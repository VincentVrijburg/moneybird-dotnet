using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.ExternalSalesInvoices
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExternalSalesInvoiceOrigin
    {
        [JsonStringEnumMemberName("upload")]
        Upload,
        [JsonStringEnumMemberName("endpoint")]
        Endpoint,
        [JsonStringEnumMemberName("si")]
        Si,
        [JsonStringEnumMemberName("email")]
        Email,
        [JsonStringEnumMemberName("si_local")]
        SiLocal,
        [JsonStringEnumMemberName("si_peppol")]
        SiPeppol,
        [JsonStringEnumMemberName("api")]
        Api,
        [JsonStringEnumMemberName("moneybird_bv")]
        MoneybirdBv,
        [JsonStringEnumMemberName("mollie")]
        Mollie
    }
}