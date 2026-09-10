using Microsoft.AspNetCore.Http;

namespace ConectaTalentos.Application.Interfaces
{
    public interface ISupabaseStorageService
    {
        Task<string> UploadFileloAsync(IFormFile file);
    }
}
