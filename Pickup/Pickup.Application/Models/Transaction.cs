using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
    public class Transaction : AuditableEntity
    {
        [ForeignKey("branch")]
        public int BranchId { get; set; }
        public Branch branch { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public int CustomerPlanId { get; set; }
        public CustomerPlan customerPlan { get; set; }
        public int MealCount { get; set; }
        public int SnackCount { get; set; }
        public string Inv_url { get; set; }
        public string Notes { get; set; }
        [ForeignKey("CreditBranch")]
        public int CreditBranchId { get; set; }
        public Branch CreditBranch { get; set; }
        public decimal CreditValue { get; set; }
        public int InvoiceID { get; set; }
        [ForeignKey("InvoiceID")]
        public Invoice invoice { get; set; }

    }
}
