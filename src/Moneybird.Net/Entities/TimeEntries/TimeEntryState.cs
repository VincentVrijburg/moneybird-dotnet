using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.TimeEntries
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TimeEntryState
    {
        [JsonStringEnumMemberName("all")]
        All,
        
        [JsonStringEnumMemberName("open")]
        Open,
        
        [JsonStringEnumMemberName("non_billable")]
        NonBillable,
    }
}