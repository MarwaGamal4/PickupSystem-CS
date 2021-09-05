using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Branches.Commands.AddEdit;
using Pickup.Application.Validators.Features.Brands.Commands.AddEdit;

namespace Pickup.Application.Validators.Features.Branches.Command.AddEdit
{
   public class AddEditBranchCommandValidator : AbstractValidator<AddEditBranchCommand>
    {
        public AddEditBranchCommandValidator(IStringLocalizer<AddEditBrandCommandValidator> localizer)
        {
            RuleFor(request => request.BranchName)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Branch Name is required!"]);

        }
    }
}
