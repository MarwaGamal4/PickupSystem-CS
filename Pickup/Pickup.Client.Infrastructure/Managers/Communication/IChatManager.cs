using Pickup.Application.Models.Chat;
using Pickup.Application.Responses.Identity;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}