using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialMutations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FinancialMutationState
    {
        [JsonStringEnumMemberName("unprocessed")]
        Unprocessed,
        [JsonStringEnumMemberName("processed")]
        Processed
    }
}