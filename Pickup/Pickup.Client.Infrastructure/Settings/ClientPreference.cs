﻿using Pickup.Client.Infrastructure.Managers;
using Pickup.Shared.Constants.Localization;
using Pickup.Shared.Settings;
using System.Linq;

namespace Pickup.Client.Infrastructure.Settings
{
    public record ClientPreference : IPreference
    {
        public bool IsDarkMode { get; set; }
        public bool IsRTL { get; set; }
        public bool IsDrawerOpen { get; set; }
        public string PrimaryColor { get; set; }
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";
    }
}