﻿using Blazored.LocalStorage;
using MudBlazor;
using Pickup.Client.Infrastructure.Settings;
using Pickup.Shared.Settings;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Preferences
{
    public class ClientPreferenceManager : IClientPreferenceManager
    {
        private readonly ILocalStorageService _localStorageService;

        public ClientPreferenceManager(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<bool> ToggleDarkModeAsync()
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.IsDarkMode = !preference.IsDarkMode;
                await SetPreference(preference);
                return !preference.IsDarkMode;
            }

            return false;
        }

        public async Task ChangeLanguageAsync(string languageCode)
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.LanguageCode = languageCode;
                if (languageCode == "ar-AR")
                {
                    preference.IsRTL = true;
                }
                else
                {
                    preference.IsRTL = false;
                }
                await SetPreference(preference);
            }
        }

        public async Task<MudTheme> GetCurrentThemeAsync()
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                if (preference.IsDarkMode == true) return BlazorHeroTheme.DarkTheme;
            }
            return BlazorHeroTheme.DefaultTheme;
        }

        public async Task<IPreference> GetPreference()
        {
            return await _localStorageService.GetItemAsync<ClientPreference>("clientPreference") ?? new ClientPreference();
        }

        public async Task SetPreference(IPreference preference)
        {
            await _localStorageService.SetItemAsync("clientPreference", preference as ClientPreference);
        }

        public async Task ToggleDrawer(bool state)
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.IsDrawerOpen = state;
                await SetPreference(preference);
            }
        }
    }
}
