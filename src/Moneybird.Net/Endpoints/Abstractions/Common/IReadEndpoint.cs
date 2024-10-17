using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities;

namespace Moneybird.Net.Endpoints.Abstractions.Common
{
    public interface IReadEndpoint<TMoneybirdEntity> where TMoneybirdEntity : IMoneybirdEntity
    {
        /// <summary>
        /// Get a list of all the entities within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="page">The page number of the entities. Defaults to 1.</param>
        /// <param name="perPage">The amount of entities per page. Defaults to 50.</param>
        /// <returns>A list of entity objects.</returns>
        public Task<IEnumerable<TMoneybirdEntity>> GetAsync(string administrationId, string accessToken, int page = 1, int perPage = 50);
    }
}
