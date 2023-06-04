using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Models;
using Moneybird.Net.Entities;

namespace Moneybird.Net.Endpoints.Abstractions.Common
{
    public interface IUpdateEndpoint<TMoneybirdEntity, TMoneybirdUpdateOptions> 
        where TMoneybirdEntity : IMoneybirdEntity 
        where TMoneybirdUpdateOptions : IMoneybirdUpdateOptions
    {
        /// <summary>
        /// Update an entity within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="entityId">The entity id to update.</param>
        /// <param name="options">the options to update with.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The updated entity.</returns>
        Task<TMoneybirdEntity> UpdateByIdAsync(string administrationId, string entityId, TMoneybirdUpdateOptions options, string accessToken);
    }
}