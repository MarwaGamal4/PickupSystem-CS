using MudBlazor;
using Pickup.Shared.Managers;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Preferences
{
    public interface IClientPreferenceManager : IPreferenceManager
    {
        Task<MudTheme> GetCurrentThemeAsync();

        Task<bool> ToggleDarkModeAsync();

        Task ChangeLanguageAsync(string languageCode);
        Task ToggleDrawer(bool state);
    }
}