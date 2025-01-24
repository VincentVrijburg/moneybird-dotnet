using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VatRateType
    {
        [JsonStringEnumMemberName("standard")]
        Standard,
        
        [JsonStringEnumMemberName("reduced")]
        Reduced
    }
}
