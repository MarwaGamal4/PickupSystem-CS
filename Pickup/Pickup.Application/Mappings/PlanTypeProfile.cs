using AutoMapper;
using Pickup.Application.Features.PlanTypes.Commands.AddEdit;
using Pickup.Application.Features.PlanTypes.Queries.GetAll;
using Pickup.Application.Models;

namespace Pickup.Application.Mappings
{
   public class PlanTypeProfile :Profile
    {
        public PlanTypeProfile()
        {
          //  CreateMap<AddEditTypeCommand, PlanType>().ReverseMap();
            CreateMap<GetAllPlanTypesResponse, PlanType>().ReverseMap();
        }
    }
}
