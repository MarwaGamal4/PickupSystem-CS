using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPaymentMethodDetail
    {
        public int Id { get; set; }
        public int PaymentsDetailsId { get; set; }
        public int MethodId { get; set; }
        public decimal Amount { get; set; }

        public virtual TbPaymentsDetail PaymentsDetails { get; set; }
    }
}
