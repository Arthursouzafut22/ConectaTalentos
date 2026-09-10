using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Candidacys;
using Microsoft.AspNetCore.Http;

namespace ConectaTalentos.Application.Interfaces
{
    public interface ICandidacyService
    {
        Task<ApiResponse<CandidacyResponseDTO>> Apply(int jobId, int userId, IFormFile file);
    }
}
