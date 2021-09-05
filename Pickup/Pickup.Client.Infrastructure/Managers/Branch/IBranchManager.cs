using Pickup.Application.Features.Branches.Commands.AddEdit;
using Pickup.Application.Features.Branches.Commands.AddUserToBranch;
using Pickup.Application.Features.Branches.Queries.GetAll;
using Pickup.Application.Features.Branches.Queries.GetById;
using Pickup.Application.Features.Users.Commands.AddEditBranchesToUser;
using Pickup.Application.Features.Users.Models;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Branch
{
    public interface IBranchManager : IManager
    {
        Task<IResult<int>> DeleteAsync(int id);
        Task<IResult<List<GetAllBranchesResponse>>> GetAllAsync();
        Task<IResult<int>> SaveAsync(AddEditBranchCommand request);
        Task<IResult<int>> AddUsersToBranch(AddUserToBranchCommand request);
        Task<IResult<GetBranchbyIdResponse>> GetBranchUsersAsync(int BranchId);
        Task<IResult<UserBranchesQueryResponse>> GetUserBranchessAsync(string UserId);
        Task<IResult<int>> AddBranchesToUser(AddEditBranchesToUserCommand request);
    }
}