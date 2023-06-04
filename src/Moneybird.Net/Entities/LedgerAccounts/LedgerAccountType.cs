using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.LedgerAccounts
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum LedgerAccountType
    {
        [JsonPropertyName("non_current_assets")]
        NonCurrentAssets,

        [JsonPropertyName("current_assets")]
        CurrentAssets,

        [JsonPropertyName("equity")]
        Equity,

        [JsonPropertyName("provisions")]
        Provisions,

        [JsonPropertyName("non_current_liabilities")]
        NonCurrentLiabilities,

        [JsonPropertyName("current_liabilities")]
        CurrentLiabilities,

        [JsonPropertyName("revenue")]
        Revenue,

        [JsonPropertyName("direct_costs")]
        DirectCosts,

        [JsonPropertyName("expenses")]
        Expenses,

        [JsonPropertyName("other_income_expenses")]
        OtherIncomeExpenses
    }
}
