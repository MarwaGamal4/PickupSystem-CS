using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Plans.Commands.AddEdit.dto
{
    public class PlanPrice
    {
        [Required]
        public int CategeoryTypeId { get; set; }
        [Required]
        public int PlanDayId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int CategoryCount { get; set; }
        [Required]
        public int MealTypeId { get; set; }
        [Required]
        public int DayCount { get; set; }
    }
}
