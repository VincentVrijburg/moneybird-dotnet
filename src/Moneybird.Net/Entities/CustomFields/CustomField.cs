using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.CustomFields
{
    public class CustomField
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("source")]
        public CustomFieldSource CustomFieldSource { get; set; }
    }
}
