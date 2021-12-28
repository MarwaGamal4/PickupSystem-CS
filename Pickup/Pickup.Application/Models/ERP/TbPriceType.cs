using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPriceType
    {
        public TbPriceType()
        {
            TbTransactionProps = new HashSet<TbTransactionProp>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TbTransactionProp> TbTransactionProps { get; set; }
    }
}
