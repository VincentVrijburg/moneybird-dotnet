using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.RecurringSalesInvoices;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Notes;
using Moneybird.Net.Models.RecurringSalesInvoices;

namespace Moneybird.Net.Endpoints
{
    public class RecurringSalesInvoiceEndpoint : IRecurringSalesInvoiceEndpoint
    {
        private const string RecurringSalesInvoiceUri = "/{0}/recurring_sales_invoices.json";
        private const string RecurringSalesInvoiceIdUri = "/{0}/recurring_sales_invoices/{1}.json";
        private const string RecurringSalesInvoiceSynchronizationUri = "/{0}/recurring_sales_invoices/synchronization.json";
        private const string RecurringSalesInvoiceIdNotesUri = "/{0}/recurring_sales_invoices/{1}/notes.json";
        private const string RecurringSalesInvoiceIdNotesIdUri = "/{0}/recurring_sales_invoices/{1}/notes/{2}.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public RecurringSalesInvoiceEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }

        public async Task<IEnumerable<RecurringSalesInvoice>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(RecurringSalesInvoiceUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<RecurringSalesInvoice>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<RecurringSalesInvoice>> GetAsync(
            string administrationId,
            string accessToken,
            RecurringSalesInvoiceFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add(filterString);
            }
            
            var relativeUrl = string.Format(RecurringSalesInvoiceUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<RecurringSalesInvoice>>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<IEnumerable<SynchronizationRecurringSalesInvoice>> GetSynchronizationRecurringSalesInvoicesAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(RecurringSalesInvoiceSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SynchronizationRecurringSalesInvoice>>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<IEnumerable<SynchronizationRecurringSalesInvoice>> GetSynchronizationRecurringSalesInvoicesAsync(
            string administrationId,
            string accessToken,
            RecurringSalesInvoiceFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add(filterString);
            }
            
            var relativeUrl = string.Format(RecurringSalesInvoiceSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SynchronizationRecurringSalesInvoice>>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<IEnumerable<RecurringSalesInvoice>> GetRecurringSalesInvoicesByIdsAsync(
            string administrationId,
            string accessToken,
            RecurringSalesInvoiceListOptions options)
        {
            var relativeUrl = string.Format(RecurringSalesInvoiceSynchronizationUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);
            
            return JsonSerializer.Deserialize<IEnumerable<RecurringSalesInvoice>>(responseJson, _config.SerializerOptions);
        }

        public async Task<RecurringSalesInvoice> GetByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(RecurringSalesInvoiceIdUri, administrationId, id);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<RecurringSalesInvoice>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<RecurringSalesInvoice> CreateAsync(string administrationId, RecurringSalesInvoiceCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(RecurringSalesInvoiceUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<RecurringSalesInvoice>(responseJson, _config.SerializerOptions);
        }

        public async Task<RecurringSalesInvoice> UpdateByIdAsync(
            string administrationId,
            string id,
            RecurringSalesInvoiceUpdateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(RecurringSalesInvoiceIdUri, administrationId, id);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<RecurringSalesInvoice>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(RecurringSalesInvoiceIdUri, administrationId, id);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<Note> CreateRecurringSalesInvoiceNoteAsync(
            string administrationId,
            string recurringSalesInvoiceId,
            NoteCreateOptions options,
            string accessToken)
        {
            var relativeUrl = string.Format(RecurringSalesInvoiceIdNotesUri, administrationId, recurringSalesInvoiceId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Note>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteRecurringSalesInvoiceNoteByIdAsync(
            string administrationId,
            string recurringSalesInvoiceId,
            string noteId,
            string accessToken)
        {
            var relativeUrl = string.Format(RecurringSalesInvoiceIdNotesIdUri, administrationId, recurringSalesInvoiceId, noteId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}
