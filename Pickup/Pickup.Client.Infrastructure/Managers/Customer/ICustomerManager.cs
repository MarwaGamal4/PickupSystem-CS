using Pickup.Application.Features.Customers.Commands.AddEdit;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Features.Customers.Queries.GetById;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Customer
{
    public interface ICustomerManager : IManager
    {
        public Task<IResult<int>> SaveAsync(dtoCustomerRequest request);
        public Task<IResult<dtoCustomerRsponse>> GetCustomer(GetCutomerByIdQuery request);
        public Task<IResult<int>> AddSubscription(dtoSubscriptionRequest request);
        public Task<IResult<int>> RenewSubscription(dtoRenewPlanRequest request);
        public Task<IResult<int>> AddTransaction(dtoAddTransactionRequest request);
    }
}
