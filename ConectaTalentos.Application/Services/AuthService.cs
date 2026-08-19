using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Account;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Domain.Enums;
using ConectaTalentos.Domain.Interfaces;
using ConectaTalentos.Domain.Models;
using Microsoft.Extensions.Logging;
using BC = BCrypt.Net;

namespace ConectaTalentos.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<AuthService> _logger;
        public AuthService(IUserRepository repository, ILogger<AuthService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<ApiResponse<UserResponseDTO>> RegisterAsync(UserDTO dto)
        {
            if (dto.ConfirmPassword != dto.Password)
            {
                return ApiResponse<UserResponseDTO>.ErrorResponse(null, ResultMessages.PasswordsDoNotMatch);
            }

            var existUser = await _repository.GetByEmail(dto.Email);

            if (existUser)
            {
                return ApiResponse<UserResponseDTO>.ErrorResponse(null, ResultMessages.EmailAlreadyRegistered);
            }

            var user = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role = UserRole.Candidate
            };

            var createUser = await _repository.Create(user);
            _logger.LogInformation($"Criando usuário do id: {createUser.Id}.");

            var userDto = new UserResponseDTO()
            {
                Id = createUser.Id,
                Name = createUser.Name,
                Email = createUser.Email
            };

            return ApiResponse<UserResponseDTO>.SuccessResponse(userDto, "Usuário cadastrado com sucesso.");
        }

        private string HashPassword(string password)
        {
            return BC.BCrypt.HashPassword(password);
        }
    }
}
