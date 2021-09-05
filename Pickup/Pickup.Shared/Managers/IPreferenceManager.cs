using Pickup.Shared.Settings;
using System.Threading.Tasks;

namespace Pickup.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();
    }
}
