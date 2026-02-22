using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Workflows
{
    public class Workflow : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }
        
        [JsonPropertyName("type")]
        public WorkflowType Type { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("default")]
        public bool Default { get; set; }
        
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        [JsonPropertyName("language")]
        public string Language { get; set; }
        
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        
        [JsonPropertyName("prices_are_incl_tax")]
        public bool PricesAreInclTax { get; set; }
        
        [JsonPropertyName("steps")]
        public List<WorkflowSteps> Steps { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
