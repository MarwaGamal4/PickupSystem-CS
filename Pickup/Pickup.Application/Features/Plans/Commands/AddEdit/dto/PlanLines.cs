using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Plans.Commands.AddEdit.dto
{
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
}
