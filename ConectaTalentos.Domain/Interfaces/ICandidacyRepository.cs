using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Domain.Interfaces
{
    public interface ICandidacyRepository
    {
        Task<Candidacy> Create(Candidacy candidacy);
        Task<Candidacy?> Update(Candidacy candidacy);
        Task<bool> ExistsCandidacyForJob(int jobId, int userId);
        Task<List<Candidacy>> GetAll(int userId);
        Task<Candidacy?> GetById(int id);
    }
}
