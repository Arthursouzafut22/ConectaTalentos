using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Domain.Interfaces
{
    public interface IJobRepositories
    {
        Task<Job> Create(Job job);
        Task<IEnumerable<Job>> GetAll();
        Task<Job?> GetById(int? id);
        Task Delete(Job job);
    }
}
