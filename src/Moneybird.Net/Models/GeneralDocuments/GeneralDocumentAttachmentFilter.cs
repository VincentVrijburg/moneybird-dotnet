using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.GeneralDocuments;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GeneralDocumentAttachmentFilter
{
    [JsonStringEnumMemberName("all")]
    All,

    [JsonStringEnumMemberName("with")]
    With,

    [JsonStringEnumMemberName("without")]
    Without
}
