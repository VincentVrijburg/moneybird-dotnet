using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.TaxRates;
using Moneybird.Net.Entities.Users;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ITaxRateEndpoint
    {
        /// <summary>
        /// Get list of all the tax rates.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A list of tax rates.</returns>
        Task<List<TaxRate>> GetTaxRates(string administrationId, string accessToken);
    }
}
