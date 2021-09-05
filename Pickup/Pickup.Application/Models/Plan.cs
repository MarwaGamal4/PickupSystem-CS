
using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
   public class Plan : AuditableEntity
    {
        public Plan()
        {
            CustomerPlans = new HashSet<CustomerPlan>();
        }
        public string PlanName { get; set; }
        public int MealsCount { get; set; }
        public int DaysCount { get; set; }
        public decimal Price { get; set; }
        public decimal MealPrice { get; set; }
        public bool IsCustomize { get; set; }
        public int PlanTypeId { get; set; }
        public PlanType planType { get; set; }
        public virtual ICollection<CustomerPlan> CustomerPlans { get; set; }

    }
}
