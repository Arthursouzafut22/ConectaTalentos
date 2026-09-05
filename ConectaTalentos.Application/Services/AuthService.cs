using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Account;
using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Application.Mappings;
using ConectaTalentos.Domain.Interfaces;
using ConectaTalentos.Infrastructure.Crypto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
                _logger.LogInformation($"É necessário confirmar a senha de acordo com a senha informada.");
                return ApiResponse<UserResponseDTO>.Conflict(ResultMessages.PasswordsDoNotMatch);
            }

            var existUser = await _repository.EmailExists(dto.Email);

            if (existUser)
            {
                _logger.LogInformation($"Usuário já existe no sistema, não é possível cadastrar um novo com essas credenciais");
                return ApiResponse<UserResponseDTO>.Conflict(ResultMessages.EmailAlreadyRegistered);
            }

            var user = dto.ToEntityUser();

            var createUser = await _repository.Create(user);
            _logger.LogInformation("Criando usuário do id: {UserId}.", createUser.Id);

            var userDto = createUser.ToUserResponseDTO();

            return ApiResponse<UserResponseDTO>.Ok(userDto, ResultMessages.UserCreatedMessage);
        }

        public async Task<ApiResponse<UserToken>> LoginAsync(LoginDTO dto)
        {
            var user = await _repository.GetByEmail(dto.Email);

            if (user is null)
            {
                return ApiResponse<UserToken>.NotFound(ResultMessages.InvalidCredentials);
            }

            _logger.LogInformation("Validando as senha do usuário.");
            var comparePassword = CryptoHandler.VerifyPassword(dto.Password, user.PasswordHash);

            if (!comparePassword)
            {
                return ApiResponse<UserToken>.Unauthorized(ResultMessages.InvalidCredentials);
            }

            var accessToken = _token.GenerateToken(user);
            var expirationHours = _configuration.GetValue<int>("JwtSettings:ExpirationHours");

            var payload = new UserToken()
            {
                Authenticated = true,
                Expiration = DateTime.UtcNow.AddHours(expirationHours),
                Token = accessToken
            };

            return ApiResponse<UserToken>.Ok(payload, ResultMessages.LoginSuccess);
        }
    }
}
