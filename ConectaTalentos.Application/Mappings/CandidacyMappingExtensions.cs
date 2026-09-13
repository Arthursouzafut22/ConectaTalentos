using ConectaTalentos.Application.DTOs.Candidacys;
using ConectaTalentos.Domain.Models;

namespace ConectaTalentos.Application.Mappings
{
    public static class CandidacyMappingExtensions
    {
        public static Candidacy ToEntity(int jobId, int userId, string url)
        {
            return new Candidacy
            {
                JobId = jobId,
                UserId = userId,
                CurriculumUrl = url
            };
        }

        public static CandidacyResponseDTO ToResponse(string fileName, string fileUrl)
        {
            return new CandidacyResponseDTO
            {
                FileName = fileName,
                FileUrl = fileUrl
            };
        }

        public static MyCandidacyResponseDTO ToResponseMyCandidacy(Candidacy candidacy)
        {
            return new MyCandidacyResponseDTO
            {
                Id = candidacy.Id,
                Status = candidacy.Status,
                Title = candidacy?.Job?.Title,
                CompanyName = candidacy?.Job?.CompanyName,
                WorkMode = candidacy.Job.WorkMode,
                ApplicationDate = candidacy.ApplicationDate
            };
        }
    }
}
