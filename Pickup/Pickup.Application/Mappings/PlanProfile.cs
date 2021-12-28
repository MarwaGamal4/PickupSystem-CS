using AutoMapper;
using Pickup.Application.Features.Plans.Commands.AddEdit;
using Pickup.Application.Features.Plans.Commands.AddEdit.dto;
using Pickup.Application.Models.ERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Mappings
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<AddEditPlanCommand,TbPlanMasterHdr>().ReverseMap();
            CreateMap<PlanLines,TbPlanMasterLine>().ReverseMap();
            CreateMap<PlanPrice,TbPlanPrice>().ReverseMap();
            CreateMap<Features.Plans.Queries.Dto.PlanDtoResponse, TbPlanMasterHdr>().ReverseMap();
            CreateMap<Features.Plans.Queries.Dto.PlanLines, TbPlanMasterLine>().ReverseMap();
            CreateMap<Features.Plans.Queries.Dto.PlanPrice, TbPlanPrice>().ReverseMap();
        }
    }
}
