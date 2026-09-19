namespace ConectaTalentos.Infrastructure.Configuration
{
    public class EmailSettings
    {
        public string Host { get; set; } = "";
        public int Port { get; set; }
        public string Usuario { get; set; } = "";
        public string Senha { get; set; } = "";
        public string Remetente { get; set; } = "";
    }
}
