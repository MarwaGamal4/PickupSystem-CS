using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Pickup.Application.Configurations;

namespace Pickup.Server.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddValidators(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppConfiguration>());
            return builder;
        }
    }
}