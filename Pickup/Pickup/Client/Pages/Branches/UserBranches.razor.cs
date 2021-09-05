
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MudBlazor;
using Pickup.Application.Features.Users.Commands.AddEditBranchesToUser;
using Pickup.Application.Features.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pickup.Client.Pages.Branches
{
    public partial class UserBranches
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }

        public List<UserBranchesModel> userBranchesList { get; set; } = new();

        private UserBranchesQueryResponse ResponseModel = new();
        private string searchString = "";
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;

        protected override async Task OnInitializedAsync()
        {
                var response = await _branchManager.GetUserBranchessAsync(Id);
            userBranchesList = response.Data.Branches;
        }

        private async Task SaveAsync()
        {

            AddEditBranchesToUserCommand req = new AddEditBranchesToUserCommand() { UserID = Id , Branches = userBranchesList };
            var result = await _branchManager.AddBranchesToUser(req);
            if (result.Succeeded)
            {
                _snackBar.Add(localizer[result.Messages[0]], Severity.Success);
                _navigationManager.NavigateTo("/identity/users");
            }
            else
            {
                foreach (var error in result.Messages)
                {
                    _snackBar.Add(localizer[error], Severity.Error);
                }
            }
        }

        private bool Search(UserBranchesModel branchModel)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (branchModel.BranchName?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }


    }
}
