using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.PurchaseTransactions;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.PurchaseTransactions;

namespace Moneybird.Net.Endpoints
{
    public class PurchaseTransactionEndpoint : IPurchaseTransactionEndpoint
    {
        private const string PurchaseTransactionsUri = "/{0}/purchase_transactions.json";
        private const string PurchaseTransactionsIdUri = "/{0}/purchase_transactions/{1}.json";
        private const string SepaCreditTransferUri = "/{0}/sepa_credit_transfer.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public PurchaseTransactionEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<IEnumerable<PurchaseTransaction>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(PurchaseTransactionsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<PurchaseTransaction>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<PurchaseTransaction>> GetAsync(
            string administrationId,
            string accessToken,
            PurchaseTransactionFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };

            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add(filterString);
            }

            var relativeUrl = string.Format(PurchaseTransactionsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<PurchaseTransaction>>(responseJson, _config.SerializerOptions);
        }

        public async Task<PurchaseTransaction> GetByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(PurchaseTransactionsIdUri, administrationId, id);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<PurchaseTransaction>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(PurchaseTransactionsIdUri, administrationId, id);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<IEnumerable<PurchaseTransactionBatch>> UploadSepaCreditTransferAsync(
            string administrationId,
            Stream body,
            string accessToken,
            PurchaseTransactionSepaCreditTransferOptions options = null)
        {
            var relativeUrl = string.Format(SepaCreditTransferUri, administrationId);
            var formFields = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(options?.LedgerAccountId))
            {
                formFields["ledger_account_id"] = options.LedgerAccountId;
            }

            if (!string.IsNullOrEmpty(options?.FinancialAccountId))
            {
                formFields["financial_account_id"] = options.FinancialAccountId;
            }

            var responseJson = await _requester
                .CreatePostMultipartFormRequestAsync(
                    _config.ApiUri,
                    relativeUrl,
                    accessToken,
                    body,
                    formFields.Any() ? formFields : null)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<PurchaseTransactionBatch>>(responseJson, _config.SerializerOptions);
        }
    }
}
