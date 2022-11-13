using MediatR;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Interfaces.Services;
using Pickup.Application.Models;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Commands.AddTransaction
{
    public class AddTransactionCommand : IRequest<IResult<int>>
    {
        public dtoAddTransactionRequest Model { get; set; }
    }
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, IResult<int>>
    {

        private protected IUnitOfWork _unitOfWork;
        private protected IStringLocalizer<AddTransactionCommandHandler> _localizer;
        private readonly IUploadService _uploadService;

        public AddTransactionCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<AddTransactionCommandHandler> localizer, IUploadService uploadService)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
            _uploadService = uploadService;
        }

        public async Task<IResult<int>> Handle(AddTransactionCommand command, CancellationToken cancellationToken)
        {
            var plan = await _unitOfWork.Repository<CustomerPlan>().GetInclude(command.Model.PlanID, x => x.Invoices);
            if (plan.RemainingMealsCount < command.Model.MealsCount)
            {
                if (plan.RemainingMealsCount > 0)
                {
                    return await Result<int>.FailAsync(_localizer[$"Maxmum Meals On Hand {0} Meal", plan.RemainingMealsCount.ToString()]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["The Customer Has Not Enough Credit Meals On This Plan"]);
                }
            }
            if (plan.RemainingSnacksCount < command.Model.SnacksCount)
            {
                if (plan.RemainingSnacksCount > 0)
                {
                    return await Result<int>.FailAsync(_localizer[$"Maxmum Snacks On Hand {0} Snack", plan.RemainingSnacksCount.ToString()]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["The Customer Has Not Enough Credit Snacks On This Plan"]);
                }
            }


            List<Transaction> TList = new List<Transaction>();
            var invoices = plan.Invoices.Where(x => x.RemainingMeals > 0 || x.RemainingSnacks > 0).ToList();
            int dMeals = 0;
            int dSnacks = 0;
            int pointer = 0;
            while (dMeals != command.Model.MealsCount || dSnacks != command.Model.SnacksCount)
            {
                Transaction trans = new Transaction();
                var invoice = await _unitOfWork.Repository<Invoice>().GetByIdAsync(invoices[pointer].Id);
                var uploadRequest = command.Model.Invoice_Image;

                if (uploadRequest != null)
                {
                    uploadRequest.UploadType = Enums.UploadType.internal_Inv;
                    uploadRequest.FileName = $"INV-Trans-{Guid.NewGuid()}{uploadRequest.Extension}";
                }
                int ddMeal = 0;
                int ddSnack = 0;
                decimal dValue = decimal.Zero;
                if (invoice.RemainingMeals - (command.Model.MealsCount - dMeals) >= 0 && dMeals != command.Model.MealsCount)
                {
                    invoice.RemainingMeals -= (command.Model.MealsCount - dMeals);
                    ddMeal = (command.Model.MealsCount - dMeals);
                    dMeals += (command.Model.MealsCount - dMeals);
                    dValue += (invoice.MealPrice * ddMeal);
                }
                else
                {
                    if (invoice.RemainingMeals - command.Model.MealsCount < 0 && dMeals != command.Model.MealsCount)
                    {
                        ddMeal = invoice.RemainingMeals;
                        invoice.RemainingMeals -= ddMeal;
                        dValue += (invoice.MealPrice * ddMeal);
                        dMeals += ddMeal;
                    }
                }
                if (invoice.RemainingSnacks - (command.Model.SnacksCount - dSnacks) >= 0 && dSnacks != command.Model.SnacksCount)
                {
                    invoice.RemainingSnacks -= (command.Model.SnacksCount - dSnacks);
                    ddSnack = (command.Model.SnacksCount - dSnacks);
                    dSnacks += (command.Model.SnacksCount - dSnacks);
                    dValue += (invoice.SnackPrice * ddSnack);
                }
                else
                {
                    if (invoice.RemainingSnacks - command.Model.SnacksCount < 0 && dSnacks != command.Model.SnacksCount)
                    {
                        ddSnack = invoice.RemainingSnacks;
                        invoice.RemainingSnacks -= ddSnack;
                        dValue += (invoice.SnackPrice * ddSnack);
                        dSnacks += ddSnack;
                    }
                }
                trans.MealCount = ddMeal;
                trans.SnackCount = ddSnack;
                trans.CreditValue = dValue;
                trans.BranchId = command.Model.BranchId;
                trans.CreditBranchId = invoice.BranchId;
                trans.CustomerId = plan.CustomerId;
                trans.CustomerPlanId = plan.Id;
                if (command.Model.Invoice_Image != null)
                {
                  trans.Inv_url = _uploadService.UploadAsync(uploadRequest);
                }
                trans.InvoiceID = invoice.Id;
                TList.Add(trans);
                await _unitOfWork.Repository<Invoice>().UpdateAsync(invoice);
                pointer++;
            }
            plan.RemainingMealsCount -= command.Model.MealsCount;
            plan.RemainingSnacksCount -= command.Model.SnacksCount;
            await _unitOfWork.Repository<Transaction>().AddRangeAsync(TList);
            await _unitOfWork.Repository<CustomerPlan>().UpdateAsync(plan);
            await _unitOfWork.Commit(cancellationToken);
            return await Result<int>.SuccessAsync(plan.Id, _localizer["Transaction Complited successfuly!"]);
        }

    }
}
