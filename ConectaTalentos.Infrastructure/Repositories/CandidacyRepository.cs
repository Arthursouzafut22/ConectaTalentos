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

        public async Task<Candidacy?> Update(Candidacy candidacy)
        {
            var c = await GetById(candidacy.Id);
            if (c is null) return null;

            _context.Candidacys.Update(candidacy);
            await _context.SaveChangesAsync();
            return candidacy;
        }

        public async Task<bool> ExistsCandidacyForJob(int jobId, int userId) =>
            await _context.Candidacys.AnyAsync(c => c.JobId == jobId && c.UserId == userId);

        public async Task<List<Candidacy>> GetAll(int userId) =>
             _context.Candidacys.Where(c => c.UserId == userId)
            .Include(c => c.Job).ToList();

        public async Task<Candidacy?> GetById(int id) =>
            await _context.Candidacys.FindAsync(id);
    }
}
