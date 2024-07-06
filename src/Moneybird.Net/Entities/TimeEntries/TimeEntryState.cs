using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.TimeEntries
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum TimeEntryState
    {
        [JsonPropertyName("all")]
        All,
        
        [JsonPropertyName("open")]
        Open,
        
        [JsonPropertyName("non_billable")]
        NonBillable,
    }
}