using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Payments;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.Payments
{
    public class PaymentEndpoint : IPaymentEndpoint
    {
        private const string PaymentsIdUri = "/{0}/payments/{1}.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public PaymentEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<Payment> GetPaymentByIdAsync(string administrationId, string paymentId, string accessToken)
        {
            var relativeUrl = string.Format(PaymentsIdUri, administrationId, paymentId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Payment>(responseJson, _config.SerializerOptions);
        }
    }
}