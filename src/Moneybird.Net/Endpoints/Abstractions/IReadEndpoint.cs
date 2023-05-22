using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moneybird.Net.Entities;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IReadEndpoint<TMoneybirdEntity> where TMoneybirdEntity : IMoneybirdEntity
    {
        /// <summary>
        /// Get a list of all the entities within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A list of entity objects.</returns>
        public Task<IEnumerable<TMoneybirdEntity>> GetAsync(string administrationId, string accessToken);
    }
}
