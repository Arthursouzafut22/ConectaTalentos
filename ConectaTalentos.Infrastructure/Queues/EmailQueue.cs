using ConectaTalentos.Application.DTOs.Email;
using ConectaTalentos.Application.Interfaces;
using System.Threading.Channels;

namespace ConectaTalentos.Infrastructure.Queues
{
    public class EmailQueue : IEmailQueue
    {
        private readonly Channel<EmailMensagem> _channel = Channel.CreateUnbounded<EmailMensagem>();

        public void Enfileirar(EmailMensagem mensagem)
            => _channel.Writer.TryWrite(mensagem);

        public IAsyncEnumerable<EmailMensagem> ConsumirAsync(CancellationToken cancellationToken)
            => _channel.Reader.ReadAllAsync(cancellationToken);
    }
}
