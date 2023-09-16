using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Projects
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ProjectState
    {
        [JsonPropertyName("active")]
        Active,
     
        [JsonPropertyName("all")]
        All,
        
        [JsonPropertyName("archived")]
        Archived
    }
}