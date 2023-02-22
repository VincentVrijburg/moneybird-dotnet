using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.SaleInvoices;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.SaleInvoices
{
    public class SaleInvoiceEndpoint : ISaleInvoiceEndpoint
    {
        private const string CreateSaleInvoiceEndpoint = "/{0}/sales_invoices.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public SaleInvoiceEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<SaleInvoice> CreateSaleInvoice(
            string administrationId,
            SaleInvoiceCreateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(CreateSaleInvoiceEndpoint, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);

            var response = await _requester.CreatePostRequestAsync(
                _config.ApiUri,
                relativeUrl,
                accessToken,
                body);

            return JsonSerializer.Deserialize<SaleInvoice>(response, _config.SerializerOptions);
        }
    }
}
