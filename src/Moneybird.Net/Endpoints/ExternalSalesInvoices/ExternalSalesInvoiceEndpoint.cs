using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.ExternalSalesInvoices.Models;
using Moneybird.Net.Entities.ExternalSalesInvoices;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.ExternalSalesInvoices
{
    public class ExternalSalesInvoiceEndpoint : IExternalSalesInvoiceEndpoint
    {
        private const string CreateExternalSaleInvoiceEndpoint = "/{0}/external_sales_invoices.json";
        private const string UploadExternalSaleInvoiceAttachmentEndpoint = "/{0}/external_sales_invoices/{1}/attachment";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public ExternalSalesInvoiceEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<ExternalSalesInvoice> CreateSaleInvoiceAsync(
            string administrationId,
            ExternalSalesInvoiceCreateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(CreateExternalSaleInvoiceEndpoint, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);

            var response = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<ExternalSalesInvoice>(response, _config.SerializerOptions);
        }

        public async Task AddAttachmentAsync(
            string administrationId,
            string id,
            Stream body,
            string accessToken,
            string fileName = "invoice.pdf")
        {
            var relativeUrl = string.Format(UploadExternalSaleInvoiceAttachmentEndpoint, administrationId, id);

            await _requester
                .CreatePostFileRequestAsync(_config.ApiUri, relativeUrl, accessToken, fileName, body)
                .ConfigureAwait(false);
        }
    }
}
