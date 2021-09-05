using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Shared.Constants.Application;
using Pickup.Shared.Wrapper;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Pickup.Application.Models;

namespace Pickup.Application.Features.Branches.Commands.AddEdit
{
    public  class AddEditBranchCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public string BranchName { get; set; }
    }

    public class AddEditBranchHandler : IRequestHandler<AddEditBranchCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditBranchHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBranchRepository _branchRepository;

        public AddEditBranchHandler(IMapper mapper, IStringLocalizer<AddEditBranchHandler> localizer, IUnitOfWork unitOfWork , IBranchRepository branchRepository)
        {
            _mapper = mapper;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _branchRepository = branchRepository;
        }

        public async Task<Result<int>> Handle(AddEditBranchCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var branchExist = await _branchRepository.IsBranchExist(command.BranchName);
                if (!branchExist)
                {
                    var branch = _mapper.Map<Branch>(command);
                    await _unitOfWork.Repository<Branch>().AddAsync(branch);
                    await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllBranchesCacheKey);
                    return await Result<int>.SuccessAsync(branch.Id, _localizer["Branch Saved"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Branch Already Exist"]);
                }

            }
            else
            {
                var branch = await _unitOfWork.Repository<Branch>().GetByIdAsync(command.Id);
                if (branch != null)
                {
                    var branchExist = await _branchRepository.IsBranchExist(command.BranchName);
                    if (branchExist && branch.BranchName != command.BranchName)
                    {
                        return await Result<int>.FailAsync(_localizer["Branch Name Already Exist"]);
                    }
                    branch.BranchName = command.BranchName ?? branch.BranchName;
                    await _unitOfWork.Repository<Branch>().UpdateAsync(branch);
                    await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllBranchesCacheKey);
                    return await Result<int>.SuccessAsync(branch.Id, _localizer["Branch Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Branch Not Found!"]);
                }
            }
        }
    }
}
