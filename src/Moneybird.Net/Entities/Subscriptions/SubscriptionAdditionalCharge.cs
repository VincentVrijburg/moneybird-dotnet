using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Subscriptions
{
    public class SubscriptionAdditionalCharge : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonPropertyName("subscription_id")]
        public string SubscriptionId { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("detail_id")]
        public string DetailId { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("price")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Price { get; set; }

        [JsonPropertyName("period")]
        public string Period { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}