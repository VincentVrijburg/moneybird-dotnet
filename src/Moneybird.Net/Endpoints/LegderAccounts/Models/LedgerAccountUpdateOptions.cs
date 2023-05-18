using System.Text.Json.Serialization;

namespace Moneybird.Net.Endpoints.LegderAccounts.Models
{
    public class LedgerAccountUpdateOptions
    {
        [JsonPropertyName("ledger_account")]
        public LedgerAccountUpdate LedgerAccount { get; set; }
    }
}
