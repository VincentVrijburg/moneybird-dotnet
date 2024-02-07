using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Projects
{
    public class ProjectUpdate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("budget")]
        public string Budget { get; set; }
    }
}