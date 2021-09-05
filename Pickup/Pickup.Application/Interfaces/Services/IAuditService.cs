using Pickup.Application.Responses.Audit;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Services
{
    public interface IAuditService
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId);

        Task<string> ExportToExcelAsync(string userId);
    }
}