using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MudBlazor;
using Pickup.Application.Features.Branches.Commands.AddUserToBranch;
using Pickup.Application.Features.Branches.Queries.GetById;
using Pickup.Application.Models.BranchManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pickup.Client.Pages.Branches
{
    public partial class BranchUsers
    {

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }

        public List<UsersBranchResponse> BranchUsersList { get; set; } = new();

        private GetBranchbyIdResponse ResponseModel = new();
        private string searchString = "";
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;

        int num = 0;
        bool BranchId;
        protected override async Task OnInitializedAsync()
        {
            BranchId = int.TryParse(Id, out num);
            if (BranchId)
            {
                var response = await _branchManager.GetBranchUsersAsync(num);
                BranchUsersList = response.Data.Users;
            }
            else
            {
                _snackBar.Add("Invalid Path :(", Severity.Error);
            }


        }

        private async Task SaveAsync()
        {

            UsersToBranchRequest req = new UsersToBranchRequest() { BranchId = num,BranchUsers = BranchUsersList };

            var request = new AddUserToBranchCommand()
            {
                usersToBranchRequest = req
            };
            var result = await _branchManager.AddUsersToBranch(request);
            if (result.Succeeded)
            {
                _snackBar.Add(localizer[result.Messages[0]], Severity.Success);
                _navigationManager.NavigateTo("/Admin/branches");
            }
            else
            {
                foreach (var error in result.Messages)
                {
                    _snackBar.Add(localizer[error], Severity.Error);
                }
            }
        }

        private bool Search(UsersBranchResponse userModel)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (userModel.UserName?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }



    }
}
