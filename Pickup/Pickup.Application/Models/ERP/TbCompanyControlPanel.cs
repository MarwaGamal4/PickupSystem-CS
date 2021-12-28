using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbCompanyControlPanel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? PeriodId { get; set; }
        public bool? MoreCurrancy { get; set; }
        public bool? ShowCurrencyscreen { get; set; }
        public string DublicateNumber { get; set; }
        public bool? OpeningEntry { get; set; }
        public bool? ShowControlpanel { get; set; }
        public bool? BankAccount { get; set; }
        public string AccountLenth { get; set; }
        public string IntermediateAccount { get; set; }
        public string RevenueNo { get; set; }
        public string ExpensesNo { get; set; }
        public string Suppliers { get; set; }
        public string Customers { get; set; }
        public string Cash { get; set; }
        public int? LastPeriod { get; set; }
        public int? NextPeriod { get; set; }
        public string BranchAccount { get; set; }
        public bool? NotifyItemExpire { get; set; }
        public int? DaysItemExpire { get; set; }
        public string CashAccount { get; set; }
        public string BranchSAccount { get; set; }
        public string BranchCostAccount { get; set; }
        public string StoreCostAccount { get; set; }
        public string DriverAccount { get; set; }
        public string FranciseAccount { get; set; }
        public string ThirdPartAccount { get; set; }
        public string StoreCash { get; set; }
        public string FirstGoods { get; set; }
        public string GoodsStock { get; set; }
        public string MyProperty { get; set; }
        public string CostOfGoodsSold { get; set; }
        public string StoreInventory { get; set; }
        public string Nfcsells { get; set; }
        public string BranchesSells { get; set; }
        public string StoreSells { get; set; }

        public virtual TbCompany Company { get; set; }
        public virtual TbFinancialPeriod Period { get; set; }
    }
}
