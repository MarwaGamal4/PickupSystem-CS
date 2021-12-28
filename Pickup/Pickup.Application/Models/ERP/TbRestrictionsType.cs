using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbRestrictionsType
    {
        public TbRestrictionsType()
        {
            TbBankTransHdrs = new HashSet<TbBankTransHdr>();
            TbPaymentVoucherHdrs = new HashSet<TbPaymentVoucherHdr>();
            TbRestrictionHdrs = new HashSet<TbRestrictionHdr>();
            TbTransactionHeaders = new HashSet<TbTransactionHeader>();
        }

        public int Id { get; set; }
        public int? RestTypeId { get; set; }
        public string RestTypeName { get; set; }
        public string RestTypeEnglis { get; set; }
        public string RestModual { get; set; }
        public bool QtyIn { get; set; }

        public virtual ICollection<TbBankTransHdr> TbBankTransHdrs { get; set; }
        public virtual ICollection<TbPaymentVoucherHdr> TbPaymentVoucherHdrs { get; set; }
        public virtual ICollection<TbRestrictionHdr> TbRestrictionHdrs { get; set; }
        public virtual ICollection<TbTransactionHeader> TbTransactionHeaders { get; set; }
    }
}
