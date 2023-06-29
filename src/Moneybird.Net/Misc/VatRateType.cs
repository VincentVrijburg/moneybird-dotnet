using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum VatRateType
    {
        [JsonPropertyName("standard")]
        Standard,
        
        [JsonPropertyName("reduced")]
        Reduced
    }
}
