using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
