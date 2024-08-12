using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.SalesInvoices;

namespace Moneybird.Net.Endpoints
{
    public class SalesInvoiceEndpoint : ISalesInvoiceEndpoint
    {
        private const string SalesInvoiceUri = "/{0}/sales_invoices.json";
        private const string SalesInvoiceIdUri = "/{0}/sales_invoices/{1}.json";
        private const string SalesInvoiceAttachmentUri = "/{0}/external_sales_invoices/{1}/attachment";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public SalesInvoiceEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<IEnumerable<SalesInvoice>> GetAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(SalesInvoiceUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SalesInvoice>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<SalesInvoice>> GetAsync(string administrationId, string accessToken, SalesInvoiceFilterOptions options)
        {
            List<string> paramValues = null;
                        
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues = new List<string> { $"filter={filterString}" };
            }
            
            var relativeUrl = string.Format(SalesInvoiceUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SalesInvoice>>(responseJson, _config.SerializerOptions);
        }

        public async Task<SalesInvoice> GetByIdAsync(string administrationId, string salesInvoiceId, string accessToken)
        {
            var relativeUrl = string.Format(SalesInvoiceIdUri, administrationId, salesInvoiceId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<SalesInvoice>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<SalesInvoice> CreateAsync(string administrationId, SalesInvoiceCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(SalesInvoiceUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);

            var response = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<SalesInvoice>(response, _config.SerializerOptions);
        }

        public async Task<SalesInvoice> UpdateByIdAsync(string administrationId, string salesInvoiceId, SalesInvoiceUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(SalesInvoiceIdUri, administrationId, salesInvoiceId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<SalesInvoice>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string salesInvoiceId, string accessToken)
        {
            var relativeUrl = string.Format(SalesInvoiceIdUri, administrationId, salesInvoiceId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<SalesInvoice> SendInvoice(string administrationId, string salesInvoiceId, SalesInvoiceSendOptions options, string accessToken)
        {
            var relativeUrl = string.Format(SalesInvoiceIdUri, administrationId, salesInvoiceId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<SalesInvoice>(responseJson, _config.SerializerOptions); ;
        }

        public async Task AddAttachmentAsync(string administrationId, string salesInvoiceId, Stream body, string accessToken, string fileName = "invoice.pdf")
        {
            var relativeUrl = string.Format(SalesInvoiceAttachmentUri, administrationId, salesInvoiceId);

            await _requester
                .CreatePostFileRequestAsync(_config.ApiUri, relativeUrl, accessToken, fileName, body)
                .ConfigureAwait(false);
        }
    }
}
