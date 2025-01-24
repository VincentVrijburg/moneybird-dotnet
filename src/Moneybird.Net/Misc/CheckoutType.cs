using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CheckoutType
    {
        [JsonStringEnumMemberName("product")]
        Product,
        
        [JsonStringEnumMemberName("subscription")]
        Subscription
    }
}
