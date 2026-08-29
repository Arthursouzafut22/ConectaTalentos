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
    }
}
