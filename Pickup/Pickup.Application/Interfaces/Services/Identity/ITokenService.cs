using Pickup.Application.Interfaces.Common;
using Pickup.Application.Requests.Identity;
using Pickup.Application.Responses.Identity;
using Pickup.Shared.Wrapper;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}