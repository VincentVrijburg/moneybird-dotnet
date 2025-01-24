using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.SalesInvoices
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SalesInvoiceState
    {
        [JsonStringEnumMemberName("all")]
        All,
        
        [JsonStringEnumMemberName("draft")]
        Draft,
        
        [JsonStringEnumMemberName("open")]
        Open,
        
        [JsonStringEnumMemberName("scheduled")]
        Scheduled,
        
        [JsonStringEnumMemberName("pending_payment")]
        PendingPayment,
        
        [JsonStringEnumMemberName("late")]
        Late,
        
        [JsonStringEnumMemberName("reminded")]
        Reminded,
        
        [JsonStringEnumMemberName("paid")]
        Paid,
        
        [JsonStringEnumMemberName("uncollectible")]
        Uncollectible,
    }
}
