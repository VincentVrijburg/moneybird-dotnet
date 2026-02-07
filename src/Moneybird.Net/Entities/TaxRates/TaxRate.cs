using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.TaxRates
{
    public class TaxRate : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("percentage")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? Percentage { get; set; }

        [JsonPropertyName("tax_rate_type")]
        public TaxRateType TaxRateType { get; set; }

        [JsonPropertyName("show_tax")]
        public bool? ShowTax { get; set; }

        [JsonPropertyName("active")]
        public bool? Active { get; set; }
        
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
