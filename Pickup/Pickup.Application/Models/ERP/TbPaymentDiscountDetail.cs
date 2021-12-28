using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPaymentDiscountDetail
    {
        public int Id { get; set; }
        public int PaymentDetailsId { get; set; }
        public int DiscountId { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal Discountpercntage { get; set; }

        public virtual TbPaymentsDetail PaymentDetails { get; set; }
    }
}
