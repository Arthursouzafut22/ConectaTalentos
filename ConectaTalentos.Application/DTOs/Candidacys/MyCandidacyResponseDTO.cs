using ConectaTalentos.Domain.Enums;
using System.Text.Json.Serialization;

namespace ConectaTalentos.Application.DTOs.Candidacys
{
    public class MyCandidacyResponseDTO
    {
        public int Id { get; set; }
        public ApplicationStatus Status { get; set; }

        [JsonPropertyName("nome_vaga")]
        public string? Title { get; set; }

        [JsonPropertyName("nome_empresa")]
        public string? CompanyName { get; set; }

        [JsonPropertyName("modelo_trabalho")]
        public WorkMode WorkMode { get; set; }

        [JsonPropertyName("data_candidatura")]
        public DateTime ApplicationDate { get; set; }
    }
}
