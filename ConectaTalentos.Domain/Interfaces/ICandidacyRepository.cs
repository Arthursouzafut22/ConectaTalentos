using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Domain.Interfaces
{
    public interface ICandidacyRepository
    {
        Task<Candidacy> Create(Candidacy candidacy);
        Task<bool> ExistsCandidacyForJob(int jobId, int userId);
    }
}
