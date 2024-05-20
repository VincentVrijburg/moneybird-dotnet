using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Verifications;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints
{
    public class VerificationEndpoint : IVerificationEndpoint
    {
        private const string VerificationsUri = "/{0}/verifications.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public VerificationEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<Verification> GetVerificationAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(VerificationsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Verification>(responseJson, _config.SerializerOptions);
        }
    }
}