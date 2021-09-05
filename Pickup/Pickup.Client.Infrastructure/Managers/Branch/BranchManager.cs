using Pickup.Application.Features.Branches.Commands.AddEdit;
using Pickup.Application.Features.Branches.Commands.AddUserToBranch;
using Pickup.Application.Features.Branches.Queries.GetAll;
using Pickup.Application.Features.Branches.Queries.GetById;
using Pickup.Application.Features.Users.Commands.AddEditBranchesToUser;
using Pickup.Application.Features.Users.Models;
using Pickup.Client.Infrastructure.Extensions;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Branch
{
    public class BranchManager : IBranchManager
    {
        private readonly HttpClient _httpClient;

        public BranchManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.BranchesEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllBranchesResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.BranchesEndpoints.GetAll);
            return await response.ToResult<List<GetAllBranchesResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditBranchCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.BranchesEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<GetBranchbyIdResponse>> GetBranchUsersAsync(int BranchId)
        {
            var response = await _httpClient.GetAsync(Routes.BranchesEndpoints.getBranchUsers(BranchId));
            return await response.ToResult<GetBranchbyIdResponse>();
        }

        public async Task<IResult<int>> AddUsersToBranch(AddUserToBranchCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.BranchesEndpoints.AddUsersToBranch, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddBranchesToUser(AddEditBranchesToUserCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.BranchesEndpoints.AddBranchsToUser, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<UserBranchesQueryResponse>> GetUserBranchessAsync(string UserId)
        {
            var response = await _httpClient.GetAsync(Routes.BranchesEndpoints.GetUserBranches(UserId));
            return await response.ToResult<UserBranchesQueryResponse>();
        }

    }
}
