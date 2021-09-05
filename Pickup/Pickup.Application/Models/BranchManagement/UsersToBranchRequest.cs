using Pickup.Application.Features.Branches.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models.BranchManagement
{
   public class UsersToBranchRequest
    {
        public int BranchId { get; set; }
        public IList<UsersBranchResponse> BranchUsers { get; set; }
    }
}
