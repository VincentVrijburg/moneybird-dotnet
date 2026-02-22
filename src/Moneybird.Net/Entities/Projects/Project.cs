using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Projects
{
    public class Project : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("state")]
        public ProjectState State { get; set; }
        
        [JsonPropertyName("budget")]
        public int? Budget { get; set; }
    }
}