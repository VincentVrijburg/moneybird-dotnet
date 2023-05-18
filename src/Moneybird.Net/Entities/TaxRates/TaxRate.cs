using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.TaxRates
{
    public class TaxRate
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("partial_name")]
        public string PartialName { get; set; }

        [JsonPropertyName("percentage")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Percentage { get; set; }

        [JsonPropertyName("tax_rate_type")]
        public TaxRateType TaxRateType { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("show_tax")]
        public bool ShowTax { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("created_after")]
        public string CreatedAfter { get; set; }

        [JsonPropertyName("updated_after")]
        public string UpdatedAfter { get; set; }
    }
}
