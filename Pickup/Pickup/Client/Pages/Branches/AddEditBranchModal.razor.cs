using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using Pickup.Application.Features.Branches.Commands.AddEdit;
using Pickup.Client.Extensions;
using Pickup.Shared.Constants.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pickup.Client.Pages.Branches
{
    public partial class AddEditBranchModal
    {
        [Parameter]
        public AddEditBranchCommand AddEditBranchModel { get; set; } = new();
        [Inject] private Microsoft.Extensions.Localization.IStringLocalizer<AddEditBranchModal> localizer { get; set; }
        private FluentValidationValidator _fluentValidationValidator;
        private bool validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] public HubConnection hubConnection { get; set; }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            _processing = true;
            var response = await _branchManager.SaveAsync(AddEditBranchModel);
            if (response.Succeeded)
            {
                _snackBar.Add(localizer[response.Messages[0]], Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
            await hubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
            _processing = false;
        }

        protected override async Task OnInitializedAsync()
        {

            await LoadDataAsync();

            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }
        private async Task LoadDataAsync()
        {
            await Task.CompletedTask;
        }
    }
}
