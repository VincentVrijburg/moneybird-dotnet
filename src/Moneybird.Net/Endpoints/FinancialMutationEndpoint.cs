using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.FinancialMutations;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.FinancialMutations;

namespace Moneybird.Net.Endpoints
{
    public class FinancialMutationEndpoint : IFinancialMutationEndpoint
    {
        private const string FinancialMutationsUri = "/{0}/financial_mutations.json";
        private const string FinancialMutationsIdUri = "/{0}/financial_mutations/{1}.json";
        private const string FinancialMutationsSynchronizationUri = "/{0}/financial_mutations/synchronization.json";
        private const string FinancialMutationsIdLinkBookingUri = "/{0}/financial_mutations/{1}/link_booking.json";
        private const string FinancialMutationsIdUnlinkBookingUri = "/{0}/financial_mutations/{1}/unlink_booking.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public FinancialMutationEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<IEnumerable<FinancialMutation>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(FinancialMutationsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<FinancialMutation>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<FinancialMutation>> GetAsync(
            string administrationId,
            string accessToken,
            FinancialMutationFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };

            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add(filterString);
            }

            var relativeUrl = string.Format(FinancialMutationsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<FinancialMutation>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<SynchronizationFinancialMutation>> GetSynchronizationFinancialMutationsAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(FinancialMutationsSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SynchronizationFinancialMutation>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<SynchronizationFinancialMutation>> GetSynchronizationFinancialMutationsAsync(
            string administrationId,
            string accessToken,
            FinancialMutationFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };

            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add(filterString);
            }

            var relativeUrl = string.Format(FinancialMutationsSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SynchronizationFinancialMutation>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<FinancialMutation>> GetFinancialMutationsByIdsAsync(
            string administrationId,
            string accessToken,
            FinancialMutationListOptions options)
        {
            var relativeUrl = string.Format(FinancialMutationsSynchronizationUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<FinancialMutation>>(responseJson, _config.SerializerOptions);
        }

        public async Task<FinancialMutation> GetByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(FinancialMutationsIdUri, administrationId, id);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<FinancialMutation>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> LinkBookingAsync(
            string administrationId,
            string financialMutationId,
            FinancialMutationLinkBookingOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(FinancialMutationsIdLinkBookingUri, administrationId, financialMutationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            var responseCode = JsonSerializer.Deserialize<int>(responseJson, _config.SerializerOptions);
            return responseCode == 200;
        }

        public async Task<FinancialMutation> UnlinkBookingAsync(
            string administrationId,
            string financialMutationId,
            FinancialMutationUnlinkBookingOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(FinancialMutationsIdUnlinkBookingUri, administrationId, financialMutationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<FinancialMutation>(responseJson, _config.SerializerOptions);
        }
    }
}
