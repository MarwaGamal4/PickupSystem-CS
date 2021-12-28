using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPaymentsDetail
    {
        public TbPaymentsDetail()
        {
            TbPaymentDiscountDetails = new HashSet<TbPaymentDiscountDetail>();
            TbPaymentMethodDetails = new HashSet<TbPaymentMethodDetail>();
        }

        public int Id { get; set; }
        public int SubscrbtionId { get; set; }
        public int CustomerId { get; set; }
        public int CustomerType { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public string Notes { get; set; }
        public int InvoiceType { get; set; }
        public int InvoiceState { get; set; }

        public virtual TbSubscrbtionHeader Subscrbtion { get; set; }
        public virtual ICollection<TbPaymentDiscountDetail> TbPaymentDiscountDetails { get; set; }
        public virtual ICollection<TbPaymentMethodDetail> TbPaymentMethodDetails { get; set; }
    }
}
