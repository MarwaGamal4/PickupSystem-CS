using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbSubscrbtionHeader
    {
        public TbSubscrbtionHeader()
        {
            TbPaymentsDetails = new HashSet<TbPaymentsDetail>();
            TbSubscrbtionDetails = new HashSet<TbSubscrbtionDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AdressId { get; set; }
        public int PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public int RemainingDays { get; set; }
        public string SubscriptionExepression { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public int LastPaymentId { get; set; }
        public int DriverId { get; set; }
        public int BranchId { get; set; }
        public int Notes { get; set; }
        public int OldCid { get; set; }
        public int Pointer { get; set; }

        public virtual ICollection<TbPaymentsDetail> TbPaymentsDetails { get; set; }
        public virtual ICollection<TbSubscrbtionDetail> TbSubscrbtionDetails { get; set; }
    }
}
