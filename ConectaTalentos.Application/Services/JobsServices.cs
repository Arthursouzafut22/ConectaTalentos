using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Jobs;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Application.Mappings;
using ConectaTalentos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConectaTalentos.Application.Services
{
    public class JobsServices : IJobsService
    {
        private readonly IJobRepositories _repositories;
        private readonly ILogger<JobsServices> _logger;

        public JobsServices(IJobRepositories repositories, ILogger<JobsServices> logger)
        {
            _repositories = repositories;
            _logger = logger;
        }
        public async Task<ApiResponse<JobResponseDTO>> CreteJob(CreteJobsDTO dto, int userId)
        {
            var job = dto.ToEntity(userId);

            _logger.LogInformation("Publicando vaga de emprego.");
            var createJob = await _repositories.Create(job);

            var response = createJob.ToResponseDTO();

            return ApiResponse<JobResponseDTO>.SuccessResponse(response, "Vaga de emprego publicada com sucesso.");
        }
    }
}
