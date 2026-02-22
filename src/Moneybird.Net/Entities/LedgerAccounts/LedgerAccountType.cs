using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.LedgerAccounts
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LedgerAccountType
    {
        [JsonStringEnumMemberName("non_current_assets")]
        NonCurrentAssets,
        [JsonStringEnumMemberName("current_assets")]
        CurrentAssets,
        [JsonStringEnumMemberName("equity")]
        Equity,
        [JsonStringEnumMemberName("non_current_liabilities")]
        NonCurrentLiabilities,
        [JsonStringEnumMemberName("current_liabilities")]
        CurrentLiabilities,
        [JsonStringEnumMemberName("revenue")]
        Revenue,
        [JsonStringEnumMemberName("direct_costs")]
        DirectCosts,
        [JsonStringEnumMemberName("expenses")]
        Expenses,
        [JsonStringEnumMemberName("other_income_expenses")]
        OtherIncomeExpenses,
        [JsonStringEnumMemberName("other")]
        Other,
        [JsonStringEnumMemberName("temporary")]
        Temporary,
        [JsonStringEnumMemberName("provisions")]
        Provisions
    }
}
