using AutoMapper;
using Pickup.Application.Features.Products.Commands.AddEdit;
using Pickup.Domain.Entities.Catalog;

namespace Pickup.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}