using System;
using System.Collections.Generic;
using System.Reflection;

namespace POne.Core.Auth
{

    public class RolesUtils
    {
        static IEnumerable<string> GetI18nKeysFromType(MemberInfo member, string prefix)
        {

            if (member is FieldInfo fieldInfo)
            {
                if (fieldInfo.GetCustomAttribute<RoleActionAttribute>() is RoleActionAttribute actionAttribute)
                {
                    var newPrefix = $"{prefix}.ROLES.{fieldInfo.Name.ToUpper()}";
                    yield return actionAttribute.I18nKey ?? $"{newPrefix}.TITLE";
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
            action.Title = roleAppAttribute.I18nKey ?? $"{newPrefix}.TITLE";
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
}
