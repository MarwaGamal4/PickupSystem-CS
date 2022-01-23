using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Dto
{
    public class dtoGetCustomeInvoicesRequest
    {
        public int? CustomerID { get; set; }
        public int? PlanID { get; set; }
        public int? BranchID { get; set; }
        public int? OwnerBranchID { get; set; }
    }
}
