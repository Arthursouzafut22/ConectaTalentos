using ConectaTalentos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ConectaTalentos.Application.Services
{
    public class SupabaseStorageService : ISupabaseStorageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _supabaseUrl;
        private readonly string _bucketName;

        public SupabaseStorageService(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _supabaseUrl = configuration["Supabase:Url"]!;     
            _bucketName = configuration["Supabase:BucketName"]!; 
            var serviceKey = configuration["Supabase:ServiceKey"]!;

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", serviceKey);
            _httpClient.DefaultRequestHeaders.Add("apikey", serviceKey);
        }

        public async Task<string> UploadFileloAsync(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}/{file.FileName}";
            var uploadUrl = $"{_supabaseUrl}/storage/v1/object/{_bucketName}/{fileName}";

            using var stream = file.OpenReadStream();
            using var content = new StreamContent(stream);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(
                file.ContentType ?? "application/octet-stream");

            var response = await _httpClient.PostAsync(uploadUrl, content);
            response.EnsureSuccessStatusCode();

            return $"{_supabaseUrl}/storage/v1/object/public/{_bucketName}/{fileName}";
        }
    }
}