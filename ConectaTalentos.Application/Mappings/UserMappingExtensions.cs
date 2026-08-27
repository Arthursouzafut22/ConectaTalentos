using ConectaTalentos.Application.DTOs.Account;
using ConectaTalentos.Domain.Enums;
using ConectaTalentos.Domain.Models;
using ConectaTalentos.Infrastructure.Crypto;

namespace ConectaTalentos.Application.Mappings
{
    public static class UserMappingExtensions
    {
        public static User ToEntityUser(this UserDTO dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = CryptoHandler.HashPassword(dto.Password),
                Role = UserRole.Candidate
            };
        }

        public static UserResponseDTO ToUserResponseDTO(this User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
