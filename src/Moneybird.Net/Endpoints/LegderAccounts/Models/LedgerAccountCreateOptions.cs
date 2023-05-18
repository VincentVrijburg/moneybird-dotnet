using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.LegderAccounts.Models
{
    public class LedgerAccountCreateOptions
    {
        [JsonPropertyName("ledger_account")]
        public LedgerAccountCreate LedgerAccount { get; set; }
    }
}
