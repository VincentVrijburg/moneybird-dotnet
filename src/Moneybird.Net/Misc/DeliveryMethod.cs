using System.Text.Json.Serialization;

// ReSharper disable IdentifierTypo

namespace Moneybird.Net.Misc
{
    /// <summary>
    /// Delivery method.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum DeliveryMethod
    {
        [JsonPropertyName("Email")]
        Email,
        [JsonPropertyName("Simplerinvoicing")]
        Simplerinvoicing,
        [JsonPropertyName("Post")]
        Post,
        [JsonPropertyName("Manual")]
        Manual
    }
}