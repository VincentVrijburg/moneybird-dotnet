using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.GeneralDocuments;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GeneralDocumentRecurringFilter
{
    [JsonStringEnumMemberName("all")]
    All,

    [JsonStringEnumMemberName("enabled")]
    Enabled,

    [JsonStringEnumMemberName("disabled")]
    Disabled
}
