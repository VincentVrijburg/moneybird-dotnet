using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.ExternalSalesInvoices.Models;
using Moneybird.Net.Entities.ExternalSalesInvoices;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.ExternalSalesInvoices
{
    public class ExternalSalesInvoiceEndpoint : IExternalSalesInvoiceEndpoint
    {
        private const string ExternalSalesInvoiceUri = "/{0}/external_sales_invoices.json";
        private const string ExternalSalesInvoiceIdUri = "/{0}/external_sales_invoices/{1}.json";
        private const string ExternalSalesInvoiceAttachmentUri = "/{0}/external_sales_invoices/{1}/attachment";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public ExternalSalesInvoiceEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<IEnumerable<ExternalSalesInvoice>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(ExternalSalesInvoiceUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<List<ExternalSalesInvoice>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<ExternalSalesInvoice>> GetAsync(string administrationId, string accessToken, ExternalSalesInvoiceFilterOptions options)
        {
            List<string> paramValues = null;
                        
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues = new List<string> { $"filter={filterString}" };
            }
            
            var relativeUrl = string.Format(ExternalSalesInvoiceUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<List<ExternalSalesInvoice>>(responseJson, _config.SerializerOptions);
        }

        public async Task<ExternalSalesInvoice> GetByIdAsync(
            string administrationId,
            string salesInvoiceId,
            string accessToken)
        {
            var relativeUrl = string.Format(ExternalSalesInvoiceIdUri, administrationId, salesInvoiceId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<ExternalSalesInvoice>(responseJson, _config.SerializerOptions);
        }

        public async Task<ExternalSalesInvoice> CreateAsync(
            string administrationId,
            ExternalSalesInvoiceCreateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(ExternalSalesInvoiceUri, administrationId);
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
            var relativeUrl = string.Format(ExternalSalesInvoiceAttachmentUri, administrationId, id);

            await _requester
                .CreatePostFileRequestAsync(_config.ApiUri, relativeUrl, accessToken, fileName, body)
                .ConfigureAwait(false);
        }
    }
}
