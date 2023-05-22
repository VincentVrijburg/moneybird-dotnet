using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.LedgerAccounts;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.LegderAccounts
{
    public class LedgerAccountEndpoint : ILedgerAccountEndpoint
    {
        private const string LedgerAccountsUri = "/{0}/ledger_accounts.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public LedgerAccountEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }

        public async Task<IEnumerable<LedgerAccount>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(LedgerAccountsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<LedgerAccount>>(responseJson, _config.SerializerOptions);
        }
    }
}
