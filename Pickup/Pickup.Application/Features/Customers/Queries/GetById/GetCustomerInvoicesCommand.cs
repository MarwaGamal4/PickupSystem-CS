using LinqKit;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pickup.Application.Extensions;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Application.Models.Identity;
using Pickup.Application.Specifications;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Queries.GetById
{
    public class GetCustomerInvoicesCommand : IRequest<PaginatedResult<dtoCustomerInvoiceResponse>>
    {
        public dtoGetCustomeInvoicesRequest Model { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }

        public GetCustomerInvoicesCommand(int pageNumber, int pageSize, string searchString)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
        }
    }
    public class GetCustomerInvoicesCommandHandler : IRequestHandler<GetCustomerInvoicesCommand, PaginatedResult<dtoCustomerInvoiceResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;
        public Expression<Func<Invoice, bool>> Criteria = (x => x.Id != 0);

        public GetCustomerInvoicesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<dtoCustomerInvoiceResponse>> Handle(GetCustomerInvoicesCommand request, CancellationToken cancellationToken)
        {

            if (request.Model.CustomerID != null)
            {
                Criteria = Criteria.And(x => x.CustomerId == request.Model.CustomerID);
            }
            if (request.Model.PlanID != null)
            {
                Criteria = Criteria.And(x => x.CustomerPlanId == request.Model.PlanID);
            }
            if (request.Model.BranchID != null)
            {
                Criteria = Criteria.And(x => x.BranchId == request.Model.BranchID);
            }
            if (request.Model.DateFrom != null)
            {
                Criteria = Criteria.And(x => x.CreatedOn >= request.Model.DateFrom);
            }
            if (request.Model.DateTo != null)
            {
                Criteria = Criteria.And(x => x.CreatedOn <= request.Model.DateTo);
            }
            return await _unitOfWork.Repository<Invoice>().Entities.Include(x => x.branch).Include(x => x.customerPlan).Where(Criteria).Select
                (
                x =>
                    new dtoCustomerInvoiceResponse
                    {
                        InvoiceID = x.Id,
                        PlanID = x.CustomerPlanId,
                        BranchID = x.BranchId,
                        BranchName = x.branch.BranchName,
                        CustomerID = x.CustomerId,
                        MealsAmount = x.MealsAmount,
                        MealsCount = x.TotalMealsCount,
                        SnacksAmount = x.SnacksAmount,
                        PlanName = x.customerPlan.PlanName,
                        SnacksCount = x.TotalSnacksCount,
                        TotalValue = x.MealsAmount + x.SnacksAmount,
                        Invoice_Url = x.InvoiceURL
                    }
                ).ToPaginatedListAsync(request.PageNumber, request.PageSize);


        }
    }
}
