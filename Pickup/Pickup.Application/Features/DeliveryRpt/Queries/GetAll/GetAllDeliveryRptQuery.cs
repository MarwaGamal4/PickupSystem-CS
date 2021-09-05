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

namespace Pickup.Application.Features.DeliveryRpt.Queries.GetAll
{
   public class GetAllDeliveryRptQuery : IRequest<Result<List<GetAllDeliveryRptResponse>>>
    {
        public string BranchName { get; set; }
        public string DriverName { get; set; }
        public int? CID { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime? date { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
    }
    public class GetAllDeliveryRptQueryHandler : IRequestHandler<GetAllDeliveryRptQuery, Result<List<GetAllDeliveryRptResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDeliveryRptRepository _rptRepository;

        public GetAllDeliveryRptQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDeliveryRptRepository rptRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _rptRepository = rptRepository;
        }

        public async Task<Result<List<GetAllDeliveryRptResponse>>> Handle(GetAllDeliveryRptQuery request, CancellationToken cancellationToken)
        {
            if (request.BranchName != null)
            {
                if (request.date != null)
                {
                    var RptListDate = await _rptRepository.GetRPTByBranch(request.BranchName, request.date);
                    var mappedRptDate = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptListDate);
                    return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRptDate);
                }
                else if (request.dateFrom != null && request.dateTo != null)
                {
                    var RptListDateRange = await _rptRepository.GetRPTByBranch(request.BranchName, request.dateFrom,request.dateTo);
                    var mappedRptDateRange = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptListDateRange);
                    return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRptDateRange);
                }
                var RptList = await _rptRepository.GetRPTByBranch(request.BranchName);
                var mappedRpt = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptList);
                return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRpt);

            }
            else if (request.DriverName != null)
            {
                if (request.date != null)
                {
                    var RptListDate = await _rptRepository.GetRPTByDriver(request.DriverName, request.date);
                    var mappedRptDate = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptListDate);
                    return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRptDate);
                }
                else if (request.dateFrom != null && request.dateTo != null)
                {
                    var RptListDateRange = await _rptRepository.GetRPTByDriver(request.DriverName, request.dateFrom, request.dateTo);
                    var mappedRptDateRange = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptListDateRange);
                    return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRptDateRange);
                }
                var RptList = await _rptRepository.GetRPTByDriver(request.DriverName);
                var mappedRpt = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptList);
                return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRpt);
            }
            else if (request.CID != null) 
            {
                if (request.date != null)
                {
                    var RptListDate = await _rptRepository.GetRPTByCID(request.CID, request.date);
                    var mappedRptDate = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptListDate);
                    return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRptDate);
                }
                else if (request.dateFrom != null && request.dateTo != null)
                {
                    var RptListDateRange = await _rptRepository.GetRPTByCID(request.CID, request.dateFrom, request.dateTo);
                    var mappedRptDateRange = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptListDateRange);
                    return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRptDateRange);
                }
                var RptList = await _rptRepository.GetRPTByCID(request.CID);
                var mappedRpt = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptList);
                return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRpt);
            }
            else if (request.CustomerPhone != null)
            {
                if (request.date != null)
                {
                    var RptListDate = await _rptRepository.GetRPTByCustomerPhone(request.CustomerPhone, request.date);
                    var mappedRptDate = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptListDate);
                    return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRptDate);
                }
                else if (request.dateFrom != null && request.dateTo != null)
                {
                    var RptListDateRange = await _rptRepository.GetRPTByCustomerPhone(request.CustomerPhone, request.dateFrom, request.dateTo);
                    var mappedRptDateRange = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptListDateRange);
                    return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRptDateRange);
                }
                var RptList = await _rptRepository.GetRPTByCustomerPhone(request.CustomerPhone);
                var mappedRpt = _mapper.Map<List<GetAllDeliveryRptResponse>>(RptList);
                return await Result<List<GetAllDeliveryRptResponse>>.SuccessAsync(mappedRpt);
            }
            return await Result<List<GetAllDeliveryRptResponse>>.FailAsync("Somthing Went Wrong Please Call Support");
        }
    }
}
