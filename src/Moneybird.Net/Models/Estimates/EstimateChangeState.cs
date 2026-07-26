using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Estimates
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstimateChangeState
    {
        [JsonStringEnumMemberName("accepted")]
        Accepted,
        
        [JsonStringEnumMemberName("rejected")]
        Rejected,
        
        [JsonStringEnumMemberName("open")]
        Open,
        
        [JsonStringEnumMemberName("late")]
        Late,
        
        [JsonStringEnumMemberName("billed")]
        Billed,
        
        [JsonStringEnumMemberName("archived")]
        Archived
    }
}
