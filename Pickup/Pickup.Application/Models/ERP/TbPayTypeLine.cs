using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPayTypeLine
    {
        public int Id { get; set; }
        public int PaymethodId { get; set; }
        public int BranchId { get; set; }

        public virtual TbPayTypeHeader Paymethod { get; set; }
    }
}
