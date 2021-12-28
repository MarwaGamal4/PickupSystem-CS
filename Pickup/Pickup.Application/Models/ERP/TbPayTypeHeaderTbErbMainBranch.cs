using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPayTypeHeaderTbErbMainBranch
    {
        public int TbPayTypeHeaderId { get; set; }
        public int TbErbMainBranchesId { get; set; }

        public virtual TbErbMainBranch TbErbMainBranches { get; set; }
        public virtual TbPayTypeHeader TbPayTypeHeader { get; set; }
    }
}
