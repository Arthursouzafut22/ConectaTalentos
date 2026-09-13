using ConectaTalentos.Domain.Enums;
using System.Text.Json.Serialization;

namespace ConectaTalentos.Application.DTOs.Candidacys
{
    public class UpdatStatusDTO
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ApplicationStatus Status { get; set; }
    }
}
