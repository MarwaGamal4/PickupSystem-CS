using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbUserBranche
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }

        public virtual TbUser User { get; set; }
    }
}
