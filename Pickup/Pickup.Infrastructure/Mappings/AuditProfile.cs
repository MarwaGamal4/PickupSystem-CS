using AutoMapper;
using Pickup.Application.Models.Audit;
using Pickup.Application.Responses.Audit;

namespace Pickup.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}