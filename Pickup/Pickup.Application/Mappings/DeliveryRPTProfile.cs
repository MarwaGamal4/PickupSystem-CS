using AutoMapper;
using Pickup.Application.Features.DeliveryRpt.Queries.GetAll;
using Pickup.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Mappings
{
   public class DeliveryRPTProfile : Profile
    {
        public DeliveryRPTProfile()
        {
            CreateMap<GetAllDeliveryRptResponse, DeliveryRPT>().ReverseMap();
        }
    }
}
