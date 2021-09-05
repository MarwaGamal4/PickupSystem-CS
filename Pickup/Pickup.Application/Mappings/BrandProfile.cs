using AutoMapper;
using Pickup.Application.Features.Brands.Commands.AddEdit;
using Pickup.Application.Features.Brands.Queries.GetAll;
using Pickup.Application.Features.Brands.Queries.GetById;
using Pickup.Domain.Entities.Catalog;

namespace Pickup.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}