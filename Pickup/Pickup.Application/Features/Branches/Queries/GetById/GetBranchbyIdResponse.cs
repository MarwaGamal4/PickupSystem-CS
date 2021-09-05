using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Branches.Queries.GetById
{
   public class GetBranchbyIdResponse
    {
       public List<UsersBranchResponse> Users { get; set; }
    }
    public class UsersBranchResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public bool Selected { get; set; }
    }
}
