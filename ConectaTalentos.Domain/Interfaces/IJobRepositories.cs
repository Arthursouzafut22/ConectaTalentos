using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Domain.Interfaces
{
    public interface IJobRepositories
    {
        Task<Job> Create(Job job);
        Task<IEnumerable<Job>> GetAll();
        Task<Job?> GetById(int? id);
        Task<Job?> Update(Job job);
        Task Delete(Job job);
    }
}
