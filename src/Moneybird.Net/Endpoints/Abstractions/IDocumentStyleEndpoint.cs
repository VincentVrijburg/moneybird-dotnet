using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.DocumentStyles;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IDocumentStyleEndpoint
    {
        /// <summary>
        /// Get list of all the document styles by access token.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A list of document style objects.</returns>
        Task<List<DocumentStyle>> GetDocumentStylesAsync(string administrationId, string accessToken);
    }
}