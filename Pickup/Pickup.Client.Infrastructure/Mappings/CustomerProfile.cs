using AutoMapper;
using Pickup.Application.Features.Customers.Commands.AddEdit;
using Pickup.Application.Features.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerCommand, dtoCustomerRequest>().ReverseMap();
        }
    }
}
