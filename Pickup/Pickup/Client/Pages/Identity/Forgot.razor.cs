﻿using Blazored.FluentValidation;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Pickup.Application.Requests.Identity;
using System.Threading.Tasks;

namespace Pickup.Client.Pages.Identity
{
    public partial class Forgot
    {
        [Inject] private Microsoft.Extensions.Localization.IStringLocalizer<Forgot> localizer { get; set; }

        private FluentValidationValidator _fluentValidationValidator;
        private bool validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

        private readonly ForgotPasswordRequest emailModel = new();

        private async Task SubmitAsync()
        {
            var result = await _userManager.ForgotPasswordAsync(emailModel);
            if (result.Succeeded)
            {
                _snackBar.Add(localizer["Done!"], Severity.Success);
                _navigationManager.NavigateTo("/");
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
        }
    }
}