using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Application.Models.Identity;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Queries.GetById
{
    public class GetCustomerTransactionsQuery : IRequest<IResult<List<dtoPlanTransaction>>>
    {
        dtoGetCustomeTransactionsRequest Model { get; set; }

    }
    public class GetCustomerTransactionsQueryHandler : IRequestHandler<GetCustomerTransactionsQuery, IResult<List<dtoPlanTransaction>>>
    {
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly IStringLocalizer<GetCustomerInvoicesCommandHandler> _localizer;
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerTransactionsQueryHandler(UserManager<BlazorHeroUser> userManager, IStringLocalizer<GetCustomerInvoicesCommandHandler> localizer, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult<List<dtoPlanTransaction>>> Handle(GetCustomerTransactionsQuery request, CancellationToken cancellationToken)
        {
            List<dtoPlanTransaction> MyList = new List<dtoPlanTransaction>();
            var Branches = await _unitOfWork.Repository<Branch>().GetAllAsync();
            var Users = _userManager.Users.AsEnumerable();
            throw new NotImplementedException();
        }
    }
}
