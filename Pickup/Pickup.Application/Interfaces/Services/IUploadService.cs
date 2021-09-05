using Pickup.Application.Requests;

namespace Pickup.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}