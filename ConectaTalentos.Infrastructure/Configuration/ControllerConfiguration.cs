using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ConectaTalentos.Infrastructure.Configuration
{
    public static class ControllerConfiguration
    {
        public static IServiceCollection AddControllerConfiguration(
        this IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var error = context.ModelState
                            .Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .FirstOrDefault();

                        return new BadRequestObjectResult(new
                        {
                            message = error
                        });
                    };
                });

            return services;
        }
    }
}
