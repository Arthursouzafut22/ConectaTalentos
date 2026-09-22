using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Domain.Interfaces
{
    public interface IJobRepository
    {
        Task<Job> Create(Job job);
        Task<IEnumerable<Job>> GetAll();
        Task<Job?> GetById(int? id);
        Task<Job?> GetJobWithCandidaciesAsync(int jobId);
        Task<Job?> Update(Job job);
        Task Delete(Job job);
    }
}
