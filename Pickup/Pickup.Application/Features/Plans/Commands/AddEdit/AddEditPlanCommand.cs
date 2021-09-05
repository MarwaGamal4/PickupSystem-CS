using MediatR;
using Pickup.Application.Models;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Plans.Commands.AddEdit
{
   public class AddEditPlanCommand : IRequest<Result<int>>
    {
        [Required]
        public string PlanName { get; set; }
        public int MealsCount { get; set; }
        public int DaysCount { get; set; }
        public decimal Price { get; set; }
        public decimal MealPrice { get; set; }
        public bool IsCustomize { get; set; }
        public int PlanTypeId { get; set; }
        public PlanType planType { get; set; }
    }
}
