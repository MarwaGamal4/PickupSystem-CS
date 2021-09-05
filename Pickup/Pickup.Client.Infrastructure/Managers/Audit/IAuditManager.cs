using Pickup.Application.Responses.Audit;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Audit
{
    public interface IAuditManager : IManager
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

        Task<string> DownloadFileAsync();
    }
}