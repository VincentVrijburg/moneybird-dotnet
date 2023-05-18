using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.LegderAccounts.Models;
using Moneybird.Net.Entities.LedgerAccounts;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.LegderAccounts
{
    public class LedgerAccountEndpoint : ILedgerAccountEndpoint
    {
        private const string LedgerAccountsUri = "/{0}/ledger_accounts.json";
        private const string LedgerAccountsIdUri = "/{0}/ledger_accounts/{1}.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public LedgerAccountEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }

        public async Task<List<LedgerAccount>> GetLedgerAccountsAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(LedgerAccountsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<List<LedgerAccount>>(responseJson, _config.SerializerOptions);
        }

        public async Task<LedgerAccount> GetLedgerAccountByIdAsync(string administrationId, string ledgerAccountId, string accessToken)
        {
            var relativeUrl = string.Format(LedgerAccountsIdUri, administrationId, ledgerAccountId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<LedgerAccount>(responseJson, _config.SerializerOptions);
        }

        public async Task<LedgerAccount> CreateLedgerAccountAsync(string administrationId, LedgerAccountCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(LedgerAccountsUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<LedgerAccount>(responseJson, _config.SerializerOptions);
        }

        public async Task<LedgerAccount> UpdateLedgerAccountByIdAsync(string administrationId, string ledgerAccountId, LedgerAccountUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(LedgerAccountsIdUri, administrationId, ledgerAccountId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<LedgerAccount>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<bool> DeleteLedgerAccountByIdAsync(string administrationId, string ledgerAccountId, string accessToken)
        {
            var relativeUrl = string.Format(LedgerAccountsIdUri, administrationId, ledgerAccountId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}
