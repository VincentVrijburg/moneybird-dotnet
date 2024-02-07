using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Webhooks;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Webhooks;

namespace Moneybird.Net.Endpoints
{
    public class WebhookEndpoint : IWebhookEndpoint
    {
        private const string WebhooksUri = "/{0}/webhooks.json";
        private const string WebhooksIdUri = "/{0}/webhooks/{1}.json";
        
        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public WebhookEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<Webhook>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(WebhooksUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Webhook>>(responseJson, _config.SerializerOptions);
        }

        public async Task<Webhook> CreateAsync(string administrationId, WebhookCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(WebhooksUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Webhook>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(WebhooksIdUri, administrationId, id);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}
