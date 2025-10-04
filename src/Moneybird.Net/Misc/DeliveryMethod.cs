using System.Text.Json.Serialization;

// ReSharper disable IdentifierTypo

namespace Moneybird.Net.Misc
{
    /// <summary>
    /// Delivery method.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DeliveryMethod
    {
        [JsonStringEnumMemberName("Email")]
        Email,
        [JsonStringEnumMemberName("Simplerinvoicing")]
        Simplerinvoicing,
        [JsonStringEnumMemberName("Post")]
        Post,
        [JsonStringEnumMemberName("Manual")]
        Manual
    }
}