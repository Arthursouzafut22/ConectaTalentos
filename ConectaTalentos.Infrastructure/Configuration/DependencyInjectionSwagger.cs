using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace ConectaTalentos.Infrastructure.Configuration
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ConectaTalentos.API",
                    Version = "v1",
                    Description = "Plataforma para conectar profissionais a oportunidades de emprego."

                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Informe o token JWT.",
                });

                c.TagActionsBy(api =>
                {
                    var controller = api.ActionDescriptor.RouteValues["controller"];

                    return controller switch
                    {
                        "Auth" => new[] { "Autenticação" },
                        "Jobs" => new[] { "Vagas" },
                        _ => new[] { controller! }
                    };
                });

            });

            return services;
        }
        
    }
}
