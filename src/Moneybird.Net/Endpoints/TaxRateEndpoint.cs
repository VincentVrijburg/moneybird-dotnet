using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.TaxRates;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.TaxRates;

namespace Moneybird.Net.Endpoints
{
    public class TaxRateEndpoint : ITaxRateEndpoint
    {
        private const string TaxRatesUri = "/{0}/tax_rates.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public TaxRateEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<TaxRate>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(TaxRatesUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<TaxRate>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<TaxRate>> GetAsync(
            string administrationId,
            string accessToken,
            TaxRateFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
                        
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add($"filter={filterString}");
            }
            
            var relativeUrl = string.Format(TaxRatesUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<TaxRate>>(responseJson, _config.SerializerOptions);
        }
    }
}
