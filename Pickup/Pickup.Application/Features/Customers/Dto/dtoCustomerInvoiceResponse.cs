using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Dto
{
    public class dtoCustomerInvoiceResponse
    {
        public int InvoiceID { get; set; }
        public int PlanID { get; set; }
        public int CustomerID { get; set; }
        public string Invoice_Url { get; set; }
        public string PlanName { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public int MealsCount { get; set; }
        public int SnacksCount { get; set; }
        public decimal MealsAmount { get; set; }
        public decimal SnacksAmount { get; set; }
        public decimal TotalValue { get; set; }
        public List<dtoPlanTransaction> Transactions { get; set; }

    }
}
