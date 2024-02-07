using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.LedgerAccounts
{
    public class LedgerAccountUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("ledger_account")]
        public LedgerAccountUpdate LedgerAccount { get; set; }
    }
}
