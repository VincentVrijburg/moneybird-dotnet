using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Estimates
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstimateState
    {
        [JsonStringEnumMemberName("all")]
        All,
        
        [JsonStringEnumMemberName("draft")]
        Draft,
        
        [JsonStringEnumMemberName("open")]
        Open,
        
        [JsonStringEnumMemberName("late")]
        Late,
        
        [JsonStringEnumMemberName("accepted")]
        Accepted,
        
        [JsonStringEnumMemberName("rejected")]
        Rejected,
        
        [JsonStringEnumMemberName("billed")]
        Billed,
        
        [JsonStringEnumMemberName("archived")]
        Archived
    }
}
