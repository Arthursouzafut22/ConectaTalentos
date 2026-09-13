using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Candidacys;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Application.Mappings;
using ConectaTalentos.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ConectaTalentos.Application.Services
{
    public class CandidacyService : ICandidacyService
    {
        private readonly ISupabaseStorageService _storage;
        private readonly IJobRepository _jobRepository;
        private readonly ICandidacyRepository _repository;
        private readonly ILogger<CandidacyService> _logger;
        private const long MaxFileSizeBytes = 5 * 1024 * 1024;

        public CandidacyService(
            ISupabaseStorageService storage,
            IJobRepository jobRepository,
            ICandidacyRepository repository,
            ILogger<CandidacyService> logger)
        {
            _storage = storage;
            _jobRepository = jobRepository;
            _repository = repository;
            _logger = logger;
        }
        public async Task<ApiResponse<CandidacyResponseDTO>> Apply(int jobId, int userId, IFormFile file)
        {
            var existsCandidacy = await _repository.ExistsCandidacyForJob(jobId, userId);
            var existsJob = await _jobRepository.GetById(jobId);
            var allowedTypes = new[] { "application/pdf" };

            if (file is null || file.Length == 0)
            {
                _logger.LogWarning("Tentativa de upload com arquivo nulo ou vazio.");
                return ApiResponse<CandidacyResponseDTO>.BadRequest(ResultMessages.IsFileInvalid);
            }

            if (!allowedTypes.Contains(file.ContentType))
            {
                _logger.LogWarning("Tentativa de upload com tipo de arquivo não permitido");
                return ApiResponse<CandidacyResponseDTO>.BadRequest(ResultMessages.InvalidFileTypeMessage);
            }

            if (file.Length > MaxFileSizeBytes)
            {
                _logger.LogWarning("Tentativa de upload com arquivo acima do tamanho permitido (5MB)");
                return ApiResponse<CandidacyResponseDTO>.BadRequest(ResultMessages.MaxFileSizeMessage);
            }

            if (existsJob is null)
            {
                _logger.LogWarning("Vaga com Id {Id} não encontrada.", jobId);
                return ApiResponse<CandidacyResponseDTO>.NotFound(ResultMessages.JobNotFoundMessage);
            }

            if (existsCandidacy)
            {
                _logger.LogWarning("Tentativa de candidatura duplicada para a mesma vaga.");
                return ApiResponse<CandidacyResponseDTO>.Conflict(ResultMessages.DuplicateApplicationMessage);
            }

            var uploadUrl = await _storage.UploadFileloAsync(file);
            var candidacy = CandidacyMappingExtensions.ToEntity(jobId, userId, uploadUrl);
            var create = await _repository.Create(candidacy);
            var response = CandidacyMappingExtensions.ToResponse(file.FileName, create.CurriculumUrl);


            return ApiResponse<CandidacyResponseDTO>.Ok(response, ResultMessages.ApplicationSuccessMessage);
        }

        public async Task<ApiResponse<IEnumerable<MyCandidacyResponseDTO>>> MyCandidacys(int userId)
        {
            var myCandidacys = await _repository.GetAll(userId);
            var response = myCandidacys.Select(x => CandidacyMappingExtensions.ToResponseMyCandidacy(x));

            return ApiResponse<IEnumerable<MyCandidacyResponseDTO>>.Ok(response, ResultMessages.CandidacysSuccessMessage);
        }

        public async Task<ApiResponse<string>> DownloadCurriculum(int id, int userId)
        {
            var candidacy = await _repository.GetById(id);

            if (candidacy is null)
            {
                _logger.LogWarning("Candidatura com Id {Id} não encontrada.", id);
                return ApiResponse<string>.NotFound(ResultMessages.CandidacyNotFoundMessage);
            }

            if (candidacy.UserId != userId)
            {
                _logger.LogWarning("Tentativa de acesso indevido ao currículo {CandidacyId}.", id);
                return ApiResponse<string>.Forbidden(ResultMessages.DownloadForbiddenMessage);
            }

            return ApiResponse<string>.Ok(candidacy.CurriculumUrl, ResultMessages.CurriculumUrlSuccessMessage);
        }

        public async Task<ApiResponse<MyCandidacyResponseDTO>> UpdateStatusCandidacys(
            int id,
            int userId, 
            UpdatStatusDTO dto)
        {
            var candidacy = await _repository.GetById(id);

            if (candidacy is null)
            {
                _logger.LogWarning("Candidatura com Id {Id} não encontrada.", id);
                return ApiResponse<MyCandidacyResponseDTO>.NotFound(ResultMessages.CandidacyNotFoundMessage);
            }

            var job = await _jobRepository.GetById(candidacy.JobId);
            var recruiterId = job?.RecruiterId;

            if (recruiterId != userId)
            {
                _logger.LogWarning("Tentativa de editar candidatura de outro recrutador. UserId: {UserId}.", userId);
                return ApiResponse<MyCandidacyResponseDTO>.Forbidden(ResultMessages.UpdateStatusForbiddenMessage);
            }

            candidacy?.Status = dto.Status;

            var updateCandidacy = await _repository.Update(candidacy); ;
            var response = CandidacyMappingExtensions.ToResponseMyCandidacy(updateCandidacy);

            return ApiResponse<MyCandidacyResponseDTO>.Ok(response, ResultMessages.UpdateStatusSuccessMessage);
        }
    }
}