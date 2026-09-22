using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Account;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Application.Mappings;
using ConectaTalentos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConectaTalentos.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<ProfileService> _logger;

        public ProfileService(IUserRepository repository, ILogger<ProfileService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<ApiResponse<UserResponseDTO>> MyProfile(int userId)
        {
            var user = await _repository.GetById(userId);

            if (user is null)
            {
                _logger.LogWarning("Tentativa de acesso a usuário inexistente. Id: {UserId}", userId);
                return ApiResponse<UserResponseDTO>.NotFound(ResultMessages.UserDoesNotExist);
            }

            var response = user.ToUserResponseDTO();
            return ApiResponse<UserResponseDTO>.Ok(response, "sucesso.");
        }
    }
}
