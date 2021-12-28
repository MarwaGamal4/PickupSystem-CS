using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbSponserDiscount
    {
        public int Id { get; set; }
        public int DiscId { get; set; }
        public string DiscName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal? DiscVal { get; set; }
        public decimal? DiscPerc { get; set; }
        public bool State { get; set; }
        public int DiscType { get; set; }
        public int CustCount { get; set; }
        public int PointCount { get; set; }

        public virtual TbDiscountOption Disc { get; set; }
    }
}
