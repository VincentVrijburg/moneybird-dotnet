using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FrequencyType
    {
        [JsonPropertyName("day")]
        Day,

        [JsonPropertyName("week")]
        Week,

        [JsonPropertyName("month")]
        Month,

        [JsonPropertyName("quarter")]
        Quarter,

        [JsonPropertyName("year")]
        Year
    }
}
