using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints
{
    public class CustomFieldEndpoint : ICustomFieldEndpoint
    {
        private const string CustomFieldsUri = "/{0}/custom_fields.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public CustomFieldEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<CustomField>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(CustomFieldsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<CustomField>>(responseJson, _config.SerializerOptions);
        }
    }
}
