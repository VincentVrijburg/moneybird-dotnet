using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Identities;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Identities;

namespace Moneybird.Net.Endpoints
{
    public class IdentityEndpoint : IIdentityEndpoint
    {
        private const string IdentitiesUri = "/{0}/identities.json";
        private const string IdentitiesIdUri = "/{0}/identities/{1}.json";
        private const string IdentitiesDefaultUri = "/{0}/identities/default.json";
        
        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public IdentityEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }

        public async Task<IEnumerable<Identity>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(IdentitiesUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Identity>>(responseJson, _config.SerializerOptions);
        }

        public async Task<Identity> GetByIdAsync(string administrationId, string identityId, string accessToken)
        {
            var relativeUrl = string.Format(IdentitiesIdUri, administrationId, identityId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Identity>(responseJson, _config.SerializerOptions);
        }

        public async Task<Identity> GetDefaultAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(IdentitiesDefaultUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Identity>(responseJson, _config.SerializerOptions);
        }

        public async Task<Identity> CreateAsync(
            string administrationId,
            IdentityCreateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(IdentitiesUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Identity>(responseJson, _config.SerializerOptions);
        }

        public async Task<Identity> UpdateByIdAsync(
            string administrationId,
            string identityId,
            IdentityUpdateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(IdentitiesIdUri, administrationId, identityId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Identity>(responseJson, _config.SerializerOptions);
        }

        public async Task<Identity> UpdateDefaultAsync(
            string administrationId,
            IdentityUpdateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(IdentitiesDefaultUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Identity>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<bool> DeleteByIdAsync(string administrationId, string identityId, string accessToken)
        {
            var relativeUrl = string.Format(IdentitiesIdUri, administrationId, identityId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}
