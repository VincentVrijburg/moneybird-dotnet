using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.SalesInvoices
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum SalesInvoicePeriod
    {
        [JsonPropertyName("this_month")]
        ThisMonth,
        
        [JsonPropertyName("prev_month")]
        PreviousMonth,
        
        [JsonPropertyName("next_month")]
        NextMonth,
        
        [JsonPropertyName("this_quarter")]
        ThisQuarter,
        
        [JsonPropertyName("prev_quarter")]
        PreviousQuarter,
        
        [JsonPropertyName("next_quarter")]
        NextQuarter,
        
        [JsonPropertyName("this_year")]
        ThisYear,
        
        [JsonPropertyName("prev_year")]
        PreviousYear,
        
        [JsonPropertyName("next_year")]
        NextYear,
    }
}
