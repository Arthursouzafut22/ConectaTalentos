namespace ConectaTalentos.Application.Common.Responses
{
    public static class ResultMessages
    {
        public static string UserCreatedMessage { get; private set; } = "Usuário cadastrado com sucesso.";
        public static string EmailAlreadyRegistered { get; private set; } = "E-mail já cadastrado.";
        public static string PasswordsDoNotMatch { get; private set; } = "As senhas não conferem.";
        public static string InvalidCredentials { get; private set; } = "Email ou senha inválidos";
        public static string LoginSuccess { get; private set; } = "Login realizado com sucesso.";
        public static string PublishSuccessMessage { get; private set; } = "Vaga de emprego publicada com sucesso.";
        public static string JobFoundSuccessfully { get; private set; } = "Vaga encontrada com sucesso.";
        public static string JobsRetrievedMessage { get; private set; } = "Vagas retornadas com sucesso.";
        public static string JobNotFoundMessage { get; private set; } = "Vaga não encontrada.";
        public static string NoPermissionToEditJob { get; private set; } = "Você não tem permissão para editar esta vaga.";
        public static string JobUpdatedSuccessfully { get; private set; } = "Vaga atualizada com sucesso.";
        public static string JobDeletedSuccessfully { get; private set; } = "Vaga excluida com sucesso.";
    }
}
