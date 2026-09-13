using System.Text.Json.Serialization;

namespace ConectaTalentos.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplicationStatus
    {
        [JsonStringEnumMemberName("Currículo Enviado")]
        CurriculoEnviado,

        [JsonStringEnumMemberName("Oferta Recebida")]
        OfertaRecebida,

        [JsonStringEnumMemberName("Contratação Efetuada")]
        ContratacaoEfetuada,

        [JsonStringEnumMemberName("Reprovação Pela Empresa")]
        ReprovacaoPelaEmpresa,

        [JsonStringEnumMemberName("Não Tenho Mais Interesse")]
        NaoTenhoMaisInteresse
    }
}
