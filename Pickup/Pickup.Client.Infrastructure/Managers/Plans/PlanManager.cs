using Blazored.LocalStorage;
using Pickup.Application.Features.Plans.Queries.Dto;
using Pickup.Client.Infrastructure.Extensions;
using Pickup.Client.Infrastructure.Settings;
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
        private readonly ILocalStorageService _localStorageService;

        public PlanManager(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;

        }

        public async Task<IResult<List<PlanDtoResponse>>> GetAllAsync()
        {
            var preference = await _localStorageService.GetItemAsync<ClientPreference>("clientPreference") ?? new ClientPreference();
            var response = await _httpClient.GetAsync(Routes.PlansEndpoints.GetAll(preference.LanguageCode));
            return await response.ToResult<List<PlanDtoResponse>>();
        }
    }
}
