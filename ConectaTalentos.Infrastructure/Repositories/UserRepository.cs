using ConectaTalentos.Domain.Interfaces;
using ConectaTalentos.Domain.Models;
using ConectaTalentos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConectaTalentos.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
       private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetById(int? id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> GetByEmail(string email)
        {
            return await _context.Users.AnyAsync((e) => e.Email == email);
        }
    }
}
