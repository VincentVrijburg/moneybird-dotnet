using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.GeneralDocuments.Models;
using Moneybird.Net.Entities.GeneralDocuments;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IGeneralDocumentEndpoint
    {
        Task<IEnumerable<GeneralDocument>> GetDocumentsAsync(string administrationId, string accessToken);
        Task<IEnumerable<GeneralSynchronizationDocument>> GetSynchronizationDocumentsAsync(string administrationId, string accessToken);
        Task<IEnumerable<GeneralDocument>> GetDocumentsByIdsAsync(string administrationId, string accessToken, GeneralDocumentListOptions options);
        Task<GeneralDocument> GetDocumentByIdAsync(string administrationId, string documentId, string accessToken);
    }
}