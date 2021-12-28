using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbNfcOperation
    {
        public int Id { get; set; }
        public int CardSerial { get; set; }
        public DateTime ExportDate { get; set; }
        public bool Status { get; set; }
        public int CustId { get; set; }
        public int CardType { get; set; }
        public int ExportBranch { get; set; }
        public decimal CardValue { get; set; }
        public int? ComId { get; set; }
        public string PayType { get; set; }
        public decimal CardAmount { get; set; }
        public int? BankId { get; set; }
        public int NfcOpType { get; set; }

        public virtual TbNfcType CardTypeNavigation { get; set; }
        public virtual TbCustomer Cust { get; set; }
        public virtual TbBranch ExportBranchNavigation { get; set; }
    }
}
