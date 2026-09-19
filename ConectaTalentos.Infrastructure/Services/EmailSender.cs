using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ConectaTalentos.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;

        public EmailSender(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task EnviarAsync(string para, string assunto, string corpo)
        {
            using var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Usuario, _settings.Senha),
                EnableSsl = true
            };

            var mensagem = new MailMessage(_settings.Remetente, para, assunto, corpo)
            {
                IsBodyHtml = true
            };

            await client.SendMailAsync(mensagem);
        }
    }
}
