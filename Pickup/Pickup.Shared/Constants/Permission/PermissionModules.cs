﻿using System.Collections.Generic;

namespace Pickup.Shared.Constants.Permission
{
    public static class PermissionModules
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
                $"Permissions.{module}.ViewDetails",
                $"Permissions.{module}.AddCid",
            };

        }

        public static List<string> GetAllPermissionsModules()
        {
            return new List<string>()
            {
                Users,
                Roles,
                Products,
                Brands,
                Branches,
                Plans,
                Pickup,
                ManagerDashboard,
            };
        }

        public const string Users = "Users";
        public const string Roles = "Roles";
        public const string Products = "Products";
        public const string Brands = "Brands";
        public const string Branches = "Branches";
        public const string Plans = "Plans";
        public const string Pickup = "Pickup";
        public const string ManagerDashboard = "ManagerDashboard";
    }
}