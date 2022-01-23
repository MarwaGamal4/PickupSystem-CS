using AutoMapper;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pickup.Application.Features.Branches.Queries.GetAll;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Application.Models.Identity;
using Pickup.Shared.Constants.Application;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Branches.Queries.GetByUser
{
    public class GetBranchesByUserQuery : IRequest<Result<List<GetAllBranchesResponse>>>
    {
        public string UserID { get; set; }
    }
    public class GetBranchesByUserHandler : IRequestHandler<GetBranchesByUserQuery, Result<List<GetAllBranchesResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public GetBranchesByUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IAppCache cache, UserManager<BlazorHeroUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result<List<GetAllBranchesResponse>>> Handle(GetBranchesByUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserID);
            if (user != null)
            {
                if (user.UserType == Shared.Constants.User.UserConstants.UserType.CustomerService)
                {
                    Func<Task<List<Branch>>> getAllBranches = () => _unitOfWork.Repository<Branch>().GetAllAsync();
                    var branchList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllBranchesCacheKey, getAllBranches);
                    var mappedBranches = _mapper.Map<List<GetAllBranchesResponse>>(branchList);
                    return await Result<List<GetAllBranchesResponse>>.SuccessAsync(mappedBranches);
                }
                else
                {
                    var CurrentUser = await _userManager.Users.Include(x => x.Branches).Where(x => x.Id == request.UserID).FirstOrDefaultAsync();
                    if (CurrentUser != null)
                    {
                        if (CurrentUser.Branches.Count > 0)
                        {
                            var mappedBranches = _mapper.Map<List<GetAllBranchesResponse>>(CurrentUser.Branches);
                            return await Result<List<GetAllBranchesResponse>>.SuccessAsync(mappedBranches);
                        }
                        else
                        {
                            return await Result<List<GetAllBranchesResponse>>.FailAsync("No Branch Found For this User");
                        }

                    }
                    else
                    {
                        return await Result<List<GetAllBranchesResponse>>.FailAsync("User Not Found");
                    }

                }
            }
            else
            {
                return await Result<List<GetAllBranchesResponse>>.FailAsync("User Not Found");
            }

        }
    }
}
