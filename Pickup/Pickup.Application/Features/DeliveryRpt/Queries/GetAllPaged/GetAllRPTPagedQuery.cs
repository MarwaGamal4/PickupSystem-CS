using LinqKit;
using MediatR;
using Pickup.Application.Extensions;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Application.Specifications;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.DeliveryRpt.Queries.GetAllPaged
{
   public class GetAllRPTPagedQuery : IRequest<CustomPagingResult<GetAllRPTPagedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Branch { get; set; }
        public string Driver { get; set; }
        public int? CID { get; set; }
        public int?[] Status { get; set; }
        public string sender_from_driver { get; set; }
        public GetAllRPTPagedQuery(int pageNumber, int pageSize, string searchString, DateTime? from , DateTime? to , string branch , string driver , int? cid , int?[] status , string Sender_from_driver)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            Branch = branch;
            Driver = driver;
            CID = cid;
            From = from;
            To = to;
            Status = status;
            sender_from_driver = Sender_from_driver;
        }


    }
    public class GetAllRPTPagedQueryHandler : IRequestHandler<GetAllRPTPagedQuery, CustomPagingResult<GetAllRPTPagedResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeliveryRptRepository _rptRepository;
        public GetAllRPTPagedQueryHandler(IUnitOfWork unitOfWork , IDeliveryRptRepository rptRepository)
        {
            _unitOfWork = unitOfWork;
            _rptRepository = rptRepository;
        }

        public async Task<CustomPagingResult<GetAllRPTPagedResponse>> Handle(GetAllRPTPagedQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<DeliveryRPT, GetAllRPTPagedResponse>> expression = (e) => new GetAllRPTPagedResponse
            {
                Id = e.Id,
                DeliveryName =e.DeliveryName   ,
                DeliveryNote = e.DeliveryNote,
                DeliveryStatus = e.DeliveryStatus,
                DriverLatitude = e.DriverLatitude,
                DriverLongitude = e.DriverLongitude,
                PrintDate = e.PrintDate,
                ActionTime = e.ActionTime,
                CustomerAddress = e.CustomerAddress,
                BranchName = e.BranchName,
                CustomerId =  e.CustomerId,
                CustomerName = e.CustomerName,
                CustomerPhone = e.CustomerPhone,
                sender_from_driver = e.sender_from_driver
                
            };
            
           
            var RptFilterSpec = new DeliveryRPTFilterSpecification(request.SearchString);
            if (request.Branch != null)
            {
                RptFilterSpec.Criteria = RptFilterSpec.Criteria.And(x => x.BranchName == request.Branch);
            }
            if (request.Driver != null)
            {
                RptFilterSpec.Criteria = RptFilterSpec.Criteria.And(x => x.DeliveryName == request.Driver);
            }
            if (request.CID != null)
            {
                RptFilterSpec.Criteria = RptFilterSpec.Criteria.And(x => x.CustomerId == request.CID);
            }
            if (request.Status.Length>0)
            {
                    RptFilterSpec.Criteria = RptFilterSpec.Criteria.And(x=> request.Status.Contains(x.DeliveryStatus));
            }
            if (!string.IsNullOrEmpty(request.sender_from_driver))
            {
                RptFilterSpec.Criteria = RptFilterSpec.Criteria.And(x => x.sender_from_driver == request.sender_from_driver);
            }
            if (request.From != null && request.To == null)
            {
                var dataa = await _unitOfWork.Repository<DeliveryRPT>().Entities
               .Specify(RptFilterSpec)
               .Select(expression).Where(x => x.PrintDate == request.From)
               .ToCustomPaginatedListAsync(request.PageNumber, request.PageSize);
                return dataa;
            }
            else if (request.From != null && request.To != null)
            {
               
                var dataa = await _unitOfWork.Repository<DeliveryRPT>().Entities
                    .Specify(RptFilterSpec)
                    .Select(expression).Where(x => x.PrintDate >= request.From && x.PrintDate <= request.To)
                    .ToCustomPaginatedListAsync(request.PageNumber, request.PageSize);
                return dataa;
            }

            var data = await _unitOfWork.Repository<DeliveryRPT>().Entities
               .Specify(RptFilterSpec)
               .Select(expression).OrderByDescending(x=>x.ActionTime)
               .ToCustomPaginatedListAsync(request.PageNumber, request.PageSize);
            return data;

        }
    }
}
