using System.Text.Json.Serialization;

namespace ConectaTalentos.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContractType
    {
        CLT,
        PJ,
        Estagio,
        Freelancer
    }
}
