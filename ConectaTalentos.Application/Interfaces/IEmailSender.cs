namespace ConectaTalentos.Application.Interfaces
{
    public interface IEmailSender
    {
        Task EnviarAsync(string para, string assunto, string corpo);
    }
}
