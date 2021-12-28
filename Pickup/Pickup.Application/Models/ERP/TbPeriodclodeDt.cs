using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPeriodclodeDt
    {
        public int Id { get; set; }
        public int? CloseIdhr { get; set; }
        public int Moves { get; set; }

        public virtual TbPeriodCloseHr CloseIdhrNavigation { get; set; }
    }
}
