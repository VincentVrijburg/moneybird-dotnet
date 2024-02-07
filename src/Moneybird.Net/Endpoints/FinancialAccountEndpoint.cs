using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.FinancialAccounts;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints
{
    public class FinancialAccountEndpoint : IFinancialAccountEndpoint
    {
        private const string FinancialAccountsUri = "/{0}/financial_accounts.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public FinancialAccountEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }
        
        public async Task<IEnumerable<FinancialAccount>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(FinancialAccountsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<FinancialAccount>>(responseJson, _config.SerializerOptions);
        }
    }
}