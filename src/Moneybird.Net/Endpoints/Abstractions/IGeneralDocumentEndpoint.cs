using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Entities.GeneralDocuments;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IGeneralDocumentEndpoint
    {
        /// <summary>
        /// Get list of all the document styles by access token.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A list of objects containing document ids and versions.</returns>
        Task<IEnumerable<GeneralSynchronizationDocument>> GetSynchronizationDocumentsAsync(string administrationId, string accessToken);
    }
}