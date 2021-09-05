using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pickup.Application.Features.Users.Models;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Interfaces.Services.Identity;
using Pickup.Application.Models;
using Pickup.Application.Models.Identity;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Users.Queries.GetUserBranches
{
   public class GetUserBranchesQuery : IRequest<Result<UserBranchesQueryResponse>>
    {
        public string UserId { get; set; }
    }
    public class GetUserBranchesQueryHandler : IRequestHandler<GetUserBranchesQuery, Result<UserBranchesQueryResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly IBranchRepository _branchRepository;

        public GetUserBranchesQueryHandler(IUnitOfWork unitOfWork, UserManager<BlazorHeroUser> userManager, IBranchRepository branchRepository)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _branchRepository = branchRepository;
        }

        public async Task<Result<UserBranchesQueryResponse>> Handle(GetUserBranchesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Include(x => x.Branches).FirstOrDefaultAsync(x => x.Id == request.UserId);

            var allBranches = await _unitOfWork.Repository<Branch>().GetAllAsync();
            List<UserBranchesModel> model = new List<UserBranchesModel>();
            foreach (var bran in allBranches)
            {
                if (user.Branches.Any(x=>x.Id == bran.Id))
                {
                    model.Add(new UserBranchesModel { BranchId = bran.Id, Selected = true, BranchName = bran.BranchName });
                }
                else
                {
                    model.Add(new UserBranchesModel { BranchId = bran.Id, Selected = false, BranchName = bran.BranchName });
                }
            }

            var result = new UserBranchesQueryResponse() { Branches = model };
            return await Result<UserBranchesQueryResponse>.SuccessAsync(result);
        }
    }
}
