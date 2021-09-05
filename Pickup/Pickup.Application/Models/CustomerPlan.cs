using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
   public class CustomerPlan : AuditableEntity
    {
        public CustomerPlan()
        {
            Invoices = new HashSet<Invoice>();
        }
        public string PlanName { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public int BranchId { get; set; }
        public Branch branch { get; set; }
        public int PlanId { get; set; }
        public Plan plan { get; set; }
        public int RemainingMealsCount { get; set; }
        public int RemainingSnacksCount { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }

    }
}
