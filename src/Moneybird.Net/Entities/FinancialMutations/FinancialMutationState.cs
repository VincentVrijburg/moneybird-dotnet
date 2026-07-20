using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialMutations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FinancialMutationState
    {
        [JsonStringEnumMemberName("all")]
        All,

        [JsonStringEnumMemberName("unprocessed")]
        Unprocessed,

        [JsonStringEnumMemberName("auto_booked")]
        AutoBooked,

        [JsonStringEnumMemberName("processed")]
        Processed
    }
}