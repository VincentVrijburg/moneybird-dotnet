using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.GeneralDocuments;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.GeneralDocuments
{
    public class GeneralDocumentEndpoint : IGeneralDocumentEndpoint
    {
        private const string DocumentsSynchronizationUri = "/{0}/documents/general_documents/synchronization.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public GeneralDocumentEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<GeneralSynchronizationDocument>> GetSynchronizationDocumentsAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(DocumentsSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<GeneralSynchronizationDocument>>(responseJson, _config.SerializerOptions);
        }
    }
}