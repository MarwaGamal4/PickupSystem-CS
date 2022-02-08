
namespace Pickup.Shared.Constants.Permission
{
    public static class Permissions
    {
        public static class Products
        {
            public const string View = "Permissions.Products.View";
            public const string Create = "Permissions.Products.Create";
            public const string Edit = "Permissions.Products.Edit";
            public const string Delete = "Permissions.Products.Delete";
        }

        public static class Brands
        {
            public const string View = "Permissions.Brands.View";
            public const string Create = "Permissions.Brands.Create";
            public const string Edit = "Permissions.Brands.Edit";
            public const string Delete = "Permissions.Brands.Delete";
        }

        public static class Users
        {
            public const string View = "Permissions.Users.View";
            public const string Create = "Permissions.Users.Create";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
        }

        public static class Roles
        {
            public const string View = "Permissions.Roles.View";
            public const string Create = "Permissions.Roles.Create";
            public const string Edit = "Permissions.Roles.Edit";
            public const string Delete = "Permissions.Roles.Delete";
        }

        public static class Branches
        {
            public const string View = "Permissions.Branches.View";
            public const string Create = "Permissions.Branches.Create";
            public const string Edit = "Permissions.Branches.Edit";
            public const string Delete = "Permissions.Branches.Delete";
            public const string Users = "Permissions.Branches.Users";
        }
        public static class Plans
        {
            public const string View = "Permissions.Plans.View";
            public const string Create = "Permissions.Plans.Create";
            public const string Edit = "Permissions.Plans.Edit";
            public const string Delete = "Permissions.Plans.Delete";
        }
        public static class Pickup
        {
            public const string View = "Permissions.Pickup.View";
            public const string EditTransaction = "Permissions.Pickup.EditTransaction";
            public const string EditInvoice = "Permissions.Pickup.EditInvoice";
        }
        public static class ManagerDashboard
        {
            public const string View = "Permissions.ManagerDashboard.View";
            public const string Delete = "Permissions.ManagerDashboard.Delete";
            public const string ViewDetails = "Permissions.ManagerDashboard.ViewDetails";
            public const string AddCid = "Permissions.ManagerDashboard.AddCid";

        }
        public static class DeliveryRPT
        {
            public const string View = "Permissions.DeliveryRPT.View";

        }
        public static class Preferences
        {
            //TODO: add permissions
        }
    }
}