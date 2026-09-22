namespace ConectaTalentos.Application.Common.Responses
{
    public static class ResultMessages
    {
        public static string UserCreatedMessage { get; } = "Usuário cadastrado com sucesso.";
        public static string UserDoesNotExist { get; } = "Usuário não existe";
        public static string EmailAlreadyRegistered { get; } = "E-mail já cadastrado.";
        public static string PasswordsDoNotMatch { get; } = "As senhas não conferem.";
        public static string InvalidCredentials { get; } = "Email ou senha inválidos";
        public static string LoginSuccess { get; } = "Login realizado com sucesso.";
        public static string PublishSuccessMessage { get; } = "Vaga de emprego publicada com sucesso.";
        public static string JobFoundSuccessfully { get; } = "Vaga encontrada com sucesso.";
        public static string JobsRetrievedMessage { get; } = "Vagas retornadas com sucesso.";
        public static string JobNotFoundMessage { get; } = "Vaga não encontrada.";
        public static string NoPermissionToEditJob { get; } = "Você não tem permissão para editar esta vaga.";
        public static string JobUpdatedSuccessfully { get; } = "Vaga atualizada com sucesso.";
        public static string JobDeletedSuccessfully { get; } = "Vaga excluida com sucesso.";
        public static string IsFileInvalid { get; } = "Arquivo invalido";
        public static string InvalidFileTypeMessage { get; } = "Apenas arquivos PDF são permitidos.";
        public static string MaxFileSizeMessage { get; } = "O arquivo deve ter no máximo 5MB.";
        public static string DuplicateApplicationMessage { get; } = "Usuário já se candidatou a esta vaga.";
        public static string ApplicationSuccessMessage { get; } = "Candidatura realizada com sucesso.";
        public static string CandidacysSuccessMessage { get; } = "Candidaturas retornadas com sucesso.";
        public static string CandidacyNotFoundMessage { get; } = "Candidatura não localizada.";
        public static string CurriculumUrlSuccessMessage { get; } = "URL do currículo obtida com sucesso.";
        public static string DownloadForbiddenMessage { get; } = "Você não tem permissão para baixar esse recurso.";
        public static string UpdateStatusForbiddenMessage { get; } = "Você não tem permissão para editar o status dessa candidatura.";
        public static string UpdateStatusSuccessMessage { get; } = "Status da candidatura atualizado com sucesso.";
        public static string CandidatesRetrieved { get; } = "Candidatos retornados com sucesso.";
        public static string CandidatesAccessDenied { get; } = "Você não tem permissão para acessar os candidatos dessa vaga.";
    }
}
