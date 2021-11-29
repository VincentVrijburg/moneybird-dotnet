using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Administrations.Models;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.Administrations
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
        
        public async Task<AdministrationList> GetAdministrationsAsync(string accessToken)
        {
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, AdministrationsUri, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<AdministrationList>(responseJson);
        }
    }
}