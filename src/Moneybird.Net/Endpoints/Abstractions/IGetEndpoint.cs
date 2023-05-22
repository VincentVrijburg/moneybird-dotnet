using System.Threading.Tasks;
using Moneybird.Net.Entities;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IGetEndpoint<TMoneybirdEntity> where TMoneybirdEntity : IMoneybirdEntity
    {
        /// <summary>
        /// Retrieve an entity by id within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="entityId">The entity id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>An object of a single entity.</returns>
        Task<TMoneybirdEntity> GetByIdAsync(string administrationId, string entityId, string accessToken);
    }
}
