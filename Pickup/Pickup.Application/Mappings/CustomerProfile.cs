using AutoMapper;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<dtoCustomerRsponse, Customer>().ReverseMap();
            CreateMap<dtoCustomerRequest, Customer>().ReverseMap();
        }
    }
}
