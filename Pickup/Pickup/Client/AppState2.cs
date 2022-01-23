using Pickup.Application.Responses.Identity;
using Pickup.Client.Infrastructure.Managers.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Client
{
    public class AppState2
    {
        private readonly IChatManager _chatManager;
        private readonly AppState _appState;

        public AppState2(IChatManager chatManager, AppState appState)
        {
            _chatManager = chatManager;
            _appState = appState;
        }
        public async void GetMessages()
        {
            List<ChatUserResponse> ChatUsers = new List<ChatUserResponse>();
            var ChatUserss = await _chatManager.GetOldMessages();
            ChatUsers = ChatUserss.Data.ToList();
            _appState.SetMessageCounter(ChatUsers.Where(x => x.Readed == false).Count());
        }
    }
}
