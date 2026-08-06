using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.Subscriptions;

public class SubscriptionAdditionalChargeCreate
{
    [JsonPropertyName("product_id")]
    public string ProductId { get; set; }

    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("price")]
    public double? Price { get; set; }

    [JsonPropertyName("period")]
    public string Period { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
