using Pickup.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Dto
{
    public enum TransType { Transaction, Invoice }
    public class dtoTimelineResponse
    {
        public int TransactionID { get; set; }
        public int ServedBranchID { get; set; }
        public int OwnerBranchID { get; set; }
        public int MealsCount { get; set; }
        public int SnacksCount { get; set; }
        public decimal MealsAmount { get; set; }
        public decimal SnacksAmount { get; set; }
        public decimal TotalTransactionValue { get; set; }
        public int PlanID { get; set; }
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public string ServedBranchName { get; set; }
        public string OwnerBranchName { get; set; }
        public string UserName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Inv_Url { get; set; }
        public TransType TransactionType { get; set; }
        public InvoiceType? invoiceType { get; set; }

    }
}
