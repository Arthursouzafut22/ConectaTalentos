using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User?> GetById(int? id);
        Task<bool> GetByEmail(string email);
    }
}
