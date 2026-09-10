using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Jobs;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Application.Mappings;
using ConectaTalentos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConectaTalentos.Application.Services
{
    public class JobsService : IJobsService
    {
        private readonly IJobRepository _repositories;
        private readonly ILogger<JobsService> _logger;

        public JobsService(IJobRepository repositories, ILogger<JobsService> logger)
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

            return ApiResponse<JobResponseDTO>.Ok(response, ResultMessages.JobFoundSuccessfully);
        }

        public async Task<ApiResponse<IEnumerable<JobResponseDTO>>> GetMyJobs(int id)
        {
            var jobs = await _repositories.GetAll();

            var response = jobs.Where(j => j.RecruiterId == id)
                .Select(j => j.ToResponseDTO());

            return ApiResponse<IEnumerable<JobResponseDTO>>.Ok(response, ResultMessages.JobsRetrievedMessage);
        }

        public async Task<ApiResponse<JobResponseDTO>> UpdateJob(int id, int userId, UpdateJob dto)
        {
            var existJob = await _repositories.GetById(id);

            if(existJob?.RecruiterId != userId)
            {
                _logger.LogWarning("Usuário {UserId} sem permissão para editar vaga {JobId}.", userId, id);
                return ApiResponse<JobResponseDTO>.NotFound(ResultMessages.NoPermissionToEditJob);
            }

            if (existJob is null)
            {
                _logger.LogWarning("Vaga com Id {Id} não encontrada.", id);
                return ApiResponse<JobResponseDTO>.Forbidden(ResultMessages.JobNotFoundMessage);
            }

            existJob.Title = dto.Title ?? existJob.Title;
            existJob.CompanyName = dto.CompanyName ?? existJob.CompanyName;
            existJob.CompanyDescription = dto.CompanyDescription ?? existJob.CompanyDescription;
            existJob.DesiredTechnologies = dto.DesiredTechnologies ?? existJob.DesiredTechnologies;
            existJob.Location = dto.Location ?? existJob.Location;
            existJob.Salary = dto.Salary ?? existJob.Salary;
            existJob.ContractType = dto.ContractType ?? existJob.ContractType;
            existJob.WorkMode = dto.WorkMode ?? existJob.WorkMode;
            existJob.Description = dto.Description ?? existJob.Description;
            existJob.Benefits = dto.Benefits ?? existJob.Benefits;
            existJob.Requirements = dto.Requirements ?? existJob.Requirements;
            existJob.IsActive = dto.IsActive ?? existJob.IsActive;

            var updateJob = await _repositories.Update(existJob);
            var response = updateJob?.ToResponseDTO();

            return ApiResponse<JobResponseDTO>.Ok(response, ResultMessages.JobUpdatedSuccessfully);
        }

        public async Task<ApiResponse<JobResponseDTO>> DeleteJob(int id, int userId)
        {
            var existJob = await _repositories.GetById(id);

            if (existJob?.RecruiterId != userId)
            {
                _logger.LogWarning("Usuário {UserId} sem permissão para excluir vaga {JobId}.", userId, id);
                return ApiResponse<JobResponseDTO>.NotFound(ResultMessages.NoPermissionToEditJob);
            }

            if (existJob is null)
            {
                _logger.LogWarning("Vaga com Id {Id} não encontrada.", id);
                return ApiResponse<JobResponseDTO>.Forbidden(ResultMessages.JobNotFoundMessage);
            }

            await _repositories.Delete(existJob);

            return ApiResponse<JobResponseDTO>.NoContent(ResultMessages.JobDeletedSuccessfully);
        }
    }
}

