using ConectaTalentos.Domain.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConectaTalentos.Infrastructure.Configuration
{
    public static class DependencyInjectionValidators
    {
        public static IServiceCollection AddInfrastructureValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<UpdateJobValidator>();
            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
