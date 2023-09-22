using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialAccounts
{
    public class FinancialAccount : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
        
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        [JsonPropertyName("provider")]
        public string Provider { get; set; }
        
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}