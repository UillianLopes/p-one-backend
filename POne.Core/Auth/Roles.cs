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
        public string I18nKey { get; set; }

        public RoleActionAttribute(string i18nKey)
        {
            I18nKey = i18nKey;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    class CreateActionAttribute : RoleActionAttribute
    {
        public CreateActionAttribute() : base("@PONE.AUTH_APPS.ROLES.CREATE")
        {
        }
    }


    [AttributeUsage(AttributeTargets.Field)]
    class UpdateActionAttribute : RoleActionAttribute
    {
        public UpdateActionAttribute() : base("@PONE.AUTH_APPS.ROLES.UPDATE")
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    class DeleteActionAttribute : RoleActionAttribute
    {
        public DeleteActionAttribute() : base("@PONE.AUTH_APPS.ROLES.DELETE")
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    class ReadActionAttribute : RoleActionAttribute
    {
        public ReadActionAttribute() : base("@PONE.AUTH_APPS.ROLES.READ")
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

    public sealed class Roles
    {
        [RoleApp]
        public sealed class Admin
        {
            [RoleModule]
            public sealed class User
            {
                [CreateAction]
                public const string Create = "ADMIN_USER_CREATE";

                [UpdateAction]
                public const string Update = "ADMIN_USER_UPDATE";

                [DeleteAction]
                public const string Delete = "ADMIN_USER_DELETE";

                [ReadAction]
                public const string Read = "ADMIN_USER_READ";
            }

            [RoleModule]
            public sealed class Profile
            {
                [CreateAction]
                public const string Create = "ADMIN_PROFILE_CREATE";

                [UpdateAction]
                public const string Update = "ADMIN_PROFILE_UPDATE";

                [DeleteAction]
                public const string Delete = "ADMIN_PROFILE_DELETE";

                [ReadAction]
                public const string Read = "ADMIN_PROFILE_READ";
            }
        }

        [RoleApp]
        public sealed class Financial
        {
            [RoleModule]
            public sealed class Bank
            {
                [CreateAction]
                public const string Create = "FINANCIAL_BANK_CREATE";

                [UpdateAction]
                public const string Update = "FINANCIAL_BANK_UPDATE";

                [DeleteAction]
                public const string Delete = "FINANCIAL_BANK_DELETE";

                [ReadAction]
                public const string Read = "FINANCIAL_BANK_READ";
            }

            [RoleModule]
            public sealed class Category
            {
                [CreateAction]
                public const string Create = "FINANCIAL_CATEGORY_CREATE";

                [UpdateAction]
                public const string Update = "FINANCIAL_CATEGORY_UPDATE";

                [DeleteAction]
                public const string Delete = "FINANCIAL_CATEGORY_DELETE";

                [ReadAction]
                public const string Read = "FINANCIAL_CATEGORY_READ";
            }

            [RoleModule]
            public sealed class Dashboard
            {
                [CreateAction]
                public const string Create = "FINANCIAL_DASHBOARD_CREATE";

                [UpdateAction]
                public const string Update = "FINANCIAL_DASHBOARD_UPDATE";

                [DeleteAction]
                public const string Delete = "FINANCIAL_DASHBOARD_DELETE";

                [ReadAction]
                public const string Read = "FINANCIAL_DASHBOARD_READ";
            }

            [RoleModule]
            public sealed class Entry
            {
                [CreateAction]
                public const string Create = "FINANCIAL_ENTRY_CREATE";

                [UpdateAction]
                public const string Update = "FINANCIAL_ENTRY_UPDATE";

                [DeleteAction]
                public const string Delete = "FINANCIAL_ENTRY_DELETE";

                [ReadAction]
                public const string Read = "FINANCIAL_ENTRY_READ";
            }

            [RoleModule]
            public sealed class SubCategory
            {
                [CreateAction]
                public const string Create = "FINANCIAL_SUB_CATEGORY_CREATE";

                [UpdateAction]
                public const string Update = "FINANCIAL_SUB_CATEGORY_UPDATE";

                [DeleteAction]
                public const string Delete = "FINANCIAL_SUB_CATEGORY_DELETE";

                [ReadAction]
                public const string Read = "FINANCIAL_SUB_CATEGORY_READ";
            }

            [RoleModule]
            public sealed class Wallet
            {
                [CreateAction]
                public const string Create = "FINANCIAL_WALLET_CREATE";

                [UpdateAction]
                public const string Update = "FINANCIAL_WALLET_UPDATE";

                [DeleteAction]
                public const string Delete = "FINANCIAL_WALLET_DELETE";

                [ReadAction]
                public const string Read = "FINANCIAL_WALLET_READ";
            }
        }

    }
}
