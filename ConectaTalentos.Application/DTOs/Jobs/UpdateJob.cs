using ConectaTalentos.Domain.Enums;
using System.Text.Json.Serialization;

namespace ConectaTalentos.Application.DTOs.Jobs
{
    public class UpdateJob
    {
        [property: JsonPropertyName("nome_vaga")]
        public string Title { get; set; } = string.Empty;

        [property: JsonPropertyName("nome_empresa")]
        public string CompanyName { get; set; } = string.Empty;

        [property: JsonPropertyName("sobre_empresa")]
        public string CompanyDescription { get; set; } = string.Empty;

        [property: JsonPropertyName("tecnologias_desejadas")]
        public string[] DesiredTechnologies { get; set; } = [];

        [property: JsonPropertyName("localizacao")]
        public string Location { get; set; } = string.Empty;

        [property: JsonPropertyName("salario")]
        public decimal? Salary { get; set; }

        [property: JsonPropertyName("tipo_contrato")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContractType? ContractType { get; set; }

        [property: JsonPropertyName("modelo_trabalho")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WorkMode? WorkMode { get; set; }

        [property: JsonPropertyName("descricao_vaga")]
        public string Description { get; set; } = string.Empty;

        [property: JsonPropertyName("beneficios_vaga")]
        public List<string> Benefits { get; set; } = [];

        [property: JsonPropertyName("requisitos_vaga")]
        public List<string> Requirements { get; set; } = [];

        [JsonPropertyName("esta_ativa")]
        public bool? IsActive { get; set; }
    }
}
