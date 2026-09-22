using ConectaTalentos.Application.Common.Responses;
using ConectaTalentos.Application.DTOs.Account;

namespace ConectaTalentos.Application.Interfaces
{
    public interface IProfileService
    {
        Task<ApiResponse<UserResponseDTO>> MyProfile(int userId);
    }
}
