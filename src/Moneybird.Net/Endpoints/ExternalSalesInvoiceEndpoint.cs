using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.ExternalSalesInvoices;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.ExternalSalesInvoices;

namespace Moneybird.Net.Endpoints
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

        public async Task<IEnumerable<ExternalSalesInvoice>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(ExternalSalesInvoiceUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<ExternalSalesInvoice>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<ExternalSalesInvoice>> GetAsync(
            string administrationId,
            string accessToken,
            ExternalSalesInvoiceFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
                        
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add($"filter={filterString}");
            }
            
            var relativeUrl = string.Format(ExternalSalesInvoiceUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<ExternalSalesInvoice>>(responseJson, _config.SerializerOptions);
        }

        public async Task<ExternalSalesInvoice> GetByIdAsync(string administrationId, string externalSalesInvoiceId, string accessToken)
        {
            var relativeUrl = string.Format(ExternalSalesInvoiceIdUri, administrationId, externalSalesInvoiceId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<ExternalSalesInvoice>(responseJson, _config.SerializerOptions);
        }

        public async Task<ExternalSalesInvoice> CreateAsync(string administrationId, ExternalSalesInvoiceCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ExternalSalesInvoiceUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);

            var response = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<ExternalSalesInvoice>(response, _config.SerializerOptions);
        }
        
        public async Task<ExternalSalesInvoice> UpdateByIdAsync(string administrationId, string externalSalesInvoiceId, ExternalSalesInvoiceUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ExternalSalesInvoiceIdUri, administrationId, externalSalesInvoiceId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<ExternalSalesInvoice>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<bool> DeleteByIdAsync(string administrationId, string externalSalesInvoiceId, string accessToken)
        {
            var relativeUrl = string.Format(ExternalSalesInvoiceIdUri, administrationId, externalSalesInvoiceId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task AddAttachmentAsync(string administrationId, string externalSalesInvoiceId, Stream body, string accessToken, string fileName = "invoice.pdf")
        {
            var relativeUrl = string.Format(ExternalSalesInvoiceAttachmentUri, administrationId, externalSalesInvoiceId);

            await _requester
                .CreatePostFileRequestAsync(_config.ApiUri, relativeUrl, accessToken, fileName, body)
                .ConfigureAwait(false);
        }
    }
}
