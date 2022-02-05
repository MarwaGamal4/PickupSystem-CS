using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Features.Customers.Queries.GetById;
using Pickup.Application.Features.Customers.Queries.GetTimeLine;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
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
        public Task<PaginatedResult<dtoCustomerInvoiceResponse>> GetInvoice(GetCustomerInvoicesCommand request);
        public Task<PaginatedResult<dtoPlanTransaction>> GetTransactions(GetCustomerTransactionsQuery request);
        public Task<IResult<List<dtoTimelineResponse>>> GetTimeline(GetTimeLineQuery request);
    }
}
