using System.Threading.Tasks;

namespace Moneybird.Net.Endpoints.Abstractions.Common
{
    public interface IDeleteEndpoint
    {
        /// <summary>
        /// Delete an entity by id within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="id">The entity id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A boolean result.</returns>
        Task<bool> DeleteByIdAsync(string administrationId, string id, string accessToken);
    }
}
