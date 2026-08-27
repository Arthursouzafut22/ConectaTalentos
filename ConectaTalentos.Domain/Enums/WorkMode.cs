using System.Text.Json.Serialization;

namespace ConectaTalentos.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WorkMode
    {
        Remoto,
        Presencial,
        Híbrido
    }
}
