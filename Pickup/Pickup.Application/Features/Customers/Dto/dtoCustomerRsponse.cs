using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Dto
{
    public class dtoCustomerRsponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Notes { get; set; }
        public List<dtoCustomerPlanReponse> CustomerPlan { get; set; } = new();
    }
}
