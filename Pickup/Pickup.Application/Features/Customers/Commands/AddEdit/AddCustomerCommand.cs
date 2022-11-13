using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Interfaces.Services;
using Pickup.Application.Models;
using Pickup.Application.Requests;
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
    public class AddCustomerCommand : IRequest<Result<int>>
    {
        public dtoCustomerRequest CustomerRequest { get; set; }
    }
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddCustomerHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly ICustomerRepository _CustomerRepository;

        public AddCustomerHandler(IMapper mapper, IStringLocalizer<AddCustomerHandler> localizer, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IUploadService uploadService)
        {
            _mapper = mapper;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _CustomerRepository = customerRepository;
            _uploadService = uploadService;
        }

        public async Task<Result<int>> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
        {

            if (command.CustomerRequest.Id == 0)
            {
                var Exist = await _CustomerRepository.IsCustomerExist(command.CustomerRequest.Phone1);
                var Exis2 = await _CustomerRepository.IsCustomerExist(command.CustomerRequest.Phone2);
                if (Exist || Exis2)
                {
                    return await Result<int>.FailAsync(_localizer["Customer With This Phone Number is Already Exist"]);
                }
                var uploadRequest = command.CustomerRequest.Invoice_Image;

                if (uploadRequest != null)
                {
                    uploadRequest.UploadType = Enums.UploadType.Invoice;
                    uploadRequest.FileName = $"INV-New-{Guid.NewGuid()}{uploadRequest.Extension}";
                }
                Customer cust = new Customer()
                {
                    Name = command.CustomerRequest.Name,
                    Phone1 = command.CustomerRequest.Phone1,
                    BranchId = command.CustomerRequest.BranchId,
                    Phone2 = command.CustomerRequest.Phone2,
                    Notes = command.CustomerRequest.Notes,

                };
                var Plan = new CustomerPlan()
                {
                    PlanName = command.CustomerRequest.PlanName,
                    RemainingMealsCount = command.CustomerRequest.MealsQty,
                    RemainingSnacksCount = command.CustomerRequest.SnacksQty,
                    customer = cust,
                    CustomerId = cust.Id


                };
                var inv = new Invoice()
                {
                    invoiceType = Enums.InvoiceType.New,
                    Internal_Num = command.CustomerRequest.RefrenceId,
                    TotalMealsCount = command.CustomerRequest.MealsQty,
                    MealsAmount = command.CustomerRequest.MealsAmount,
                    TotalSnacksCount = command.CustomerRequest.SnacksQty,
                    SnacksAmount = command.CustomerRequest.SnacksAmount
    ,
                    CustomerPlanId = Plan.Id,
                    RemainingMeals = command.CustomerRequest.MealsQty,
                    RemainingSnacks = command.CustomerRequest.SnacksQty,
                    BranchId = command.CustomerRequest.BranchId,
                    InvoiceURL = command.CustomerRequest.Inv_Url
                };
                inv.MealPrice = inv.TotalMealsCount > 0 ? command.CustomerRequest.MealsAmount / command.CustomerRequest.MealsQty : decimal.Zero;
                inv.SnackPrice = inv.TotalSnacksCount > 0 ? command.CustomerRequest.SnacksAmount / command.CustomerRequest.SnacksQty : decimal.Zero;
                inv.customer = cust; inv.CustomerId = cust.Id;
                if (command.CustomerRequest.Invoice_Image != null)
                {
                 inv.InvoiceURL = _uploadService.UploadAsync(uploadRequest);
                }
                Plan.Invoices = new List<Invoice>();
                Plan.Invoices.Add(inv);
                cust.CustomerPlans = new List<CustomerPlan>();
                cust.CustomerPlans.Add(Plan);
                await _unitOfWork.Repository<Customer>().AddAsync(cust);
                await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCustomersCacheKey);

                return await Result<int>.SuccessAsync(cust.Id, _localizer["Customer Added And Saved"]);

            }
            else
            {
                var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync((int)command.CustomerRequest.Id);
                if (customer != null)
                {
                    if (customer.Phone1 != command.CustomerRequest.Phone1 && customer.Phone2 != command.CustomerRequest.Phone2)
                    {
                        var Exist = await _CustomerRepository.IsCustomerExist(command.CustomerRequest.Phone1);
                        var Exis2 = await _CustomerRepository.IsCustomerExist(command.CustomerRequest.Phone2);
                        if (Exist || Exis2)
                        {
                            return await Result<int>.FailAsync(_localizer["Customer With This Phone Number is Already Exist"]);
                        }
                    }
                    if (customer.Phone1 != command.CustomerRequest.Phone1)
                    {
                        var Exist = await _CustomerRepository.IsCustomerExist(command.CustomerRequest.Phone1);
                        if (Exist)
                        {
                            return await Result<int>.FailAsync(_localizer["Customer With This Phone Number is Already Exist"]);
                        }
                    }
                    if (customer.Phone2 != command.CustomerRequest.Phone2)
                    {
                        var Exis2 = await _CustomerRepository.IsCustomerExist(command.CustomerRequest.Phone2);
                        if (Exis2)
                        {
                            return await Result<int>.FailAsync(_localizer["Customer With This Phone Number is Already Exist"]);
                        }
                    }
                    await _unitOfWork.Repository<Customer>().UpdateAsync(customer);
                    await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCustomersCacheKey);
                    return await Result<int>.SuccessAsync(customer.Id, _localizer["Customer Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Customer Not Found!"]);
                }
            }
        }
    }
}
