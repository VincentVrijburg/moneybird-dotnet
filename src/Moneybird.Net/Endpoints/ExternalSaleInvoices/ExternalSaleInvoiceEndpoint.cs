using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.ExternalSaleInvoices;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.ExternalSaleInvoices
{
    public class ExternalSaleInvoiceEndpoint : IExternalSaleInvoiceEndpoint
    {
        private const string CreateExternalSaleInvoiceEndpoint = "/{0}/external_sales_invoices.json";
        private const string UploadExternalSaleInvoiceAttachmentEndpoint = "/{0}/external_sales_invoices/{1}/attachment";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public ExternalSaleInvoiceEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<ExternalSaleInvoice> CreateSaleInvoice(
            string administrationId,
            ExternalSaleInvoiceCreateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(CreateExternalSaleInvoiceEndpoint, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);

            var response = await _requester.CreatePostRequestAsync(
                _config.ApiUri,
                relativeUrl,
                accessToken,
                body);

            return JsonSerializer.Deserialize<ExternalSaleInvoice>(response, _config.SerializerOptions);
        }

        public async Task AddAttachment(
            string administrationId,
            string id,
            Stream body,
            string accessToken,
            string fileName = "invoice.pdf")
        {
            var relativeUrl = string.Format(UploadExternalSaleInvoiceAttachmentEndpoint, administrationId, id);

            await _requester.CreatePostFileRequestAsync(
                _config.ApiUri,
                relativeUrl,
                accessToken,
                fileName,
                body);
        }
    }
}
