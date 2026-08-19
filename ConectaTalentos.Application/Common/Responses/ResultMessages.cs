namespace ConectaTalentos.Application.Common.Responses
{
    public static class ResultMessages
    {
        public static string EmailAlreadyRegistered { get; private set; } = "E-mail já cadastrado.";
        public static string PasswordsDoNotMatch { get; private set; } = "As senhas não conferem.";
    }
}
