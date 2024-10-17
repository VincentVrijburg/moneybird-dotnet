using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.Administrations;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IAdministrationEndpoint
    {
        /// <summary>
        /// Get list of all the administrations by access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="page">The page number of the administrations. Defaults to 1.</param>
        /// <param name="perPage">The amount of administrations per page. Defaults to 50.</param>
        /// <returns>A list of administration objects.</returns>
        Task<IEnumerable<Administration>> GetAsync(string accessToken, int page = 1, int perPage = 50);
    }
}
