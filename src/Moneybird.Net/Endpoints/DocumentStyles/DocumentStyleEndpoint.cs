using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.DocumentStyles;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.DocumentStyles
{
    public class DocumentStyleEndpoint : IDocumentStyleEndpoint
    {
        private const string DocumentStylesUri = "/{0}/document_styles.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public DocumentStyleEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<List<DocumentStyle>> GetDocumentStylesAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(DocumentStylesUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<List<DocumentStyle>>(responseJson, _config.SerializerOptions);
        }
    }
}