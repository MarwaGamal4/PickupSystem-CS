using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbPlanCategory
    {
        public TbPlanCategory()
        {
            TbMeals = new HashSet<TbMeal>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public decimal? MaxQtyGm { get; set; }
        public decimal? MaxQtyPc { get; set; }
        public int ComId { get; set; }
        public int UserId { get; set; }
        public string Symbol { get; set; }

        public virtual ICollection<TbMeal> TbMeals { get; set; }
    }
}
