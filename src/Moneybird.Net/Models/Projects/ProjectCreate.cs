using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Projects
{
    public class ProjectCreate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("budget")]
        public string Budget { get; set; }
    }
}