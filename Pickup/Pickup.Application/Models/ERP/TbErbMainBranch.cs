using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbErbMainBranch
    {
        public TbErbMainBranch()
        {
            TbAreas = new HashSet<TbArea>();
            TbDrivers = new HashSet<TbDriver>();
            TbPayTypeHeaderTbErbMainBranches = new HashSet<TbPayTypeHeaderTbErbMainBranch>();
        }

        public int Id { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public string AccountNo { get; set; }
        public string OtherAccount { get; set; }
        public string Notes { get; set; }
        public int? ComId { get; set; }
        public int? UserId { get; set; }
        public bool? Active { get; set; }
        public string MainAccount { get; set; }
        public string Costnumber { get; set; }
        public string CashNumber { get; set; }
        public bool Isfranchise { get; set; }
        public string FranchiseAccount { get; set; }
        public decimal Commission { get; set; }
        public string CommisionAccount { get; set; }

        public virtual ICollection<TbArea> TbAreas { get; set; }
        public virtual ICollection<TbDriver> TbDrivers { get; set; }
        public virtual ICollection<TbPayTypeHeaderTbErbMainBranch> TbPayTypeHeaderTbErbMainBranches { get; set; }
    }
}
