using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPermAction
    {
        public int Id { get; set; }
        public string ActionValue { get; set; }
        public int UserId { get; set; }
        public int ComId { get; set; }
        public bool Allow { get; set; }

        public virtual TbUser User { get; set; }
    }
}
