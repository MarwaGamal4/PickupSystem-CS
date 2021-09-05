using AutoMapper;
using MediatR;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Domain.Entities.Catalog;
using Pickup.Shared.Wrapper;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Brands.Queries.GetById
{
    public class GetBrandByIdQuery : IRequest<Result<GetBrandByIdResponse>>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Result<GetBrandByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetBrandByIdResponse>> Handle(GetBrandByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Brand>().GetByIdAsync(query.Id);
            var mappedProduct = _mapper.Map<GetBrandByIdResponse>(product);
            return await Result<GetBrandByIdResponse>.SuccessAsync(mappedProduct);
        }
    }
}