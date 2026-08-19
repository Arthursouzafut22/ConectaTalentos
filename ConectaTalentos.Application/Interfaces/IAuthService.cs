using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Account;

namespace ConectaTalentos.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<UserResponseDTO>> RegisterAsync(UserDTO user);
    }
}
