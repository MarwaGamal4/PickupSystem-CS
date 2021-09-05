using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Application.Models.BranchManagement;
using Pickup.Application.Models.Identity;
using Pickup.Shared.Constants.Application;
using Pickup.Shared.Models;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Branches.Commands.AddUserToBranch
{
    public class AddUserToBranchCommand :IRequest<Result<int>>
    {

        public UsersToBranchRequest usersToBranchRequest { get; set; }

    }
    public class AddUserToBranchCommandHandler : IRequestHandler<AddUserToBranchCommand, Result<int>>
    {
        private readonly IStringLocalizer<AddUserToBranchCommandHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly IBranchRepository _branchRepository;
        public AddUserToBranchCommandHandler(IStringLocalizer<AddUserToBranchCommandHandler> localizer, IUnitOfWork unitOfWork, UserManager<BlazorHeroUser> userManager, IBranchRepository branchRepository)
        {

            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _branchRepository = branchRepository;
        }

        public async Task<Result<int>> Handle(AddUserToBranchCommand command, CancellationToken cancellationToken)
        {
            var branch = await _unitOfWork.Repository<Branch>().GetInclude(command.usersToBranchRequest.BranchId, x => x.Users);
            List<BlazorHeroUser> users = new List<BlazorHeroUser>();
            foreach (var id in command.usersToBranchRequest.BranchUsers)
            {
                if (id.Selected)
                {
                    var user = await _userManager.FindByIdAsync(id.Id);
                    users.Add(user);
                }
            }
            await _branchRepository.AddUsersToBranch(command.usersToBranchRequest.BranchId, users);
            await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllBranchesCacheKey);
            return await Result<int>.SuccessAsync(branch.Id, _localizer["Branch Updated"]);
        }
    }
}
