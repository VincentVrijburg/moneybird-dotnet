using System;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Products;

namespace Moneybird.Net.Entities.Subscriptions
{
    public class SubscriptionProduct
    {
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("product")]
        public Product Product { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("discount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Discount { get; set; }
    }
}