using System.Text.Json.Serialization;

// ReSharper disable IdentifierTypo

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DeliveryMethod
    {
        Email,
        Simplerinvoicing,
        Post,
        Manual
    }
}