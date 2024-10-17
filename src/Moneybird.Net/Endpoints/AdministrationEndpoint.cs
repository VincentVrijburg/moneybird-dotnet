using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Administrations;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints
{
    public class AdministrationEndpoint : IAdministrationEndpoint
    {
        private const string AdministrationsUri = "/administrations.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public AdministrationEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<Administration>> GetAsync(string accessToken, int page = 1, int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, AdministrationsUri, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Administration>>(responseJson);
        }
    }
}
