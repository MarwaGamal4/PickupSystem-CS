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


namespace Pickup.Application.Features.Customers.Queries.GetTimeLine
{
    public class GetTimeLineQuery : IRequest<IResult<List<dtoTimelineResponse>>>
    {
        public dtoGetCustomeTransactionsRequest Model { get; set; }
    }
    public class GrtTimelineQueryHandler : IRequestHandler<GetTimeLineQuery, IResult<List<dtoTimelineResponse>>>
    {
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly IStringLocalizer<GrtTimelineQueryHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        public Expression<Func<Transaction, bool>> TransactionCriteria = (x => x.Id != 0);
        public Expression<Func<Invoice, bool>> InvoiceCriteria = (x => x.Id != 0);

        public GrtTimelineQueryHandler(UserManager<BlazorHeroUser> userManager, IStringLocalizer<GrtTimelineQueryHandler> localizer, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult<List<dtoTimelineResponse>>> Handle(GetTimeLineQuery request, CancellationToken cancellationToken)
        {

            List<dtoTimelineResponse> MyList = new List<dtoTimelineResponse>();
            var Branches = await _unitOfWork.Repository<Branch>().GetAllAsync();
            var Users = _userManager.Users.AsEnumerable();
            List<Transaction> TransList = new List<Transaction>();
            if (request.Model.DateFrom != null)
            {
                TransactionCriteria = TransactionCriteria.And(x => x.CreatedOn >= (DateTime)request.Model.DateFrom);
                InvoiceCriteria = InvoiceCriteria.And(x => x.CreatedOn >= (DateTime)request.Model.DateFrom);
            }
            if (request.Model.DateTo != null)
            {
                TransactionCriteria = TransactionCriteria.And(x => x.CreatedOn <= (DateTime)request.Model.DateTo);
                InvoiceCriteria = InvoiceCriteria.And(x => x.CreatedOn <= (DateTime)request.Model.DateTo);
            }
            if (request.Model.BranchID != null)
            {
                TransactionCriteria = TransactionCriteria.And(x => x.BranchId == request.Model.BranchID);
                // InvoiceCriteria = InvoiceCriteria.And(x => x.BranchId == request.Model.BranchID);
            }
            if (request.Model.CustomerID != null)
            {
                TransactionCriteria = TransactionCriteria.And(x => x.CustomerId == request.Model.CustomerID);
                InvoiceCriteria = InvoiceCriteria.And(x => x.CustomerId == request.Model.CustomerID);
            }
            if (request.Model.OwnerBranchID != null)
            {
                TransactionCriteria = TransactionCriteria.And(x => x.CreditBranchId == request.Model.OwnerBranchID);
                InvoiceCriteria = InvoiceCriteria.And(x => x.BranchId == request.Model.BranchID);
            }
            if (request.Model.PlanID != null)
            {
                TransactionCriteria = TransactionCriteria.And(x => x.CustomerPlanId == request.Model.PlanID);
                InvoiceCriteria = InvoiceCriteria.And(x => x.CustomerPlanId == request.Model.PlanID);
            }

            // var dataa = await _unitOfWork.Repository<Transaction>().Entities.Include(x => x.invoice).Where(TransactionCriteria).ToListAsync();
            var Invoices = await _unitOfWork.Repository<Invoice>().Entities.Include(x => x.branch).Include(x => x.Transactions).Where(InvoiceCriteria).ToListAsync();



            foreach (var invoice in Invoices)
            {
                foreach (var item in invoice.Transactions)
                {
                    dtoTimelineResponse tt = new dtoTimelineResponse();
                    tt.CustomerID = item.CustomerId;
                    tt.InvoiceID = item.InvoiceID;
                    tt.Inv_Url = item.Inv_url;
                    tt.MealsAmount = item.MealCount * item.invoice.MealPrice;
                    tt.MealsCount = item.MealCount;
                    tt.OwnerBranchID = item.CreditBranchId;
                    tt.OwnerBranchName = Branches.FirstOrDefault(x => x.Id == item.CreditBranchId).BranchName;
                    tt.PlanID = item.CustomerPlanId;
                    tt.ServedBranchID = item.BranchId;
                    tt.ServedBranchName = Branches.FirstOrDefault(x => x.Id == item.BranchId).BranchName;
                    tt.SnacksAmount = item.SnackCount * item.invoice.SnackPrice;
                    tt.SnacksCount = item.SnackCount;
                    tt.TotalTransactionValue = item.CreditValue;
                    tt.TransactionDate = item.CreatedOn;
                    tt.TransactionID = item.Id;
                    tt.UserName = $"{Users.FirstOrDefault(x => x.Id == item.CreatedBy).FirstName} {Users.FirstOrDefault(x => x.Id == item.CreatedBy).LastName}";
                    tt.TransactionType = TransType.Transaction;
                    MyList.Add(tt);
                }
                dtoTimelineResponse t = new dtoTimelineResponse();
                t.CustomerID = invoice.CustomerId;
                t.InvoiceID = invoice.Id;
                t.Inv_Url = invoice.InvoiceURL;
                t.MealsAmount = invoice.MealsAmount;
                t.MealsCount = invoice.TotalMealsCount;
                t.OwnerBranchID = invoice.BranchId;
                t.OwnerBranchName = invoice.branch.BranchName;
                t.PlanID = invoice.CustomerPlanId;
                t.ServedBranchID = invoice.BranchId;
                t.ServedBranchName = invoice.branch.BranchName;
                t.SnacksAmount = invoice.SnacksAmount;
                t.SnacksCount = invoice.TotalSnacksCount;
                t.TotalTransactionValue = invoice.SnacksAmount + invoice.MealsAmount;
                t.TransactionDate = invoice.CreatedOn;
                t.TransactionID = invoice.Id;
                t.UserName = $"{Users.FirstOrDefault(x => x.Id == invoice.CreatedBy).FirstName} {Users.FirstOrDefault(x => x.Id == invoice.CreatedBy).LastName}";
                t.TransactionType = TransType.Invoice;
                t.invoiceType = invoice.invoiceType;
                MyList.Add(t);
            }
            foreach (var item in Invoices)
            {

            }

            return await Result<List<dtoTimelineResponse>>.SuccessAsync(MyList.OrderByDescending(x => x.TransactionDate).ToList());
        }
    }
}
