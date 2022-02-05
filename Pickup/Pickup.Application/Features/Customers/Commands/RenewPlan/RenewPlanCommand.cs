using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
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

namespace Pickup.Application.Features.Customers.Commands.RenewPlan
{
    public class RenewPlanCommand : IRequest<IResult<int>>
    {
        public Dto.dtoRenewPlanRequest Model { get; set; }
    }
    public class RenewPlanCommandHandler : IRequestHandler<RenewPlanCommand, IResult<int>>
    {
        private protected IUnitOfWork _unitOfWork;
        private protected ICustomerRepository _customerRepository;
        private protected IStringLocalizer<RenewPlanCommandHandler> _localizer;
        private readonly IUploadService _uploadService;

        public RenewPlanCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IStringLocalizer<RenewPlanCommandHandler> localizer, IUploadService uploadService)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _localizer = localizer;
            _uploadService = uploadService;
        }

        public async Task<IResult<int>> Handle(RenewPlanCommand command, CancellationToken cancellationToken)
        {
            var Plan = await _unitOfWork.Repository<CustomerPlan>().GetInclude(command.Model.PlanID, x => x.Invoices);
            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(Plan.CustomerId);
            var uploadRequest = command.Model.Invoice_Image;

            if (uploadRequest != null)
            {
                uploadRequest.UploadType = Enums.UploadType.Invoice;
                uploadRequest.FileName = $"INV-Renew-{Guid.NewGuid()}{uploadRequest.Extension}";
            }
            var inv = new Invoice()
            {
                invoiceType = Enums.InvoiceType.Renew,
                Internal_Num = command.Model.RefrenceId,
                TotalMealsCount = command.Model.MealsQty,
                MealsAmount = command.Model.MealsAmount,
                TotalSnacksCount = command.Model.SnacksQty,
                SnacksAmount = command.Model.SnacksAmount,
                CustomerPlanId = command.Model.PlanID,
                RemainingMeals = command.Model.MealsQty,
                RemainingSnacks = command.Model.SnacksQty,
                BranchId = command.Model.BranchId,
                CustomerId = Plan.CustomerId,
                Notes = command.Model.Notes
            };
            inv.MealPrice = inv.TotalMealsCount > 0 ? command.Model.MealsAmount / command.Model.MealsQty : decimal.Zero;
            inv.SnackPrice = inv.TotalSnacksCount > 0 ? command.Model.SnacksAmount / command.Model.SnacksQty : decimal.Zero;
            inv.InvoiceURL = _uploadService.UploadAsync(uploadRequest);
            Plan.RemainingMealsCount += command.Model.MealsQty;
            Plan.RemainingSnacksCount += command.Model.SnacksQty;
            await _unitOfWork.Repository<Invoice>().AddAsync(inv);
            await _unitOfWork.Repository<CustomerPlan>().UpdateAsync(Plan);
            await _unitOfWork.Commit(cancellationToken);
            return await Result<int>.SuccessAsync(inv.Id, _localizer["Renew Success!"]);
        }
    }
}
