using AutoMapper;
using Pickup.Application.Features.Customers.Commands.AddEdit;
using Pickup.Application.Features.Customers.Commands.AddTransaction;
using Pickup.Application.Features.Customers.Commands.RenewPlan;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Features.Customers.Queries.GetById;
using Pickup.Application.Features.Customers.Queries.GetTimeLine;
using Pickup.Application.Interfaces.Services;
using Pickup.Client.Infrastructure.Extensions;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Customer
{
    public class CustomerManager : ICustomerManager
    {

        private readonly HttpClient _httpClient;
        private readonly IMapper _Mapper;

        public CustomerManager(HttpClient httpClient, IMapper Mapper)
        {
            _httpClient = httpClient;

            _Mapper = Mapper;
        }

        public async Task<IResult<int>> AddSubscription(dtoSubscriptionRequest request)
        {
            AddSubscriptionCommand cmd = new AddSubscriptionCommand();
            cmd.SubscriptionModel = request;
            var response = await _httpClient.PostAsJsonAsync(Routes.CustomersEndPoint.AddSubscription, cmd);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddTransaction(dtoAddTransactionRequest request)
        {
            AddTransactionCommand cmd = new AddTransactionCommand();
            cmd.Model = request;
            var response = await _httpClient.PostAsJsonAsync(Routes.CustomersEndPoint.AddTransaction, cmd);
            return await response.ToResult<int>();
        }

        public async Task<IResult<dtoCustomerRsponse>> GetCustomer(GetCutomerByIdQuery request)
        {
            var requestt = await _httpClient.PostAsJsonAsync(Routes.CustomersEndPoint.GetCustomer, request);
            return await requestt.ToResult<dtoCustomerRsponse>();
        }

        public async Task<PaginatedResult<dtoCustomerInvoiceResponse>> GetInvoice(GetCustomerInvoicesCommand request)
        {
            var requestt = await _httpClient.PostAsJsonAsync(Routes.CustomersEndPoint.GetInvoice, request);
            return await requestt.ToPaginatedResult<dtoCustomerInvoiceResponse>();
        }

        public async Task<IResult<List<dtoTimelineResponse>>> GetTimeline(GetTimeLineQuery request)
        {
            var requestt = await _httpClient.PostAsJsonAsync(Routes.CustomersEndPoint.GetTimeline, request);
            return await requestt.ToResult<List<dtoTimelineResponse>>();
        }

        public async Task<PaginatedResult<dtoPlanTransaction>> GetTransactions(GetCustomerTransactionsQuery request)
        {
            var requestt = await _httpClient.PostAsJsonAsync(Routes.CustomersEndPoint.GetTransaction, request);
            return await requestt.ToPaginatedResult<dtoPlanTransaction>();
        }

        public async Task<IResult<int>> RenewSubscription(dtoRenewPlanRequest request)
        {
            RenewPlanCommand cmd = new RenewPlanCommand();
            cmd.Model = request;
            var response = await _httpClient.PostAsJsonAsync(Routes.CustomersEndPoint.RenewSubscription, cmd);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> SaveAsync(dtoCustomerRequest request)
        {
            AddCustomerCommand cmd = new AddCustomerCommand();
            request.Id = 0;
            cmd.CustomerRequest = request;
            // var req = _Mapper.Map<AddCustomerCommand>(request);
            var response = await _httpClient.PostAsJsonAsync(Routes.CustomersEndPoint.AddNew, cmd);
            return await response.ToResult<int>();
        }
    }
}
