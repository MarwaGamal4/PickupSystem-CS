using Pickup.Application.Interfaces.Common;

namespace Pickup.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}