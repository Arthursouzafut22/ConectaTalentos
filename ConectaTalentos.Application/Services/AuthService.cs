using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Account;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Domain.Enums;
using ConectaTalentos.Domain.Interfaces;
using ConectaTalentos.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BC = BCrypt.Net;

namespace ConectaTalentos.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _token;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        public AuthService(IUserRepository repository, 
            ILogger<AuthService> logger, 
            ITokenService token,
            IConfiguration configuration)
        {
            _repository = repository;
            _token = token;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<ApiResponse<UserResponseDTO>> RegisterAsync(UserDTO dto)
        {
            if (dto.ConfirmPassword != dto.Password)
            {
                return ApiResponse<UserResponseDTO>.ErrorResponse(null, ResultMessages.PasswordsDoNotMatch);
            }

            var existUser = await _repository.EmailExists(dto.Email);

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
            _logger.LogInformation("Criando usuário do id: {UserId}.", createUser.Id);

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
        private bool VerifyPassword(string password, string passwordHash)
        {
            return BC.BCrypt.Verify(password, passwordHash);
        }
        public async Task<ApiResponse<UserToken>> LoginAsync(LoginDTO dto)
        {
            var user = await _repository.GetByEmail(dto.Email);

            if (user is null)
            {
                return ApiResponse<UserToken>.ErrorResponse(null, ResultMessages.InvalidCredentials);
            }

            _logger.LogInformation("Validando as senha do usuário.");
            var comparePassword = VerifyPassword(dto.Password, user.PasswordHash);

            if (!comparePassword)
            {
                return ApiResponse<UserToken>.ErrorResponse(null, ResultMessages.InvalidCredentials);
            }

            var accessToken = _token.GenerateToken(user);
            var expirationHours = _configuration.GetValue<int>("JwtSettings:ExpirationHours");

            var payload = new UserToken()
            {
                Authenticated = true,
                Expiration = DateTime.UtcNow.AddHours(expirationHours),
                Token = accessToken
            };

            return ApiResponse<UserToken>.SuccessResponse(payload, "Login realizado com sucesso.");
        }
    }
}
