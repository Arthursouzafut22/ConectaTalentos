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

            return ApiResponse<JobResponseDTO>.Ok(response, ResultMessages.PublishSuccessMessage);
        }

        public async Task<ApiResponse<IEnumerable<JobResponseDTO>>> GetAll()
        {
            _logger.LogInformation("Buscando todas as vagas de emprego publicadas.");

            var jobs = await _repositories.GetAll();

            var response = jobs.Select(j => j.ToResponseDTO()).ToList();

            _logger.LogInformation("Foram encontradas {TotalVagas} vaga(s) publicada(s).", response.Count);

            return ApiResponse<IEnumerable<JobResponseDTO>>.Ok(response, ResultMessages.JobsRetrievedMessage); 
        }

        public async Task<ApiResponse<JobResponseDTO>> GetById(int? id)
        {
            _logger.LogInformation("Buscando vaga pelo {id}.", id);

            var job = await _repositories.GetById(id);

            if (job is null)
            {
                _logger.LogWarning("Vaga com Id {Id} não encontrada.", id);
                return ApiResponse<JobResponseDTO>.NotFound(ResultMessages.JobNotFoundMessage);
            }

            var response = job?.ToResponseDTO();

            return ApiResponse<JobResponseDTO>.Ok(response, "Vaga encontrada com sucesso.");
        }

        public async Task<ApiResponse<IEnumerable<JobResponseDTO>>> GetMyJobs(int id)
        {
            var jobs = await _repositories.GetAll();

            var response = jobs.Where(j => j.RecruiterId == id)
                .Select(j => j.ToResponseDTO());

            return ApiResponse<IEnumerable<JobResponseDTO>>.Ok(response, "Vagas encontradas com sucesso.");
        }

        public async Task<ApiResponse<JobResponseDTO>> UpdateJob(int id, UpdateJob job)
        {
            var existJob = await _repositories.GetById(id);

            if(existJob is null)
            {
                return ApiResponse<JobResponseDTO>.NotFound(ResultMessages.JobNotFoundMessage);
            }

            var updateJob = await _repositories.Update(existJob);
            var response = updateJob?.ToResponseDTO();

            return ApiResponse<JobResponseDTO>.Ok(response, "Vagas atualizada com sucesso.");
        }
    }
}
