using ConectaTalentos.Domain.Enums;
using System.Text.Json.Serialization;

namespace ConectaTalentos.Application.DTOs.Jobs
{
    public class JobResponseDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("id_recrutador")]
        public int RecruiterId { get; set; }

        [JsonPropertyName("nome_vaga")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("nome_empresa")]
        public string CompanyName { get; set; } = string.Empty;

        [JsonPropertyName("sobre_empresa")]
        public string CompanyDescription { get; set; } = string.Empty;

        [JsonPropertyName("tecnologias_desejadas")]
        public string[] DesiredTechnologies { get; set; } = [];

        [JsonPropertyName("localizacao")]
        public string Location { get; set; } = string.Empty;

        [JsonPropertyName("salario")]
        public decimal Salary { get; set; }

        [JsonPropertyName("tipo_contrato")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContractType ContractType { get; set; }

        [JsonPropertyName("modelo_trabalho")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WorkMode WorkMode { get; set; }

        [JsonPropertyName("descricao_vaga")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("beneficios_vaga")]
        public List<string> Benefits { get; set; } = [];

        [JsonPropertyName("requisitos_vaga")]
        public List<string> Requirements { get; set; } = [];

        [JsonPropertyName("esta_ativa")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("data_registro")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
