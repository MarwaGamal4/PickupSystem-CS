using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Shared.Wrapper;
using Pickup.Application.Models;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pickup.Application.Features.PlanTypes.Commands.AddEdit
{
    public class AddEditTypeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public string PlanTypeName { get; set; }
        [Required]
        public string PlanSlogan { get; set; }
    }
    public class AddEditTypeCommandHanler : IRequestHandler<AddEditTypeCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditTypeCommandHanler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlanTypeRepository _PlanTypeRepository;

        public AddEditTypeCommandHanler(IMapper mapper, IStringLocalizer<AddEditTypeCommandHanler> localizer, IUnitOfWork unitOfWork, IPlanTypeRepository planTypeRepository)
        {
            _mapper = mapper;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _PlanTypeRepository = planTypeRepository;
        }

        public async Task<Result<int>> Handle(AddEditTypeCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                var PlanSolganExist = await _PlanTypeRepository.IsPlanSolganExist(request.PlanSlogan);
                var PlanNameExist = await _PlanTypeRepository.IsPlanTypeExist(request.PlanTypeName);
                if (PlanSolganExist)
                {
                    return await Result<int>.FailAsync(_localizer["PlanType Solgan Already Exist!"]);
                }
                else if (PlanNameExist)
                {
                    return await Result<int>.FailAsync(_localizer["PlanType Name Already Exist!"]);
                }
                else
                {
                    var planType = _mapper.Map<PlanType>(request);
                    await _unitOfWork.Repository<PlanType>().AddAsync(planType);
                    return await Result<int>.SuccessAsync(planType.Id, _localizer["PlanType Added Successfully"]);
                }
            }
            else
            {
                var PlanType = await _unitOfWork.Repository<PlanType>().GetByIdAsync(request.Id);
                if (PlanType != null)
                {
                    var planTypeNameExist = await _PlanTypeRepository.IsPlanTypeExist(request.PlanTypeName);
                    var PlanSolganExist = await _PlanTypeRepository.IsPlanSolganExist(request.PlanSlogan);

                    if (planTypeNameExist && PlanType.PlanTypeName != request.PlanTypeName)
                    {
                        return await Result<int>.FailAsync(_localizer["PlanType Name Already Exist!"]);
                    }
                    else if (PlanSolganExist && PlanType.PlanSlogan != request.PlanSlogan)
                    {
                        return await Result<int>.FailAsync(_localizer["PlanType Solgan Already Exist!"]);
                    }
                    else
                    {
                        PlanType.PlanTypeName = request.PlanTypeName ?? PlanType.PlanTypeName;
                        PlanType.PlanSlogan = request.PlanSlogan ?? PlanType.PlanSlogan;
                        await _unitOfWork.Repository<PlanType>().UpdateAsync(PlanType);
                        return await Result<int>.SuccessAsync(PlanType.Id, _localizer["PlanType Updated"]);
                    }
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["PlanType Not Found!"]);
                }

            }
        }
    }
}
