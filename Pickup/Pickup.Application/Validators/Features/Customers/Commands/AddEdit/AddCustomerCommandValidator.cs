using FluentValidation;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Customers.Commands.AddEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Validators.Features.Customers.Commands.AddEdit
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator(IStringLocalizer<AddCustomerCommandValidator> localizer)
        {
            RuleFor(request => request.CustomerRequest.Name)
              .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Customer Name is required!"]);
            RuleFor(request => request.CustomerRequest.Phone1).Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Customer Phone is required!"]);
            RuleFor(x => x.CustomerRequest.Phone2).NotEqual(x => x.CustomerRequest.Phone1).WithMessage(localizer["Second phone Number Mut Be Uniq!"]);
        }
    }
}
