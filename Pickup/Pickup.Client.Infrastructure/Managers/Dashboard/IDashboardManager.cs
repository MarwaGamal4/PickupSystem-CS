using Pickup.Application.Features.Dashboards.Queries.GetData;
using Pickup.Shared.Wrapper;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}