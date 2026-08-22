namespace ConectaTalentos.Application.DTOs.Account
{
    public class UserToken
    {
        public bool Authenticated { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        
    }
}
