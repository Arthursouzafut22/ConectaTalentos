using ConectaTalentos.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConectaTalentos.Application.DTOs.Jobs
{
    public class CreteJobsDTO
    {
        [property: JsonPropertyName("nome_vaga")]
        [Required(ErrorMessage = "Nome da vaga é obrigatório")]
        public string Title { get; set; } = string.Empty;

        [property: JsonPropertyName("nome_empresa")]
        [Required(ErrorMessage = "Nome da empresa é obrigatório")]
        public string CompanyName { get; set; } = string.Empty;

        [property: JsonPropertyName("sobre_empresa")]
        [Required(ErrorMessage = "Descrição sobre a empresa é obrigatória")]
        public string CompanyDescription { get; set; } = string.Empty;

        [property: JsonPropertyName("tecnologias_desejadas")]
        [Required(ErrorMessage = "As tecnologias desejadas são obrigatórias")]
        public string[] DesiredTechnologies { get; set; } = [];

        [property: JsonPropertyName("localizacao")]
        [Required(ErrorMessage = "Localização da vaga é obrigatória")]
        public string Location { get; set; } = string.Empty;

        [property: JsonPropertyName("salario")]
        [Required(ErrorMessage = "Salário da vaga é obrigatório")]
        public decimal Salary { get; set; }

        [property: JsonPropertyName("tipo_contrato")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required(ErrorMessage = "O tipo de contratação da vaga é obrigatório")]
        public ContractType ContractType { get; set; }

        [property: JsonPropertyName("modelo_trabalho")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required(ErrorMessage = "A modalidade de trabalho é obrigatória")]
        public WorkMode WorkMode { get; set; }

        [property: JsonPropertyName("descricao_vaga")]
        [Required(ErrorMessage = "Descrição da vaga é obrigatória")]
        public string Description { get; set; } = string.Empty;

        [property: JsonPropertyName("beneficios_vaga")]
        [Required(ErrorMessage = "Benefícios da vaga são obrigatórios")]
        public List<string> Benefits { get; set; } = [];

        [property: JsonPropertyName("requisitos_vaga")]
        [Required(ErrorMessage = "Requisitos da vaga são obrigatórios")]
        public List<string> Requirements { get; set; } = [];

        [JsonPropertyName("esta_ativa")]
        public bool IsActive { get; set; } = true;
    }
}