using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.LedgerAccounts
{
    public class LedgerAccountCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("ledger_account")]
        public LedgerAccountCreate LedgerAccount { get; set; }
    }
}
