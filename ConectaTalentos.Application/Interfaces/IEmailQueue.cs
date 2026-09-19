using ConectaTalentos.Application.DTOs.Email;

namespace ConectaTalentos.Application.Interfaces
{
    public interface IEmailQueue
    {
        void Enfileirar(EmailMensagem mensagem);
        IAsyncEnumerable<EmailMensagem> ConsumirAsync(CancellationToken cancellationToken);
    }
}
