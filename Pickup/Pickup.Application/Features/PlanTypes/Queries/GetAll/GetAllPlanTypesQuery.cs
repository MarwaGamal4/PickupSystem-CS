using AutoMapper;
using MediatR;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.PlanTypes.Queries.GetAll
{
    public class GetAllPlanTypesQuery : IRequest<Result<List<GetAllPlanTypesResponse>>>
    {
    }
    public class GetAllPlanTypesQueryHandler : IRequestHandler<GetAllPlanTypesQuery, Result<List<GetAllPlanTypesResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPlanTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Result<List<GetAllPlanTypesResponse>>> Handle(GetAllPlanTypesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
