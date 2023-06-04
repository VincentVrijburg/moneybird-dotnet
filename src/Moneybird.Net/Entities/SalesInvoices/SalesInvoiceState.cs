using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.SalesInvoices
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum SalesInvoiceState
    {
        [JsonPropertyName("all")]
        All,
        
        [JsonPropertyName("draft")]
        Draft,
        
        [JsonPropertyName("open")]
        Open,
        
        [JsonPropertyName("scheduled")]
        Scheduled,
        
        [JsonPropertyName("pending_payment")]
        PendingPayment,
        
        [JsonPropertyName("late")]
        Late,
        
        [JsonPropertyName("reminded")]
        Reminded,
        
        [JsonPropertyName("paid")]
        Paid,
        
        [JsonPropertyName("uncollectible")]
        Uncollectible,
    }
}
