using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.SalesInvoices.Models;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.SalesInvoices
{
    public class SalesInvoiceEndpoint : ISalesInvoiceEndpoint
    {
        private const string CreateSaleInvoiceEndpoint = "/{0}/sales_invoices.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public SalesInvoiceEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<SalesInvoice> CreateSaleInvoiceAsync(
            string administrationId,
            SalesInvoiceCreateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(CreateSaleInvoiceEndpoint, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);

            var response = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<SalesInvoice>(response, _config.SerializerOptions);
        }
    }
}
