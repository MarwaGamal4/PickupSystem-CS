using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbItemComponentsHdr
    {
        public TbItemComponentsHdr()
        {
            TbItemComponentsLines = new HashSet<TbItemComponentsLine>();
        }

        public int Id { get; set; }
        public int ManualEnterPrice { get; set; }
        public int ComplexItem { get; set; }
        public decimal? QtyNeeded { get; set; }
        public int SelectedUnitId { get; set; }
        public int CompHdrType { get; set; }
        public int ComId { get; set; }
        public int PriceType { get; set; }
        public decimal? CostPrice { get; set; }

        public virtual TbItem ComplexItemNavigation { get; set; }
        public virtual ICollection<TbItemComponentsLine> TbItemComponentsLines { get; set; }
    }
}
