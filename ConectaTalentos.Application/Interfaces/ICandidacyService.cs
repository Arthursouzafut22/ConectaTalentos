using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Candidacys;
using Microsoft.AspNetCore.Http;

namespace ConectaTalentos.Application.Interfaces
{
    public interface ICandidacyService
    {
        Task<ApiResponse<CandidacyResponseDTO>> Apply(int jobId, int userId, IFormFile file);
        Task<ApiResponse<IEnumerable<MyCandidacyResponseDTO>>> MyCandidacys(int userId);
        Task<ApiResponse<string>> DownloadCurriculum(int id, int userId);
        Task<ApiResponse<MyCandidacyResponseDTO>> UpdatStatusCandidacys(int id, int userId, UpdatStatusDTO dto);
    }
}
