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

        public async Task<Job?> Update(Job job)
        {
            var existingJob = await GetById(job.Id);
            if (existingJob is null) return null;

            existingJob.Title = job.Title;
            existingJob.CompanyName = job.CompanyName;
            existingJob.CompanyDescription = job.CompanyDescription;
            existingJob.DesiredTechnologies = job.DesiredTechnologies;
            existingJob.Location = job.Location;
            existingJob.Salary = job.Salary;
            existingJob.ContractType = job.ContractType;
            existingJob.WorkMode = job.WorkMode;
            existingJob.Description = job.Description;
            existingJob.Benefits = job.Benefits;
            existingJob.Requirements = job.Requirements;
            existingJob.IsActive = job.IsActive;
            existingJob.UpdatedAt = DateTime.UtcNow;

             _context.Jobs.Update(existingJob);

            await _context.SaveChangesAsync();
            return existingJob;
        }

        public async Task Delete(Job job)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
        }
    }
}
