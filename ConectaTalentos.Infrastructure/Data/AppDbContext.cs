using ConectaTalentos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConectaTalentos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
