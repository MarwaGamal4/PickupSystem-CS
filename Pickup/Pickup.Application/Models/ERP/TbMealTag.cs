using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbMealTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? MaxQtyGm { get; set; }
        public decimal? MaxQtyPc { get; set; }
    }
}
