using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Dto
{
    public class dtoCustomerPlanReponse
    {
        public int CustomerPlanID { get; set; }
        public int RemainingMeals { get; set; } = 0;
        public int RemainingSnacks { get; set; } = 0;
        public string PlanName { get; set; } = "";
    }
}
