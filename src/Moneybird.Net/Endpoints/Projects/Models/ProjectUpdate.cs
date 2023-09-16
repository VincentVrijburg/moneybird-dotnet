using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Projects.Models
{
    public class ProjectUpdate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("budget")]
        public string Budget { get; set; }
    }
}