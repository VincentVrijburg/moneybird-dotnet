using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.FinancialStatements.Models;
using Moneybird.Net.Entities.FinancialStatements;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.FinancialStatements
{
    public class FinancialStatementEndpoint : IFinancialStatementEndpoint
    {
        private const string FinancialStatementsUri = "/{0}/financial_statements.json";
        private const string FinancialStatementsIdUri = "/{0}/financial_statements/{1}.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public FinancialStatementEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }
        
        public async Task<FinancialStatement> CreateAsync(string administrationId, FinancialStatementCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(FinancialStatementsUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);

            var response = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<FinancialStatement>(response, _config.SerializerOptions);
        }

        public async Task<FinancialStatement> UpdateByIdAsync(string administrationId, string financialStatementId, FinancialStatementUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(FinancialStatementsIdUri, administrationId, financialStatementId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<FinancialStatement>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string financialStatementId, string accessToken)
        {
            var relativeUrl = string.Format(FinancialStatementsIdUri, administrationId, financialStatementId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}