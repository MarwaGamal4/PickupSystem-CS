﻿using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using MudBlazor;
using Pickup.Client.Extensions;
using Pickup.Client.Infrastructure.Settings;
using Pickup.Shared.Constants.Application;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Pickup.Application.Responses.Identity;
using System.Linq;

namespace Pickup.Client.Shared
{
    public partial class MainLayout : IDisposable
    {
        private string CurrentUserId { get; set; }
        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string Email { get; set; }
        private char FirstLetterOfName { get; set; }
        public Action GetMessagess { get; set; }
        private void LoadData()
        {
            LoadDataAsync().Wait();
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadDataAsync();
            }
        }
        private async Task LoadDataAsync()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            if (user == null) return;
            if (user.Identity?.IsAuthenticated == true)
            {
                CurrentUserId = user.GetUserId();
                this.FirstName = user.GetFirstName();
                if (this.FirstName.Length > 0)
                {
                    FirstLetterOfName = FirstName[0];
                }
                this.SecondName = user.GetLastName();
                this.Email = user.GetEmail();
            }
        }
        private int _MessagesCounter = 0;
        private MudTheme _currentTheme;
        private bool _drawerOpen = true;
        public bool RTL { get; set; } = false;
        public List<ChatUserResponse> ChatUsers { get; set; }
        private async void GetMessages()
        {
            if (await _authenticationManager.CurrentUser() != null)
            {
                var ChatUserss = await _chatManager.GetOldMessages();
                if (ChatUserss.Data != null)
                {
                    ChatUsers = ChatUserss.Data.ToList();
                    appState.SetMessageCounter(ChatUsers.Where(x => x.Readed == false).Count());
                    StateHasChanged();
                }
             
            }
         
        }
        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
            GetMessages();
            //  appState2.GetMessages();
            GetMessagess = GetMessages;
            _currentTheme = BlazorHeroTheme.DefaultTheme;
            _currentTheme = await _clientPreferenceManager.GetCurrentThemeAsync();
            _interceptor.RegisterEvent();
            var preference = await _clientPreferenceManager.GetPreference() as ClientPreference;
            RTL = preference.IsRTL;
            _drawerOpen = preference.IsDrawerOpen;
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            await hubConnection.StartAsync();
            hubConnection.On<string, string, string>(ApplicationConstants.SignalR.ReceiveChatNotification, (message, receiverUserId, senderUserId) =>
            {
                if (CurrentUserId == receiverUserId)
                {
                    GetMessages();
                    // appState2.GetMessages();
                    // _jsRuntime.InvokeAsync<string>("PlayAudio", "notification");
                    var curentUrl = _navigationManager.Uri;
                    if (!curentUrl.Contains(senderUserId))
                    {
                        _snackBar.Add(message, Severity.Info, config =>
                        {
                            config.VisibleStateDuration = 10000;
                            config.HideTransitionDuration = 500;
                            config.ShowTransitionDuration = 500;
                            config.Action = "Chat?";
                            config.ActionColor = Color.Primary;
                            config.Onclick = snackbar =>
                            {
                                _navigationManager.NavigateTo($"chat/{senderUserId}");
                                _chatManager.MarkasRead(senderUserId);
                                GetMessages();
                                //appState2.GetMessages();
                                return Task.CompletedTask;
                            };
                        });
                    }

                }
            });
            hubConnection.On(ApplicationConstants.SignalR.ReceiveRegenerateTokens, async () =>
            {
                try
                {
                    var token = await _authenticationManager.TryForceRefreshToken();
                    if (!string.IsNullOrEmpty(token))
                    {
                        _snackBar.Add(localizer["Refreshed Token."], Severity.Success);
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _snackBar.Add(localizer["You are Logged Out."], Severity.Error);
                    await _authenticationManager.Logout();
                    _navigationManager.NavigateTo("/");
                }
            });
        }

        private void Logout()
        {
            string logoutConfirmationText = localizer["Logout Confirmation"];
            string logoutText = localizer["Logout"];
            var parameters = new DialogParameters
            {
                {"ContentText", logoutConfirmationText},
                {"ButtonText", logoutText},
                {"Color", Color.Error}
            };

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

            _dialogService.Show<Dialogs.Logout>(localizer["Logout"], parameters, options);
        }

        private async Task DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
            await _clientPreferenceManager.ToggleDrawer(_drawerOpen);
        }

        private async Task DarkMode()
        {
            bool isDarkMode = await _clientPreferenceManager.ToggleDarkModeAsync();
            _currentTheme = isDarkMode
                ? BlazorHeroTheme.DefaultTheme
                : BlazorHeroTheme.DarkTheme;

        }

        public void Dispose()
        {
            _interceptor.DisposeEvent();
            //_ = hubConnection.DisposeAsync();
        }
        public bool IsLoading { get; set; } = false;
        private HubConnection hubConnection;
        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;
    }
}