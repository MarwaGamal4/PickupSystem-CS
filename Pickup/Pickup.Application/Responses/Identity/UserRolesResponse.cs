﻿using System.Collections.Generic;

namespace Pickup.Application.Responses.Identity
{
    public class UserRolesResponse
    {
        public List<UserRoleModel> UserRoles { get; set; } = new List<UserRoleModel>();
    }

    public class UserRoleModel
    {
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}