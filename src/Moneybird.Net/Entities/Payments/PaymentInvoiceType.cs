using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Payments
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentInvoiceType
    {
        [JsonStringEnumMemberName("SalesInvoice")]
        SalesInvoice,
        [JsonStringEnumMemberName("Document")]
        Document,
        [JsonStringEnumMemberName("ExternalSalesInvoice")]
        ExternalSalesInvoice,
        [JsonStringEnumMemberName("VatDocument")]
        VatDocument
    }
}