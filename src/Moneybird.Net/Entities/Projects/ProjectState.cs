using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Projects
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProjectState
    {
        [JsonStringEnumMemberName("active")]
        Active,
     
        [JsonStringEnumMemberName("all")]
        All,
        
        [JsonStringEnumMemberName("archived")]
        Archived
    }
}