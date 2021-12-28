using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbItemsType
    {
        public TbItemsType()
        {
            TbItems = new HashSet<TbItem>();
        }

        public int Id { get; set; }
        public int? ItemTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TbItem> TbItems { get; set; }
    }
}
