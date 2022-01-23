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
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly IStringLocalizer<GetCustomerInvoicesCommandHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<PaginatedResult<dtoCustomerInvoiceResponse>> Handle(GetCustomerInvoicesCommand request, CancellationToken cancellationToken)
        {
            var productFilterSpec = new InvoiceFilterSpecification(request.SearchString);
            List<dtoCustomerInvoiceResponse> MyList = new List<dtoCustomerInvoiceResponse>();
            var Branches = await _unitOfWork.Repository<Branch>().GetAllAsync();
            var Users = _userManager.Users.AsEnumerable();
            IEnumerable<Invoice> invList = null;

            if (request.Model.CustomerID != null)
            {
                invList = _unitOfWork.Repository<Invoice>().Entities.Include(x => x.customerPlan).Include(x => x.Transactions).Where(x => x.CustomerId == request.Model.CustomerID).AsEnumerable();
            }
            if (request.Model.PlanID != null)
            {
                invList = _unitOfWork.Repository<Invoice>().Entities.Include(x => x.customerPlan).Include(x => x.Transactions).Where(x => x.CustomerPlanId == request.Model.PlanID).AsEnumerable();

            }
            if (request.Model.BranchID != null)
            {
                invList = _unitOfWork.Repository<Invoice>().Entities.Include(x => x.customerPlan).Include(x => x.Transactions).Where(x => x.BranchId == request.Model.BranchID).AsEnumerable();

            }
            if (invList is null)
            {
                return null;
            }

            foreach (var item in invList)
            {
                dtoCustomerInvoiceResponse record = new dtoCustomerInvoiceResponse();
                record.InvoiceID = item.Id;
                record.PlanID = item.CustomerPlanId;
                record.BranchID = item.BranchId;
                record.BranchName = Branches.FirstOrDefault(x => x.Id == item.BranchId).BranchName;
                record.CustomerID = item.CustomerId;
                record.Invoice_Url = item.InvoiceURL;
                record.MealsAmount = item.MealsAmount;
                record.MealsCount = item.TotalMealsCount;
                record.SnacksAmount = item.SnacksAmount;
                record.SnacksCount = item.TotalSnacksCount;
                record.TotalValue = item.SnacksAmount + item.MealsAmount;
                record.PlanName = item.customerPlan.PlanName;
                record.Transactions = new List<dtoPlanTransaction>();
                foreach (var transaction in item.Transactions)
                {
                    dtoPlanTransaction trans = new dtoPlanTransaction();
                    trans.CustomerID = transaction.Id;
                    trans.InvoiceID = transaction.InvoiceID;
                    trans.MealsAmount = transaction.MealCount * item.MealPrice;
                    trans.SnacksAmount = transaction.SnackCount * item.SnackPrice;
                    trans.MealsCount = transaction.MealCount;
                    trans.SnacksCount = transaction.SnackCount;
                    trans.OwnerBranchID = transaction.CreditBranchId;
                    trans.OwnerBranchName = Branches.FirstOrDefault(x => x.Id == transaction.CreditBranchId).BranchName;
                    trans.PlanID = transaction.CustomerPlanId;
                    trans.ServedBranchID = transaction.BranchId;
                    trans.ServedBranchName = Branches.FirstOrDefault(x => x.Id == transaction.BranchId).BranchName;
                    trans.TotalTransactionValue = transaction.CreditValue;
                    trans.TransactionDate = transaction.CreatedOn;
                    trans.UserName = Users.FirstOrDefault(x => x.Id == transaction.CreatedBy).FirstName;
                    trans.Inv_Url = transaction.Inv_url;
                    record.Transactions.Add(trans);
                }
                MyList.Add(record);
            }
            var data = MyList.AsQueryable().ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return await data;
        }
    }
}
