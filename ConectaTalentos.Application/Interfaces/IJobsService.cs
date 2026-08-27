using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Jobs;

namespace ConectaTalentos.Application.Interfaces
{
    public interface IJobsService
    {
        Task<ApiResponse<JobResponseDTO>> CreteJob(CreteJobsDTO job, int userId);
    }
}
