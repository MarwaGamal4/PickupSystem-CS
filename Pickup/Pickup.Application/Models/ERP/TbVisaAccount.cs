using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbVisaAccount
    {
        public int Id { get; set; }
        public int? VisaAccNum { get; set; }
        public string VisaAccName { get; set; }
        public int? ScreenId { get; set; }
        public int ComId { get; set; }
    }
}
