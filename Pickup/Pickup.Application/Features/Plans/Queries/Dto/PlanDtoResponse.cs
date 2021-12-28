using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Plans.Queries.Dto
{
    public class PlanDtoResponse
    {
        public int Id { get; set; }

        public string PlanName { get; set; }
        public string PlanExprission { get; set; }

        public int ComId { get; set; }

        public int DaysCount { get; set; }

        public int StartDay { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsActive { get; set; }

        public int MealCategory { get; set; }
        public List<PlanPrice> TbPlanPrices { get; set; }
        public List<PlanLines> TbPlanMasterLines { get; set; }
    }
    public class PlanLines 
    {
        public int Days { get; set; }
        public string DaysNames { get; set; }
        public string MealName { get; set; }
        public int MealId { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public decimal MealCost { get; set; }
        public decimal MealPrice { get; set; }
    }
    public class PlanPrice 
    {

        public int CategeoryTypeId { get; set; }

        public int PlanDayId { get; set; }

        public decimal Amount { get; set; }

        public int CategoryCount { get; set; }

        public int MealTypeId { get; set; }

        public int DayCount { get; set; }
    }
}
