using MediatR;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Brands.Commands.Delete;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Shared.Constants.Application;
using Pickup.Shared.Wrapper;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Branches.Commands.Delete
{
    public class DeleteBranchCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Result<int>>
        {
        private readonly IStringLocalizer<DeleteBrandCommandHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBranchRepository _branchRepository;

        public DeleteBranchCommandHandler(IStringLocalizer<DeleteBrandCommandHandler> localizer, IUnitOfWork unitOfWork, IBranchRepository branchRepository)
        {
            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _branchRepository = branchRepository;
        }

        public async Task<Result<int>> Handle(DeleteBranchCommand command, CancellationToken cancellationToken)
        {
            var BranchInUse = await _branchRepository.IsBranchInuse(command.Id);
            if (!BranchInUse)
            {
                var branch = await _unitOfWork.Repository<Branch>().GetByIdAsync(command.Id);
                await _unitOfWork.Repository<Branch>().DeleteAsync(branch);
                await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllBranchesCacheKey);
                return await Result<int>.SuccessAsync(branch.Id, _localizer["Branch Deleted"]);
            }
            else
            {
                return await Result<int>.FailAsync(_localizer["Deletion Not Allowed For This Branch"]);
            }

        }
    }

}
