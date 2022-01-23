using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using Pickup.Application.Features.Branches.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pickup.Shared.Constants.Application;
using Pickup.Client.Extensions;
using Pickup.Application.Features.Branches.Commands.AddEdit;

namespace Pickup.Client.Pages.Branches
{
    public partial class Branches
    {
        public List<GetAllBranchesResponse> BranchList = new();
        private GetAllBranchesResponse branch = new();
        private string searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;
        private bool _Loading = false;
        [CascadingParameter] public HubConnection hubConnection { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetBranchesAsync();
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }
        public Branches()
        {

        }

        private async Task GetBranchesAsync()
        {
            _Loading = true;
            var response = await _branchManager.GetAllAsync();
            if (response.Succeeded)
            {
                BranchList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
            _Loading = false;
        }

        private async Task Delete(int id)
        {
            string deleteContent = localizer["Delete Content"];
            var parameters = new DialogParameters();
            parameters.Add("ContentText", string.Format(deleteContent, id));
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await _branchManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    await Reset();
                    await hubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(localizer[response.Messages[0]], Severity.Success);
                }
                else
                {
                    await Reset();
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(localizer[message], Severity.Error);
                    }
                }
            }

        }
        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                branch = BranchList.FirstOrDefault(c => c.Id == id);
                if (branch != null)
                {
                    parameters.Add(nameof(AddEditBranchModal.AddEditBranchModel), new AddEditBranchCommand
                    {
                        Id = branch.Id,
                        BranchName = branch.BranchName
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditBranchModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            branch = new GetAllBranchesResponse();
            await GetBranchesAsync();
        }

        private bool Search(GetAllBranchesResponse branch)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (branch.BranchName?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }
        private void manageUsers(int BranchId)
        {
            _navigationManager.NavigateTo($"/Admin/Branches/{BranchId}");
        }
    }
}
