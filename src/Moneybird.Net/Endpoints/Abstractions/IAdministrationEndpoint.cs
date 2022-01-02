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
        /// <returns>A list of administration objects.</returns>
        Task<List<Administration>> GetAdministrationsAsync(string accessToken);
    }
}