using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.Projects.Models
{
    public class ProjectCreate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("budget")]
        public string Budget { get; set; }
    }
}