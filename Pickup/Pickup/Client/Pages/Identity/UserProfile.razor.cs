using Microsoft.AspNetCore.Components;
using MudBlazor;
using Pickup.Application.Requests.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pickup.Shared.Constants.User;
using Pickup.Shared.Constants.Role;
using System.Linq;

namespace Pickup.Client.Pages.Identity
{
    public partial class UserProfile
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }

        public bool Active { get; set; }
        private char FirstLetterOfName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserConstants.UserType _UserType { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Color AvatarButtonColor { get; set; } = Color.Error;
        public IEnumerable<string> Errors { get; set; }
        public bool ShowBranch { get; set; } = false;
        private async Task ToggleUserStatus()
        {
            var request = new ToggleUserStatusRequest { ActivateUser = Active, UserId = Id, UserType = _UserType };
            var result = await _userManager.ToggleUserStatusAsync(request);
            if (result.Succeeded)
            {
                _snackBar.Add(localizer["Updated User Status."], Severity.Success);
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

        [Parameter]
        public string ImageDataUrl { get; set; }
        public bool IsLoading { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            var userId = Id;
            var result = await _userManager.GetAsync(userId);
            var isAdmin = await _userManager.GetRolesAsync(userId);
            if (isAdmin.Succeeded)
            {
                var role = isAdmin.Data;
                if (role != null)
                {
                    ShowBranch = !(role.UserRoles.Any(x => x.RoleName == RoleConstants.AdministratorRole && x.Selected));
                }
            }
            if (result.Succeeded)
            {
                var user = result.Data;

                if (user != null)
                {
                    FirstName = user.FirstName;
                    LastName = user.LastName;
                    Email = user.Email;
                    PhoneNumber = user.PhoneNumber;
                    Active = user.IsActive;
                    _UserType = user.userType;
                    var data = await _accountManager.GetProfilePictureAsync(userId);
                    if (data.Succeeded)
                    {
                        ImageDataUrl = data.Data;
                    }
                }
                Title = $"{FirstName} {LastName}'s {localizer["Profile"]}";
                Description = Email;
                if (FirstName.Length > 0)
                {
                    FirstLetterOfName = FirstName[0];
                }
            }
            IsLoading = false;
        }
    }
}