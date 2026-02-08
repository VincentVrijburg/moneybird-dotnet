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
        
        [JsonStringEnumMemberName("scheduled")]
        Scheduled,
        
        [JsonStringEnumMemberName("open")]
        Open,
        
        [JsonStringEnumMemberName("pending_payment")]
        PendingPayment,
        
        [JsonStringEnumMemberName("reminded")]
        Reminded,
        
        [JsonStringEnumMemberName("late")]
        Late,
        
        [JsonStringEnumMemberName("paid")]
        Paid,
        
        [JsonStringEnumMemberName("uncollectible")]
        Uncollectible,
    }
}
