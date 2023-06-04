using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Endpoints.LegderAccounts.Models
{
    public class LedgerAccountUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("ledger_account")]
        public LedgerAccountUpdate LedgerAccount { get; set; }
    }
}
