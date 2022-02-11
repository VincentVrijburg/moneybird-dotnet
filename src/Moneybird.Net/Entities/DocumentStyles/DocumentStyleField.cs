using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.DocumentStyles
{
    public class DocumentStyleField
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }
        
        [JsonPropertyName("bold")]
        public bool? Bold { get; set; }
        
        [JsonPropertyName("label")]
        public bool? Label { get; set; }
    }
}