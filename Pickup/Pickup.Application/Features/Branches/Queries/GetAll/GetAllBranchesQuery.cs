using AutoMapper;
using LazyCache;
using MediatR;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Shared.Constants.Application;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Branches.Queries.GetAll
{
    public class GetAllBranchesQuery : IRequest<Result<List<GetAllBranchesResponse>>>
    {
    }
    public class GetAllBranchesCachedQueryHandler : IRequestHandler<GetAllBranchesQuery, Result<List<GetAllBranchesResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllBranchesCachedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllBranchesResponse>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Branch>>> getAllBranches = () => _unitOfWork.Repository<Branch>().GetAllAsync();
            var branchList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllBranchesCacheKey, getAllBranches);
            var mappedBranches = _mapper.Map<List<GetAllBranchesResponse>>(branchList);
            return await Result<List<GetAllBranchesResponse>>.SuccessAsync(mappedBranches);
        }
    }
}
