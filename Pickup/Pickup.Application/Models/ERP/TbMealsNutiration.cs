using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbMealsNutiration
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public double Value { get; set; }
        public double NutPerc { get; set; }
        public string NutMasterName { get; set; }
        public bool NotCalcRow { get; set; }
        public int ComId { get; set; }

        public virtual TbMeal Meal { get; set; }
    }
}
