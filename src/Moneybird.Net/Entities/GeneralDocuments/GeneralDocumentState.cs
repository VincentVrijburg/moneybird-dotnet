using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.GeneralDocuments;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GeneralDocumentState
{
    [JsonStringEnumMemberName("new")]
    New,

    [JsonStringEnumMemberName("open")]
    Open,

    [JsonStringEnumMemberName("late")]
    Late,

    [JsonStringEnumMemberName("paid")]
    Paid,

    [JsonStringEnumMemberName("saved")]
    Saved,

    [JsonStringEnumMemberName("pending_payment")]
    PendingPayment,

    [JsonStringEnumMemberName("all")]
    All
}
