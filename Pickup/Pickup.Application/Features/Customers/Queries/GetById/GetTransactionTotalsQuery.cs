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
    public class GetTransactionTotalsQuery : IRequest<IResult<List<dtoPlanTransaction>>>
    {
        public dtoGetCustomeTransactionsRequest Model { get; set; }
    }
    internal class GetTransactionTotalsHandeller : IRequestHandler<GetTransactionTotalsQuery, IResult<List<dtoPlanTransaction>>>
    {
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly IStringLocalizer<GetCustomerInvoicesCommandHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        public Expression<Func<Transaction, bool>> Criteria = (x => x.Id != 0);
        public GetTransactionTotalsHandeller(UserManager<BlazorHeroUser> userManager, IStringLocalizer<GetCustomerInvoicesCommandHandler> localizer, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult<List<dtoPlanTransaction>>> Handle(GetTransactionTotalsQuery request, CancellationToken cancellationToken)
        {

            List<dtoPlanTransaction> MyList = new List<dtoPlanTransaction>();
            var Branches = await _unitOfWork.Repository<Branch>().GetAllAsync();
            var Users = _userManager.Users.AsEnumerable();
            List<Transaction> TransList = new List<Transaction>();
            if (request.Model.DateFrom != null)
            {
                Criteria = Criteria.And(x => x.CreatedOn >= (DateTime)request.Model.DateFrom);
            }
            if (request.Model.DateTo != null)
            {
                Criteria = Criteria.And(x => x.CreatedOn <= (DateTime)request.Model.DateTo);
            }
            if (request.Model.BranchID != null)
            {
                Criteria = Criteria.And(x => x.BranchId == request.Model.BranchID);
            }
            if (request.Model.InvoiceId != null)
            {
                Criteria = Criteria.And(x => x.InvoiceID == request.Model.InvoiceId);
            }
            if (request.Model.CustomerID != null)
            {
                Criteria = Criteria.And(x => x.CustomerId == request.Model.CustomerID);
            }
            if (request.Model.OwnerBranchID != null)
            {
                Criteria = Criteria.And(x => x.CreditBranchId == request.Model.OwnerBranchID);
            }
            if (request.Model.PlanID != null)
            {
                Criteria = Criteria.And(x => x.CustomerPlanId == request.Model.PlanID);
            }

            var dataa = await _unitOfWork.Repository<Transaction>().Entities.Include(x => x.invoice)
                .Include(x => x.branch).Include(x => x.CreditBranch)
                .Where(Criteria)
                .Join(
                _userManager.Users,
                a => a.CreatedBy,
                b => b.Id, (a, b) => new
                {
                    FullName = $"{b.FirstName} {b.LastName}",
                    x = a
                }
                ).OrderByDescending(x => x.x.CreatedOn).
                Select(x => new dtoPlanTransaction
                {
                    CustomerID = x.x.CustomerId,
                    InvoiceID = x.x.InvoiceID,
                    Inv_Url = x.x.Inv_url,
                    MealsAmount = x.x.MealCount * x.x.invoice.MealPrice,
                    MealsCount = x.x.MealCount,
                    OwnerBranchID = x.x.CreditBranchId,
                    OwnerBranchName = x.x.CreditBranch.BranchName,
                    PlanID = x.x.CustomerPlanId,
                    ServedBranchID = x.x.BranchId,
                    ServedBranchName = x.x.branch.BranchName,
                    SnacksAmount = x.x.SnackCount * x.x.invoice.SnackPrice,
                    SnacksCount = x.x.SnackCount,
                    TotalTransactionValue = x.x.CreditValue,
                    TransactionDate = x.x.CreatedOn,
                    TransactionID = x.x.Id,
                    UserName = x.FullName

                }).ToListAsync();
            return await Result<List<dtoPlanTransaction>>.SuccessAsync(dataa);
        }
    }
}
