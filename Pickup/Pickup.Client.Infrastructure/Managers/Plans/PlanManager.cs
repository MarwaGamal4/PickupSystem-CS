using Pickup.Application.Features.Plans.Queries.Dto;
using Pickup.Client.Infrastructure.Extensions;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Plans
{
    public class PlanManager : IPlanManager
    {
        private readonly HttpClient _httpClient;

        public PlanManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<List<PlanDtoResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.PlansEndpoints.GetAll);
            return await response.ToResult<List<PlanDtoResponse>>();
        }
    }
}
