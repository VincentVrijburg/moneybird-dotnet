using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Subscriptions
{
    public class SubscriptionCreate
    {
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }
        
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        
        [JsonPropertyName("discount")]
        public decimal? Discount { get; set; }
        
        [JsonPropertyName("contact_id")]
        public long? ContactId { get; set; }
        
        [JsonPropertyName("contact_person_id")]
        public long? ContactPersonId { get; set; }
        
        [JsonPropertyName("start_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        
        [JsonPropertyName("document_style_id")]
        public string DocumentStyleId { get; set; }
        
        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }
        
        [JsonPropertyName("frequency_type")]
        public string FrequencyType { get; set; }
        
        [JsonPropertyName("mergeable")]
        public bool Mergeable { get; set; }
        
        [JsonPropertyName("prices_are_incl_tax")]
        public bool PricesAreInclTax { get; set; }
    }
}