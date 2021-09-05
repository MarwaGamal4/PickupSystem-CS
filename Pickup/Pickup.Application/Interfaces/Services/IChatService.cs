using Pickup.Application.Models.Chat;
using Pickup.Application.Responses.Identity;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}