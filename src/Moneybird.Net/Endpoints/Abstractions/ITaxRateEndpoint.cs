using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.TaxRates.Models;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.TaxRates;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ITaxRateEndpoint : IReadEndpoint<TaxRate>
    {
        /// <summary>
        /// Get list of all the tax rates with filter options.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="options">The filter options.</param>
        /// <returns>A list of tax rates.</returns>
        Task<List<TaxRate>> GetTaxRatesAsync(string administrationId, string accessToken, TaxRateFilterOptions options);
    }
}
