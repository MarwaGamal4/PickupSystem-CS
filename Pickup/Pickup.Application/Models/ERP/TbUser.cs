using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbUser
    {
        public TbUser()
        {
            TbLogUserScrs = new HashSet<TbLogUserScr>();
            TbPermActions = new HashSet<TbPermAction>();
            TbUserBranches = new HashSet<TbUserBranche>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public bool? UserActive { get; set; }
        public int? ComId { get; set; }
        public byte[] UserImage { get; set; }
        public int? UserCode { get; set; }
        public bool Admin { get; set; }

        public virtual TbCompany Com { get; set; }
        public virtual ICollection<TbLogUserScr> TbLogUserScrs { get; set; }
        public virtual ICollection<TbPermAction> TbPermActions { get; set; }
        public virtual ICollection<TbUserBranche> TbUserBranches { get; set; }
    }
}
