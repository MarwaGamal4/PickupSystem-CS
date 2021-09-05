using AutoMapper;
using Pickup.Application.Features.Branches.Commands.AddEdit;
using Pickup.Application.Features.Branches.Commands.AddUserToBranch;
using Pickup.Application.Features.Branches.Queries.GetAll;
using Pickup.Application.Models;

namespace Pickup.Application.Mappings
{
    public  class BranchProfile :Profile
    {
        public BranchProfile()
        {
            CreateMap<AddEditBranchCommand, Branch>().ReverseMap();
            CreateMap<AddUserToBranchCommand, UserBranches>().ReverseMap();
            CreateMap<GetAllBranchesResponse, Branch>().ReverseMap();
        }
    }
}
