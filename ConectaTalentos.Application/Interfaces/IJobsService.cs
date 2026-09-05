using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Jobs;

namespace ConectaTalentos.Application.Interfaces
{
    public interface IJobsService
    {
        Task<ApiResponse<JobResponseDTO>> CreteJob(CreteJobsDTO job, int userId);
        Task<ApiResponse<IEnumerable<JobResponseDTO>>> GetAll();
        Task<ApiResponse<JobResponseDTO>> GetById(int? id);
        Task<ApiResponse<IEnumerable<JobResponseDTO>>> GetMyJobs(int id);
        Task<ApiResponse<JobResponseDTO>> UpdateJob(int id, int userId, UpdateJob job);
        Task<ApiResponse<JobResponseDTO>> DeleteJob(int id, int userId);
    }
}
