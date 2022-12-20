using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.GeneralDocuments.Models;
using Moneybird.Net.Entities.GeneralDocuments;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.GeneralDocuments
{
    public class GeneralDocumentEndpoint : IGeneralDocumentEndpoint
    {
        private const string DocumentsUri = "/{0}/documents/general_documents.json";
        private const string DocumentsIdUri = "/{0}/documents/general_documents/{1}.json";
        private const string DocumentsSynchronizationUri = "/{0}/documents/general_documents/synchronization.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public GeneralDocumentEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }

        public async Task<IEnumerable<GeneralDocument>> GetDocumentsAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(DocumentsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<GeneralDocument>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<GeneralSynchronizationDocument>> GetSynchronizationDocumentsAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(DocumentsSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<GeneralSynchronizationDocument>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<GeneralDocument>> GetDocumentsByIdsAsync(string administrationId, string accessToken, GeneralDocumentListOptions options)
        {
            var relativeUrl = string.Format(DocumentsSynchronizationUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<GeneralDocument>>(responseJson, _config.SerializerOptions);
        }

        public async Task<GeneralDocument> GetDocumentByIdAsync(string administrationId, string documentId, string accessToken)
        {
            var relativeUrl = string.Format(DocumentsIdUri, administrationId, documentId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<GeneralDocument>(responseJson, _config.SerializerOptions);
        }
    }
}