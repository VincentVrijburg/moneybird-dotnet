using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialMutations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FinancialMutationSettlementState
    {
        [JsonStringEnumMemberName("authorised")]
        Authorised,
        [JsonStringEnumMemberName("cancelled")]
        Cancelled,
        [JsonStringEnumMemberName("expired")]
        Expired,
        [JsonStringEnumMemberName("settled")]
        Settled,
        [JsonStringEnumMemberName("pending")]
        Pending,
        [JsonStringEnumMemberName("refused")]
        Refused,
        [JsonStringEnumMemberName("error")]
        Error,
        [JsonStringEnumMemberName("captured")]
        Captured,
        [JsonStringEnumMemberName("failed")]
        Failed,
        [JsonStringEnumMemberName("returned")]
        Returned
    }
}