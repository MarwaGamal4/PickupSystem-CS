using Pickup.Client.Infrastructure.Extensions;
using Pickup.Client.Infrastructure.SiteModels.Requests;
using Pickup.Client.Infrastructure.SiteModels.Response;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.ManagerDashboard
{
    public class managerDashboardManager : ImanagerDashboardManager
    {
        private readonly HttpClient _httpClient;

        public managerDashboardManager(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://lowcalories.ae:51");

            //_httpClient.BaseAddress = new Uri("https://localhost:5001");
            //_httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
            //_httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "no-cors");
            //_httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");


        }

        public async Task<List<AgentsResponse>> GetAgents()
        {
            var response = await _httpClient.GetFromJsonAsync<List<AgentsResponse>>(Routes.SiteRoutes.ManagerEndpoints.GetAgents);
            return response;
        }

        public async Task<List<BranchesResponse>> GetBranches()
        {
            var response = await _httpClient.GetFromJsonAsync<List<BranchesResponse>>(Routes.SiteRoutes.ManagerEndpoints.GetBranches);
            return response;
        }

        public async Task<List<EmaritsResponse>> GetEmarits()
        {
            var response = await _httpClient.GetFromJsonAsync<List<EmaritsResponse>>(Routes.SiteRoutes.ManagerEndpoints.GetEmarits);
            return response;
        }

        public async Task<List<string>> GetPayments()
        {
            var response = await _httpClient.GetFromJsonAsync<List<string>>(Routes.SiteRoutes.ManagerEndpoints.GetPaymentMethods);
            return response;
        }

        public async Task<List<ProgramsResponse>> GetPrograms()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProgramsResponse>>(Routes.SiteRoutes.ManagerEndpoints.GetPrograms);

            return response;
        }

        public async Task<PaginatedResult<SubscriptionsResponse>> GetSubscriptions(ManagerRequest request, int PageSize, int PageNumber)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.SiteRoutes.ManagerEndpoints.GetSubscriptions(PageSize, PageNumber), request);
            return await response.ToPaginatedResult<SubscriptionsResponse>();
        }
    }
}
