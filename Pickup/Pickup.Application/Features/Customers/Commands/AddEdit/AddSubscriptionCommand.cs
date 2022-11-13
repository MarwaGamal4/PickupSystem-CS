using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Interfaces.Services;
using Pickup.Application.Models;
using Pickup.Shared.Constants.Application;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Commands.AddEdit
{
    public class AddSubscriptionCommand : IRequest<Result<int>>
    {
        public dtoSubscriptionRequest SubscriptionModel { get; set; }
    }
    public class AddSubscriptionHandler : IRequestHandler<AddSubscriptionCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddCustomerHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;

        public AddSubscriptionHandler(IMapper mapper, IStringLocalizer<AddCustomerHandler> localizer, IUnitOfWork unitOfWork, IUploadService uploadService)
        {
            _mapper = mapper;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _uploadService = uploadService;
        }

        public async Task<Result<int>> Handle(AddSubscriptionCommand command, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(command.SubscriptionModel.CustomerId);
            if (customer == null)
            {
                return await Result<int>.FailAsync(_localizer["No Customer With this ID"]);
            }
            if (command.SubscriptionModel.Invoice_Image == null)
            {
                return await Result<int>.FailAsync(_localizer["Please Provide The Invoice Image To Add"]);
            }
            var uploadRequest = command.SubscriptionModel.Invoice_Image;

            if (uploadRequest != null)
            {
                uploadRequest.UploadType = Enums.UploadType.Invoice;
                uploadRequest.FileName = $"INV-NewSub-{Guid.NewGuid()}{uploadRequest.Extension}";
            }

            var Plan = new CustomerPlan()
            {
                PlanName = command.SubscriptionModel.PlanName,
                RemainingMealsCount = command.SubscriptionModel.MealsQty,
                RemainingSnacksCount = command.SubscriptionModel.SnacksQty,
                customer = customer,
                CustomerId = customer.Id


            };
            var inv = new Invoice()
            {
                invoiceType = Enums.InvoiceType.New,
                Internal_Num = command.SubscriptionModel.RefrenceId,
                TotalMealsCount = command.SubscriptionModel.MealsQty,
                MealsAmount = command.SubscriptionModel.MealsAmount,
                TotalSnacksCount = command.SubscriptionModel.SnacksQty,
                SnacksAmount = command.SubscriptionModel.SnacksAmount
,
                CustomerPlanId = Plan.Id,
                RemainingMeals = command.SubscriptionModel.MealsQty,
                RemainingSnacks = command.SubscriptionModel.SnacksQty,
                BranchId = command.SubscriptionModel.BranchId,
                InvoiceURL = command.SubscriptionModel.Inv_Url
            };
            inv.MealPrice = inv.TotalMealsCount > 0 ? command.SubscriptionModel.MealsAmount / command.SubscriptionModel.MealsQty : decimal.Zero;
            inv.SnackPrice = inv.TotalSnacksCount > 0 ? command.SubscriptionModel.SnacksAmount / command.SubscriptionModel.SnacksQty : decimal.Zero;
            inv.customer = customer; inv.CustomerId = customer.Id;
            if (command.SubscriptionModel.Invoice_Image != null)
            {
                inv.InvoiceURL = _uploadService.UploadAsync(uploadRequest);
            }
            Plan.Invoices = new List<Invoice>();
            Plan.Invoices.Add(inv);

            await _unitOfWork.Repository<CustomerPlan>().AddAsync(Plan);
            await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCustomersCacheKey);
            return await Result<int>.SuccessAsync(Plan.Id, _localizer["Supscribed Success!"]);


        }
    }
}
