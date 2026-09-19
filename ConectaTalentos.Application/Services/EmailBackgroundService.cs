using ConectaTalentos.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConectaTalentos.Application.Services
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly IEmailQueue _fila;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EmailBackgroundService> _logger;

        public EmailBackgroundService(
            IEmailQueue fila,
            IServiceProvider serviceProvider,
            ILogger<EmailBackgroundService> logger)
        {
            _fila = fila;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmailBackgroundService iniciado.");

            await foreach (var mensagem in _fila.ConsumirAsync(stoppingToken))
            {
                using var scope = _serviceProvider.CreateScope();
                var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();

                try
                {
                    await emailSender.EnviarAsync(mensagem.Para, mensagem.Assunto, mensagem.Corpo);
                    _logger.LogInformation("Email enviado para {Email}", mensagem.Para);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Falha ao enviar email para {Email}", mensagem.Para);
                }
            }
        }
    }
}
