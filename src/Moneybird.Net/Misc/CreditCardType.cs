using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    /// <summary>
    /// Credit Card type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CreditCardType
    {
        [JsonStringEnumMemberName("mastercard")]
        Mastercard,
        [JsonStringEnumMemberName("visa")]
        Visa
    }
}