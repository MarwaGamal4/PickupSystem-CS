using Pickup.Application.Enums;
using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
   public class Invoice : AuditableEntity
    {
        public Invoice()
        {
            Inv_Images = new HashSet<Inv_Images>();
        }
        public int PlanId { get; set; }
        public InvoiceType invoiceType { get; set; }
        public Plan plan { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal Discountvalue { get; set; }
        public Branch branch { get; set; }
        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public PaymentType paymentType { get; set; }
        public int Internal_Num { get; set; }

        public virtual ICollection<Inv_Images> Inv_Images { get; set; }
        public decimal MealPrice { get; set; }
        public decimal SnackPrice { get; set; }
        public int TotalMealsCounr { get; set; }
        public int TotalSnacksCount { get; set; }
        public int CustomerPlanId { get; set; }
        public CustomerPlan customerPlan { get; set; }
        public string Notes { get; set; }

    }
}
