using Pickup.Application.Requests.Mail;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}