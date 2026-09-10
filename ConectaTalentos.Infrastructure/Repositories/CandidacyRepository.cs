using ConectaTalentos.Domain.Interfaces;
using ConectaTalentos.Domain.Models;
using ConectaTalentos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConectaTalentos.Infrastructure.Repositories
{
    public class CandidacyRepository : ICandidacyRepository
    {
        private readonly AppDbContext _context;

        public CandidacyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Candidacy> Create(Candidacy candidacy)
        {
            _context.Candidacys.Add(candidacy);
            await _context.SaveChangesAsync();
            return candidacy;
        }

        public async Task<bool> ExistsCandidacyForJob(int jobId, int userId) =>
            await _context.Candidacys.AnyAsync(c => c.JobId == jobId && c.UserId == userId);
    }
}
