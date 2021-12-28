using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbItemNutiration
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public double Value { get; set; }
        public int NutMasterid { get; set; }
        public string NutMasterName { get; set; }
        public string NutMasterEquation { get; set; }
        public double NutPerc { get; set; }
        public string NutMasterPercEquation { get; set; }
        public double ItemNutQty { get; set; }
        public string ItemNutUnit { get; set; }
        public bool NotCalcRow { get; set; }
        public int ComId { get; set; }

        public virtual TbItem Item { get; set; }
        public virtual TbNutMaster NutMaster { get; set; }
    }
}
