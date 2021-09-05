using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models.BranchManagement
{

    public class UsersToBranchResponse
    {
        IList<UsersToBranchModel> BranchesUsers { get; set; } = new List<UsersToBranchModel>();
    }
    public class UsersToBranchModel
    {
        public string Id { get; set; }
        public bool Selected { get; set; }
    }
}
