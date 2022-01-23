using Pickup.Application.Enums;
using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
    public class Invoice : AuditableEntity
    {
        public Invoice()
        {
            Transactions = new HashSet<Transaction>();
        }

        public InvoiceType invoiceType { get; set; }
        public decimal MealsAmount { get; set; }
        public decimal SnacksAmount { get; set; }
        public Branch branch { get; set; }
        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public PaymentType paymentType { get; set; }
        public string Internal_Num { get; set; }
        public string InvoiceURL { get; set; }
        public decimal MealPrice { get; set; }
        public decimal SnackPrice { get; set; }
        public int TotalMealsCount { get; set; }
        public int TotalSnacksCount { get; set; }
        public int CustomerPlanId { get; set; }
        public string Notes { get; set; }
        public int RemainingMeals { get; set; }
        public int RemainingSnacks { get; set; }
        [ForeignKey("CustomerPlanId")]
        public CustomerPlan customerPlan { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}
