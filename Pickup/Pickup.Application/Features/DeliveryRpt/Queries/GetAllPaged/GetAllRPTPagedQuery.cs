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
   public class GetAllRPTPagedQuery : IRequest<PaginatedResult<GetAllRPTPagedResponse>>
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
        public GetAllRPTPagedQuery(int pageNumber, int pageSize, string searchString, DateTime? from , DateTime? to , string branch , string driver , int? cid , int?[] status)
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
        }


    }
    public class GetAllRPTPagedQueryHandler : IRequestHandler<GetAllRPTPagedQuery, PaginatedResult<GetAllRPTPagedResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeliveryRptRepository _rptRepository;
        public GetAllRPTPagedQueryHandler(IUnitOfWork unitOfWork , IDeliveryRptRepository rptRepository)
        {
            _unitOfWork = unitOfWork;
            _rptRepository = rptRepository;
        }

        public async Task<PaginatedResult<GetAllRPTPagedResponse>> Handle(GetAllRPTPagedQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<DeliveryRPT, GetAllRPTPagedResponse>> expression = e => new GetAllRPTPagedResponse
            {
                Id = e.Id,
                DeliveryName = request.Driver?? e.DeliveryName,
                DeliveryNote = e.DeliveryNote,
                DeliveryStatus = e.DeliveryStatus,
                DriverLatitude = e.DriverLatitude,
                DriverLongitude = e.DriverLongitude,
                PrintDate = e.PrintDate,
                ActionTime = e.ActionTime,
                CustomerAddress = e.CustomerAddress,
                BranchName = request.Branch?? e.BranchName,
                CustomerId = request.CID?? e.CustomerId,
                CustomerName = e.CustomerName,
                CustomerPhone = e.CustomerPhone
            };
            var RptFilterSpec = new DeliveryRPTFilterSpecification(request.SearchString, request.Status);

            if (request.From != null && request.To == null)
            {
                //if (request.Branch != null && request.Driver == null)
                //{
                //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
                //        .Specify(RptFilterSpec)
                //        .Select(expression).Where(x => x.PrintDate == request.From && x.BranchName == request.Branch)
                //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                //    return dataBranch;
                //}
                //if (request.Branch != null && request.Driver != null)
                //{
                //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
                //        .Specify(RptFilterSpec)
                //        .Select(expression).Where(x => x.PrintDate == request.From && x.BranchName == request.Branch && x.DeliveryName == request.Driver)
                //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                //    return dataBranch;
                //}
                //if (request.CID != null)
                //{
                //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
                //        .Specify(RptFilterSpec)
                //        .Select(expression).Where(x => x.PrintDate == request.From && x.CustomerId == (int)request.CID)
                //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                //    return dataBranch;
                //}
                //if (request.Driver != null)
                //{
                //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
                //        .Specify(RptFilterSpec)
                //        .Select(expression).Where(x => x.PrintDate == request.From && x.DeliveryName == request.Driver)
                //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                //    return dataBranch;
                //}

                var dataa = await _unitOfWork.Repository<DeliveryRPT>().Entities
               .Specify(RptFilterSpec)
               .Select(expression).Where(x => x.PrintDate == request.From)
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return dataa;
            }
            else if (request.From != null && request.To != null)
            {
                //if (request.Branch != null && request.Driver == null)
                //{
                //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
                //        .Specify(RptFilterSpec)
                //        .Select(expression).Where(x => x.PrintDate >= request.From && x.PrintDate <= request.To && x.BranchName == request.Branch)
                //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                //    return dataBranch;
                //}
                //if (request.Branch != null && request.Driver != null)
                //{
                //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
                //        .Specify(RptFilterSpec)
                //        .Select(expression).Where(x => x.PrintDate >= request.From && x.PrintDate <= request.To && x.BranchName == request.Branch && x.DeliveryName == request.Driver)
                //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                //    return dataBranch;
                //}
                //if (request.CID != null)
                //{
                //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
                //        .Specify(RptFilterSpec)
                //        .Select(expression).Where(x => x.PrintDate >= request.From && x.PrintDate <= request.To && x.CustomerId == request.CID)
                //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                //    return dataBranch;
                //}
                //if (request.Driver != null)
                //{
                //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
                //        .Specify(RptFilterSpec)
                //        .Select(expression).Where(x => x.PrintDate >= request.From && x.PrintDate <= request.To && x.DeliveryName == request.Driver)
                //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                //    return dataBranch;
                //}

                var dataa = await _unitOfWork.Repository<DeliveryRPT>().Entities
                    .Specify(RptFilterSpec)
                    .Select(expression).Where(x => x.PrintDate >= request.From && x.PrintDate <= request.To)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return dataa;
            }

            //if (request.Branch != null && request.Driver == null)
            //{
            //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
            //        .Specify(RptFilterSpec)
            //        .Select(expression).Where(x => x.BranchName == request.Branch)
            //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //    return dataBranch;
            //}
            //if (request.Branch != null && request.Driver != null)
            //{
            //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
            //        .Specify(RptFilterSpec)
            //        .Select(expression).Where(x => x.BranchName == request.Branch && x.DeliveryName == request.Driver)
            //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //    return dataBranch;
            //}
            //if (request.CID != null)
            //{
            //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
            //        .Specify(RptFilterSpec)
            //        .Select(expression).Where(x => x.CustomerId == (int)request.CID)
            //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //    return dataBranch;
            //}
            //if (request.Driver != null)
            //{
            //    var dataBranch = await _unitOfWork.Repository<DeliveryRPT>().Entities
            //        .Specify(RptFilterSpec)
            //        .Select(expression).Where(x => x.DeliveryName == request.Driver)
            //        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //    return dataBranch;
            //}




            var data = await _unitOfWork.Repository<DeliveryRPT>().Entities
               .Specify(RptFilterSpec)
               .Select(expression)
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return data;

        }
    }
}
