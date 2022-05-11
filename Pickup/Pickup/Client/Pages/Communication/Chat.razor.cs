using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using MudBlazor;
using Pickup.Application.Models.Chat;
using Pickup.Application.Responses.Identity;
using Pickup.Client.Extensions;
using Pickup.Shared.Constants.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Client.Pages.Communication
{
    public partial class Chat
    {
        [CascadingParameter] public HubConnection hubConnection { get; set; }
        [Parameter] public string CurrentMessage { get; set; }
        [Parameter] public string CurrentUserId { get; set; }
        [Parameter] public string CurrentUserImageURL { get; set; }
        [CascadingParameter] private bool IsConnected { get; set; }
        public string direction { get; set; } = "rtl";
        private List<ChatHistoryResponse> messages = new List<ChatHistoryResponse>();

        private class MessageRequest
        {
            public string userName { get; set; }
            public string message { get; set; }
        }
        public string msgDirection(ChatHistoryResponse msg)
        {
            if (msg.FromUserId == CurrentUserId)
            {
                return "rtl";
            }
            return "inherit";
        }
        ElementReference MsgBackground;
        public string BackColorStyle(ChatHistoryResponse msg)
        {

            if (msg.FromUserId == CurrentUserId)
            {
                return "padding: 15px; background-color: #D9FDD3; border-radius: 17px;border-top-right-radius: 0; margin-top: 5px; width: fit-content";
            }
            return "padding: 15px; background-color: #FFFFFF; border-radius: 17px;border-top-left-radius: 0; margin-top: 5px; width: fit-content";
        }
        private MessageRequest model = new MessageRequest();
        private DotNetObjectReference<Chat> ChatObj;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            ChatObj = DotNetObjectReference.Create(this);
            await _jsRuntime.InvokeAsync<string>("ScrollToBottom", "chatContainer");
            await _jsRuntime.InvokeVoidAsync("SendMessage", ChatObj);
        }
        public void Dispose()
        {
            ChatObj?.Dispose();
        }
        [JSInvokable("SubmitAsync")]
        public async Task SubmitAsync()
        {
            if (!string.IsNullOrEmpty(CurrentMessage) && !string.IsNullOrEmpty(CId))
            {
                //Save Message to DB
                var chatHistory = new ChatHistory()
                {
                    Message = CurrentMessage,
                    ToUserId = CId,
                    CreatedDate = DateTime.Now
                };
                CurrentMessage = string.Empty;
                var response = await _chatManager.SaveMessageAsync(chatHistory);
                if (response.Succeeded)
                {
                    var state = await _stateProvider.GetAuthenticationStateAsync();
                    var user = state.User;
                    CurrentUserId = user.GetUserId();
                    chatHistory.FromUserId = CurrentUserId;
                    var userName = $"{user.GetFirstName()} {user.GetLastName()}";
                    await hubConnection.SendAsync(ApplicationConstants.SignalR.SendMessage, chatHistory, userName);
                    //CurrentMessage = string.Empty;
                }
                else
                {
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(localizer[message], Severity.Error);
                    }
                }
            }
        }

        private void OnKeyPressInChat(KeyboardEventArgs e)
        {
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                SubmitAsync();
                //CurrentMessage = string.Empty;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
            hubConnection.On<ChatHistory, string>("ReceiveMessage", async (chatHistory, userName) =>
             {
                 if ((CId == chatHistory.ToUserId && CurrentUserId == chatHistory.FromUserId) || (CId == chatHistory.FromUserId && CurrentUserId == chatHistory.ToUserId))
                 {
                     if ((CId == chatHistory.ToUserId && CurrentUserId == chatHistory.FromUserId))
                     {
                         messages.Add(new ChatHistoryResponse { Message = chatHistory.Message, FromUserId = chatHistory.FromUserId, ToUserId = chatHistory.ToUserId, FromUserFullName = userName, CreatedDate = chatHistory.CreatedDate, FromUserImageURL = CurrentUserImageURL });

                         await hubConnection.SendAsync(ApplicationConstants.SignalR.SendChatNotification, $"New Message From {userName}", CId, CurrentUserId);
                     }
                     else if ((CId == chatHistory.FromUserId && CurrentUserId == chatHistory.ToUserId))
                     {
                         await _chatManager.MarkasRead(CId);
                         messages.Add(new ChatHistoryResponse { Message = chatHistory.Message, FromUserId = chatHistory.FromUserId, ToUserId = chatHistory.ToUserId, FromUserFullName = userName, CreatedDate = chatHistory.CreatedDate, FromUserImageURL = CImageURL });

                     }
                     await _jsRuntime.InvokeAsync<string>("ScrollToBottom", "chatContainer");
                     StateHasChanged();
                 }
             });
            await GetUsersAsync();
            var state = await _stateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            CurrentUserId = user.GetUserId();
            CurrentUserImageURL = await _localStorage.GetItemAsync<string>("userImageURL");
            if (!string.IsNullOrEmpty(CId))
            {
                await LoadUserChat(CId);
            }
        }

        public List<ChatUserResponse> UserList = new List<ChatUserResponse>();
        [Parameter] public string CFullName { get; set; }
        [Parameter] public string CId { get; set; }
        [Parameter] public string CUserName { get; set; }
        [Parameter] public string CImageURL { get; set; }
        [CascadingParameter(Name = "GetMessagess")] public Action GetMessages { get; set; }

        private async Task LoadUserChat(string userId)
        {
            open = false;
            var response = await _userManager.GetAsync(userId);

            if (response.Succeeded)
            {
                var contact = response.Data;
                CId = contact.Id;


                CFullName = $"{contact.FirstName} {contact.LastName}";
                CUserName = contact.UserName;
                CImageURL = contact.ProfilePictureDataUrl;
                _navigationManager.NavigateTo($"chat/{CId}");
                //Load messages from db here

                messages = new List<ChatHistoryResponse>();
                var historyResponse = await _chatManager.GetChatHistoryAsync(CId);
                if (historyResponse.Succeeded)
                {
                    messages = historyResponse.Data.ToList();
                }
                else
                {
                    foreach (var message in historyResponse.Messages)
                    {
                        _snackBar.Add(localizer[message], Severity.Error);
                    }
                }

                await _chatManager.MarkasRead(CId);
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
            GetMessagess();
        }

        private async Task GetUsersAsync()
        {
            //add get chat history from chat controller / manager
            var response = await _chatManager.GetChatUsersAsync();
            if (response.Succeeded)
            {
                UserList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
        }

        private bool open;
        private Anchor ChatDrawer { get; set; }
        public List<ChatUserResponse> ChatUsers = new List<ChatUserResponse>();
        private async void GetMessagess()
        {
            var ChatUserss = await _chatManager.GetOldMessages();
            ChatUsers = ChatUserss.Data.ToList();
            appState.SetMessageCounter(ChatUsers.Where(x => x.Readed == false).Count());
            StateHasChanged();
        }
        private void OpenDrawer(Anchor anchor)
        {
            ChatDrawer = anchor;
            open = true;
        }
    }
}