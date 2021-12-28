using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbNutMaster
    {
        public TbNutMaster()
        {
            TbItemNutirations = new HashSet<TbItemNutiration>();
        }

        public int Id { get; set; }
        public string NutName { get; set; }
        public bool IsCalculated { get; set; }
        public string Equation { get; set; }
        public int? NutId { get; set; }
        public int ComId { get; set; }
        public bool NutUsed { get; set; }
        public string Perc { get; set; }

        public virtual ICollection<TbItemNutiration> TbItemNutirations { get; set; }
    }
}
