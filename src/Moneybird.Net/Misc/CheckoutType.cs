using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CheckoutType
    {
        [JsonPropertyName("product")]
        Product,
        
        [JsonPropertyName("subscription")]
        Subscription
    }
}
