using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            TbCustCardBalances = new HashSet<TbCustCardBalance>();
            TbCustomerAdresses = new HashSet<TbCustomerAdress>();
            TbCustomersPhones = new HashSet<TbCustomersPhone>();
            TbNfcOperations = new HashSet<TbNfcOperation>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ComId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string CustomerName { get; set; }
        public DateTime RegDate { get; set; }
        public string RegType { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public int Evalution { get; set; }
        public string Notes { get; set; }
        public bool Status { get; set; }
        public string CustomerAccount { get; set; }
        public string CustCoupon { get; set; }
        public int? RelatedId { get; set; }
        public int CustomerType { get; set; }

        public virtual TbCustomerCategory Category { get; set; }
        public virtual ICollection<TbCustCardBalance> TbCustCardBalances { get; set; }
        public virtual ICollection<TbCustomerAdress> TbCustomerAdresses { get; set; }
        public virtual ICollection<TbCustomersPhone> TbCustomersPhones { get; set; }
        public virtual ICollection<TbNfcOperation> TbNfcOperations { get; set; }
    }
}
