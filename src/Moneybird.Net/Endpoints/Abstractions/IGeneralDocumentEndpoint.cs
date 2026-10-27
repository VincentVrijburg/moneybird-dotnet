using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.GeneralDocuments;
using Moneybird.Net.Models.GeneralDocuments;

namespace Moneybird.Net.Endpoints.Abstractions;

public interface IGeneralDocumentEndpoint :
    IReadEndpoint<GeneralDocument>,
    IReadFilterEndpoint<GeneralDocument, GeneralDocumentFilterOptions>,
    IGetEndpoint<GeneralDocument>,
    ICreateEndpoint<GeneralDocument, GeneralDocumentCreateOptions>,
    IUpdateEndpoint<GeneralDocument, GeneralDocumentUpdateOptions>,
    IDeleteEndpoint
{
}
