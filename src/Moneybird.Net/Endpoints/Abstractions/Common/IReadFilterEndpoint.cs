using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities;

namespace Moneybird.Net.Endpoints.Abstractions.Common
{
    public interface IReadFilterEndpoint<TMoneybirdEntity, TMoneybirdFilterOptions> 
        where TMoneybirdEntity : IMoneybirdEntity 
        where TMoneybirdFilterOptions : IMoneybirdFilterOptions
    {
        /// <summary>
        /// Get list of all the entities with filter options within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="options">The filter options.</param>
        /// <param name="page">The page number of the entities. Defaults to 1.</param>
        /// <param name="perPage">The amount of entities per page. Defaults to 50.</param>
        /// <returns></returns>
        Task<IEnumerable<TMoneybirdEntity>> GetAsync(string administrationId, string accessToken, TMoneybirdFilterOptions options, int page = 1, int perPage = 50);
    }
}