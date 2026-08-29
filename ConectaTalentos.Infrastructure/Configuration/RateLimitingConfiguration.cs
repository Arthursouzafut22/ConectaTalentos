using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

namespace ConectaTalentos.Infrastructure.Configuration
{
    public static class RateLimitingConfiguration
    {
        public static IServiceCollection AddRateLimitingConfiguration(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.AddPolicy("Login", context =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "desconhecido",
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 5,
                            Window = TimeSpan.FromMinutes(15),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        }));

                options.AddPolicy("Fixed", context =>
                     RateLimitPartition.GetFixedWindowLimiter(
                         partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "desconhecido",
                         factory: _ => new FixedWindowRateLimiterOptions
                         {
                             PermitLimit = 100,
                             Window = TimeSpan.FromMinutes(1),
                             QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                             QueueLimit = 2
                         }));

                options.AddPolicy("PublicarVaga", context =>
                {
                    var userId = context.User.FindFirst("id")?.Value ?? "anonimo";

                    return RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: userId,
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 5,
                            Window = TimeSpan.FromMinutes(5),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        });
                });

                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    await context.HttpContext.Response.WriteAsync("{\"message\": \"Muitas requisições. " +
                        "Tente novamente em instantes.\"}",
                        cancellationToken: token);
                };
            });

            return services;
        }
    }
}
