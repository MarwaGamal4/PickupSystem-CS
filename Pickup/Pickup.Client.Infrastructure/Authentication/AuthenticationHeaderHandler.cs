﻿using Blazored.LocalStorage;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Authentication
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        private readonly ILocalStorageService localStorage;

        public AuthenticationHeaderHandler(ILocalStorageService localStorage)
            => this.localStorage = localStorage;

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Add("Branch", "3");
            if (request.Headers.Authorization?.Scheme != "Bearer")
            {

                var savedToken = await this.localStorage.GetItemAsync<string>("authToken");

                if (!string.IsNullOrWhiteSpace(savedToken))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}