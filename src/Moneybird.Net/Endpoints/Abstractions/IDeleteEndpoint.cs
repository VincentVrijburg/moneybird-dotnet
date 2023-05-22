using System.Threading.Tasks;
using Moneybird.Net.Entities;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IDeleteEndpoint
    {
        /// <summary>
        /// Delete an entity by id within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="entityId">The entity id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A boolean result.</returns>
        Task<bool> DeleteByIdAsync(string administrationId, string entityId, string accessToken);
    }
}
