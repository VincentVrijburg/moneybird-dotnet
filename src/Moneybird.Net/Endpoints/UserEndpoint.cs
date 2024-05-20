using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Users;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints
{
    public class UserEndpoint : IUserEndpoint
    {
        private const string UsersUri = "/{0}/users.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public UserEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<User>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(UsersUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<User>>(responseJson, _config.SerializerOptions);
        }
    }
}
