using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities;

namespace Moneybird.Net.Endpoints.Abstractions.Common
{
    public interface ICreateEndpoint<TMoneybirdEntity, TMoneybirdCreateOptions> 
        where TMoneybirdEntity : IMoneybirdEntity 
        where TMoneybirdCreateOptions : IMoneybirdCreateOptions
    {
        /// <summary>
        /// Create a new entity with a create model within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="options">The options to create the entity with.</param>
        /// <param name="accessToken">The access token.</param>
        Task<TMoneybirdEntity> CreateAsync(string administrationId, TMoneybirdCreateOptions options, string accessToken);
    }
}