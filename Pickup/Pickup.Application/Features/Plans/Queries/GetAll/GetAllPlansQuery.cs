using AutoMapper;
using MediatR;
using Pickup.Application.Features.Plans.Queries.Dto;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Plans.Queries.GetAll
{
    public class GetAllPlansQuery : IRequest<Result<List<PlanDtoResponse>>>
    {

    }
    public class GetAllPlansQueryHandler : IRequestHandler<GetAllPlansQuery, Result<List<PlanDtoResponse>>>
    {
       private protected IPlanRepository _PlanRepository;
        private readonly IMapper _mapper;

        public GetAllPlansQueryHandler(IPlanRepository planRepository, IMapper mapper)
        {
            _PlanRepository = planRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<PlanDtoResponse>>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
        {
            var Plans = await _PlanRepository.GetAllAsync();
            var MappedPlans =_mapper.Map<List<PlanDtoResponse>>(Plans);
            return await Result<List<PlanDtoResponse>>.SuccessAsync(MappedPlans);
        }
    }
}
