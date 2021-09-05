using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Users.Models;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models.Identity;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using Pickup.Application.Models;
using System.Threading;
using System.Threading.Tasks;
using Pickup.Shared.Constants.Application;

namespace Pickup.Application.Features.Users.Commands.AddEditBranchesToUser
{
   public class AddEditBranchesToUserCommand : IRequest<Result<int>>
    {
        public string UserID { get; set; }
        public List<UserBranchesModel> Branches { get; set; }
    }

    public class AddEditBranchesToUserCommandHandler : IRequestHandler<AddEditBranchesToUserCommand, Result<int>>
    {
        private readonly IStringLocalizer<AddEditBranchesToUserCommandHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly IBranchRepository _branchRepository;

        public AddEditBranchesToUserCommandHandler(IStringLocalizer<AddEditBranchesToUserCommandHandler> localizer, IUnitOfWork unitOfWork, UserManager<BlazorHeroUser> userManager, IBranchRepository branchRepository)
        {
            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _branchRepository = branchRepository;
        }

        public async Task<Result<int>> Handle(AddEditBranchesToUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Include(x => x.Branches).FirstOrDefaultAsync(x => x.Id == command.UserID);
            List<Branch> branches = new List<Branch>();

            foreach (var userBranche in command.Branches)
            {
                if (userBranche.Selected)
                {
                    var bran = await _unitOfWork.Repository<Branch>().GetByIdAsync(userBranche.BranchId);
                    branches.Add(bran);
                }
            }
            await _branchRepository.AddBranchesToUserh(command.UserID, branches);
            return await Result<int>.SuccessAsync(await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllBranchesCacheKey), _localizer["User Updated"]);
        }
    }
}
