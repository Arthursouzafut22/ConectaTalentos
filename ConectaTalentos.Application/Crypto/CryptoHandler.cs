using BC = BCrypt.Net;

namespace ConectaTalentos.Infrastructure.Crypto
{
    public class CryptoHandler
    {
        public static string HashPassword(string password)
        {
            return BC.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BC.BCrypt.Verify(password, passwordHash);
        }
    }
}
