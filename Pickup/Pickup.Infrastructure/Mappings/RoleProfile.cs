using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Pickup.Application.Responses.Identity;

namespace Pickup.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, IdentityRole>().ReverseMap();
        }
    }
}