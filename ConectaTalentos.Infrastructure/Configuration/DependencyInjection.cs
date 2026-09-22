using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Application.Services;
using ConectaTalentos.Domain.Interfaces;
using ConectaTalentos.Domain.Repositories;
using ConectaTalentos.Infrastructure.Data;
using ConectaTalentos.Infrastructure.Queues;
using ConectaTalentos.Infrastructure.Repositories;
using ConectaTalentos.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConectaTalentos.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobsService, JobsService>();
            services.AddScoped<ICandidacyRepository, CandidacyRepository>();
            services.AddScoped<ICandidacyService, CandidacyService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddHttpClient<ISupabaseStorageService, SupabaseStorageService>();

            services.Configure<EmailSettings>(configuration.GetSection("Email"));

            services.AddSingleton<IEmailQueue, EmailQueue>();
            services.AddScoped<IEmailSender, EmailSender>();
            

            services.AddHostedService<EmailBackgroundService>();

            return services;
        }

    }
}
