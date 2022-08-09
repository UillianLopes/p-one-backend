using System;
using System.Collections.Generic;
using System.Reflection;

namespace POne.Core.Auth
{

    abstract class RoleAttribute : Attribute
    {
        public RoleAttribute() { }

        public string I18n { get; private set; }
    }


    [AttributeUsage(AttributeTargets.Class)]
    class RoleAppAttribute : RoleAttribute
    {
        public RoleAppAttribute() : base()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    class RoleModuleAttribute : RoleAttribute
    {
        public RoleModuleAttribute() : base()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    class RoleActionAttribute : RoleAttribute
    {
        public RoleActionAttribute() : base()
        {
        }
    }

    public record AuthRole
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
    }

    public record AuthModule
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public AuthModule()
        {
            Roles = new List<AuthRole>();
        }

        public List<AuthRole> Roles { get; private set; }
    }

    public record AuthApp
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public AuthApp()
        {
            Modules = new List<AuthModule>();
        }

        public List<AuthModule> Modules { get; private set; }
    }

    public class RolesUtils
    {
        static IEnumerable<string> GetI18nKeysFromType(MemberInfo member, string prefix)
        {

            if (member is FieldInfo fieldInfo)
            {
                if (fieldInfo.GetCustomAttribute<RoleActionAttribute>() is RoleActionAttribute appAttribute)
                {
                    var newPrefix = $"{prefix}.ROLES.{appAttribute.I18n ?? fieldInfo.Name.ToUpper()}";
                    yield return $"{newPrefix}.TITLE";
                    yield return $"{newPrefix}.DESCRIPTION";
                }
            }
            else if (member is Type memberType && memberType.IsClass)
            {
                if (memberType.GetCustomAttribute<RoleAppAttribute>() is RoleAppAttribute appAttribute)
                {
                    var newPrefix = $"{prefix}.{appAttribute.I18n ?? memberType.Name.ToUpper()}";
                    yield return $"{newPrefix}.TITLE";
                    yield return $"{newPrefix}.DESCRIPTION";

                    foreach (var fieldMember in memberType.GetFields())
                        foreach (var role in GetI18nKeysFromType(fieldMember, newPrefix))
                            yield return role;

                    foreach (var nestedType in memberType.GetNestedTypes())
                        foreach (var role in GetI18nKeysFromType(nestedType, newPrefix))
                            yield return role;

                }
                else if (memberType.GetCustomAttribute<RoleModuleAttribute>() is RoleModuleAttribute moduleAttribute)
                {
                    var newPrefix = $"{prefix}.MODULES.{moduleAttribute.I18n ?? memberType.Name.ToUpper()}";
                    yield return $"{newPrefix}.TITLE";
                    yield return $"{newPrefix}.DESCRIPTION";

                    foreach (var fieldMember in memberType.GetFields())
                        foreach (var role in GetI18nKeysFromType(fieldMember, newPrefix))
                            yield return role;

                    foreach (var nestedType in memberType.GetNestedTypes())
                        foreach (var role in GetI18nKeysFromType(nestedType, newPrefix))
                            yield return role;
                }
            }

            yield break;
        }

        public static IEnumerable<string> GenerateI18nKeysBasedOnRoles()
        {
            foreach (var memberType in typeof(Roles).GetNestedTypes())
                foreach (var value in GetI18nKeysFromType(memberType, "@PONE.AUTH_APPS"))
                    yield return value;
        }

        static AuthRole GetAction(FieldInfo member, string prefix)
        {
            if (member.GetCustomAttribute<RoleActionAttribute>() is not RoleActionAttribute roleAppAttribute)
                return null;

            var action = new AuthRole();
            var newPrefix = $"{prefix}.ROLES.{roleAppAttribute.I18n ?? member.Name.ToUpper()}";
            action.Description = $"{newPrefix}.DESCRIPTION";
            action.Title = $"{newPrefix}.TITLE";
            action.Key = (string)member.GetValue(null);

            return action;
        }

        static AuthModule GetModule(MemberInfo member, string prefix)
        {
            if (member is not Type memberType || memberType.GetCustomAttribute<RoleModuleAttribute>() is not RoleModuleAttribute roleAppAttribute)
                return null;

            var module = new AuthModule();
            var newPrefix = $"{prefix}.MODULES.{roleAppAttribute.I18n ?? member.Name.ToUpper()}";
            module.Description = $"{newPrefix}.DESCRIPTION";
            module.Title = $"{newPrefix}.TITLE";

            foreach (var fieldInfo in memberType.GetFields())
                if (GetAction(fieldInfo, newPrefix) is AuthRole jsonAction)
                    module.Roles.Add(jsonAction);

            return module;
        }

        static AuthApp GetApp(MemberInfo member, string prefix)
        {
            if (member is not Type memberType || memberType.GetCustomAttribute<RoleAppAttribute>() is not RoleAppAttribute roleAppAttribute)
                return null;

            var app = new AuthApp();
            var newPrefix = $"{prefix}.{roleAppAttribute.I18n ?? member.Name.ToUpper()}";
            app.Description = $"{newPrefix}.DESCRIPTION";
            app.Title = $"{newPrefix}.TITLE";

            foreach (var fieldInfo in memberType.GetNestedTypes())
                if (GetModule(fieldInfo, newPrefix) is AuthModule jsonModule)
                    app.Modules.Add(jsonModule);

            return app;
        }

        public static IEnumerable<AuthApp> ReadAppsAndRoles()
        {
            foreach (var memberType in typeof(Roles).GetNestedTypes())
                yield return GetApp(memberType, "@PONE.AUTH_APPS");
        }

        public static ISet<string> GetAllRoleKeys()
        {
            var rolesSet = new SortedSet<string>();

            foreach (var appType in typeof(Roles).GetNestedTypes())
            {
                if (appType.GetCustomAttribute<RoleAppAttribute>() is not RoleAppAttribute roleApp)
                    continue;

                foreach (var moduleType in appType.GetNestedTypes())
                {
                    if (moduleType.GetCustomAttribute<RoleModuleAttribute>() is not RoleModuleAttribute roleModule)
                        continue;

                    foreach (var roleField in moduleType.GetFields())
                    {
                        if (roleField.GetCustomAttribute<RoleActionAttribute>() is not RoleActionAttribute roleAction)
                            continue;

                        var role = (string)roleField.GetValue(null);

                        rolesSet.Add(role);
                    }

                }
            }

            return rolesSet;
        }
    }

    public sealed class Roles
    {
        [RoleApp]
        public sealed class Admin
        {
            [RoleModule]
            public sealed class User
            {
                [RoleAction]
                public const string Create = "ADMIN_USER_CREATE";

                [RoleAction]
                public const string Update = "ADMIN_USER_UPDATE";

                [RoleAction]
                public const string Delete = "ADMIN_USER_DELETE";

                [RoleAction]
                public const string Read = "ADMIN_USER_READ";
            }

            [RoleModule]
            public sealed class Profile
            {
                [RoleAction]
                public const string Create = "ADMIN_PROFILE_CREATE";

                [RoleAction]
                public const string Update = "ADMIN_PROFILE_UPDATE";

                [RoleAction]
                public const string Delete = "ADMIN_PROFILE_DELETE";

                [RoleAction]
                public const string Read = "ADMIN_PROFILE_READ";
            }
        }

        [RoleApp]
        public sealed class Financial
        {
            [RoleModule]
            public sealed class Bank
            {
                [RoleAction]
                public const string Create = "FINANCIAL_BANK_CREATE";

                [RoleAction]
                public const string Update = "FINANCIAL_BANK_UPDATE";

                [RoleAction]
                public const string Delete = "FINANCIAL_BANK_DELETE";

                [RoleAction]
                public const string Read = "FINANCIAL_BANK_READ";
            }

            [RoleModule]
            public sealed class Category
            {
                [RoleAction]
                public const string Create = "FINANCIAL_CATEGORY_CREATE";

                [RoleAction]
                public const string Update = "FINANCIAL_CATEGORY_UPDATE";

                [RoleAction]
                public const string Delete = "FINANCIAL_CATEGORY_DELETE";

                [RoleAction]
                public const string Read = "FINANCIAL_CATEGORY_READ";
            }

            [RoleModule]
            public sealed class Dashboard
            {
                [RoleAction]
                public const string Create = "FINANCIAL_DASHBOARD_CREATE";

                [RoleAction]
                public const string Update = "FINANCIAL_DASHBOARD_UPDATE";

                [RoleAction]
                public const string Delete = "FINANCIAL_DASHBOARD_DELETE";

                [RoleAction]
                public const string Read = "FINANCIAL_DASHBOARD_READ";
            }

            [RoleModule]
            public sealed class Entry
            {
                [RoleAction]
                public const string Create = "FINANCIAL_ENTRY_CREATE";

                [RoleAction]
                public const string Update = "FINANCIAL_ENTRY_UPDATE";

                [RoleAction]
                public const string Delete = "FINANCIAL_ENTRY_DELETE";

                [RoleAction]
                public const string Read = "FINANCIAL_ENTRY_READ";
            }

            [RoleModule]
            public sealed class SubCategory
            {
                [RoleAction]
                public const string Create = "FINANCIAL_SUB_CATEGORY_CREATE";

                [RoleAction]
                public const string Update = "FINANCIAL_SUB_CATEGORY_UPDATE";

                [RoleAction]
                public const string Delete = "FINANCIAL_SUB_CATEGORY_DELETE";

                [RoleAction]
                public const string Read = "FINANCIAL_SUB_CATEGORY_READ";
            }

            [RoleModule]
            public sealed class Wallet
            {
                [RoleAction]
                public const string Create = "FINANCIAL_WALLET_CREATE";

                [RoleAction]
                public const string Update = "FINANCIAL_WALLET_UPDATE";

                [RoleAction]
                public const string Delete = "FINANCIAL_WALLET_DELETE";

                [RoleAction]
                public const string Read = "FINANCIAL_WALLET_READ";
            }
        }

    }
}
