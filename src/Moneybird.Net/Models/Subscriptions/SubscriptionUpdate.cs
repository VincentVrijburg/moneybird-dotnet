using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Subscriptions
{
    public class SubscriptionUpdate
    {
        [JsonPropertyName("contact_person_id")]
        public string ContactPersonId { get; set; }

        [JsonPropertyName("document_style_id")]
        public string DocumentStyleId { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("mergeable")]
        public bool? Mergeable { get; set; }

        [JsonPropertyName("prices_are_incl_tax")]
        public bool? PricesAreInclTax { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("discount")]
        public decimal? Discount { get; set; }
    }
}