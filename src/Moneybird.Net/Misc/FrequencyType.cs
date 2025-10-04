using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FrequencyType
    {
        [JsonStringEnumMemberName("day")]
        Day,

        [JsonStringEnumMemberName("week")]
        Week,

        [JsonStringEnumMemberName("month")]
        Month,

        [JsonStringEnumMemberName("quarter")]
        Quarter,

        [JsonStringEnumMemberName("year")]
        Year
    }
}
