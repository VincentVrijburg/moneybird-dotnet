using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Endpoints.LegderAccounts.Models
{
    public class LedgerAccountCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("ledger_account")]
        public LedgerAccountCreate LedgerAccount { get; set; }
    }
}
