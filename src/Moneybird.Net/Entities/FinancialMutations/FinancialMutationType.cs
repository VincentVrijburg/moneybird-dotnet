using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialMutations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FinancialMutationType
    {
        [JsonStringEnumMemberName("all")]
        All,

        [JsonStringEnumMemberName("debit")]
        Debit,

        [JsonStringEnumMemberName("credit")]
        Credit
    }
}
