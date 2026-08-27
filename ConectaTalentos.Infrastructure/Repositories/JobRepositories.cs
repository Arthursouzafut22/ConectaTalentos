using ConectaTalentos.Domain.Interfaces;
using ConectaTalentos.Domain.Models;
using ConectaTalentos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConectaTalentos.Infrastructure.Repositories
{
    public class JobRepositories : IJobRepositories
    {
        private readonly AppDbContext _context;

        public JobRepositories(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Job> Create(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job?> GetById(int? id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task Delete(Job job)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
        }
    }
}
