using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbMeal
    {
        public TbMeal()
        {
            TbItemsSections = new HashSet<TbItemsSection>();
            TbManyCatMeals = new HashSet<TbManyCatMeal>();
            TbManyTypeMeals = new HashSet<TbManyTypeMeal>();
            TbMealsLines = new HashSet<TbMealsLine>();
            TbMealsNutirations = new HashSet<TbMealsNutiration>();
            TbPlanMasterLines = new HashSet<TbPlanMasterLine>();
        }

        public int Id { get; set; }
        public int? MealId { get; set; }
        public bool? MealCase { get; set; }
        public string ItemType { get; set; }
        public int? MealUnit1 { get; set; }
        public int? MainUnit { get; set; }
        public int? TbUnitsId { get; set; }
        public int? ComId { get; set; }
        public int MealTypeId { get; set; }
        public string MealCoArName { get; set; }
        public string MealCoArDesc { get; set; }
        public string MealCoEnName { get; set; }
        public string MealCoEnDesc { get; set; }
        public string MealName { get; set; }
        public byte[] MealImg { get; set; }
        public decimal? CostPrice { get; set; }
        public int? TbMenuSectionId { get; set; }
        public decimal? SalePrice { get; set; }
        public string Tag { get; set; }
        public int PlanCategoryId { get; set; }

        public virtual TbPlanCategory PlanCategory { get; set; }
        public virtual TbMenuSection TbMenuSection { get; set; }
        public virtual TbUnit TbUnits { get; set; }
        public virtual ICollection<TbItemsSection> TbItemsSections { get; set; }
        public virtual ICollection<TbManyCatMeal> TbManyCatMeals { get; set; }
        public virtual ICollection<TbManyTypeMeal> TbManyTypeMeals { get; set; }
        public virtual ICollection<TbMealsLine> TbMealsLines { get; set; }
        public virtual ICollection<TbMealsNutiration> TbMealsNutirations { get; set; }
        public virtual ICollection<TbPlanMasterLine> TbPlanMasterLines { get; set; }
    }
}
