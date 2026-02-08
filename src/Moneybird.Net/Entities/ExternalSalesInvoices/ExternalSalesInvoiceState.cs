using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.ExternalSalesInvoices
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExternalSalesInvoiceState
    {
        [JsonStringEnumMemberName("all")]
        All,
        [JsonStringEnumMemberName("new")]
        New,
        [JsonStringEnumMemberName("open")]
        Open,
        [JsonStringEnumMemberName("late")]
        Late,
        [JsonStringEnumMemberName("paid")]
        Paid,
        [JsonStringEnumMemberName("uncollectible")]
        Uncollectible,
        [JsonStringEnumMemberName("pending_payment")]
        PendingPayment
    }
}
