using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Estimates;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Estimates;
using Moneybird.Net.Models.Notes;

namespace Moneybird.Net.Endpoints
{
    public class EstimateEndpoint : IEstimateEndpoint
    {
        private const string EstimateUri = "/{0}/estimates.json";
        private const string EstimateIdUri = "/{0}/estimates/{1}.json";
        private const string EstimateFindByEstimateIdUri = "/{0}/estimates/find_by_estimate_id/{1}.json";
        private const string EstimateSynchronizationUri = "/{0}/estimates/synchronization.json";
        private const string EstimateSendUri = "/{0}/estimates/{1}/send_estimate.json";
        private const string EstimateChangeStateUri = "/{0}/estimates/{1}/change_state.json";
        private const string EstimateBillUri = "/{0}/estimates/{1}/bill_estimate.json";
        private const string EstimateDownloadPdfUri = "/{0}/estimates/{1}/download_pdf.json";
        private const string EstimateAttachmentUri = "/{0}/estimates/{1}/attachments";
        private const string EstimateAttachmentIdUri = "/{0}/estimates/{1}/attachments/{2}.json";
        private const string EstimateAttachmentIdDownloadUri = "/{0}/estimates/{1}/attachments/{2}/download.json";
        private const string EstimateNotesUri = "/{0}/estimates/{1}/notes.json";
        private const string EstimateNoteIdUri = "/{0}/estimates/{1}/notes/{2}.json";
        
        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public EstimateEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<IEnumerable<Estimate>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(EstimateUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Estimate>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<Estimate>> GetAsync(
            string administrationId,
            string accessToken,
            EstimateFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
                         
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add($"filter={filterString}");
            }
            
            var relativeUrl = string.Format(EstimateUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Estimate>>(responseJson, _config.SerializerOptions);
        }

        public async Task<Estimate> GetByIdAsync(string administrationId, string estimateId, string accessToken)
        {
            var relativeUrl = string.Format(EstimateIdUri, administrationId, estimateId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Estimate>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<Estimate> GetByEstimateIdAsync(string administrationId, string estimateId, string accessToken)
        {
            var relativeUrl = string.Format(EstimateFindByEstimateIdUri, administrationId, estimateId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Estimate>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<IEnumerable<SynchronizationEstimate>> GetSynchronizationEstimatesAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(EstimateSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SynchronizationEstimate>>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<IEnumerable<SynchronizationEstimate>> GetSynchronizationEstimatesAsync(
            string administrationId,
            string accessToken,
            EstimateFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add(filterString);
            }
            
            var relativeUrl = string.Format(EstimateSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SynchronizationEstimate>>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<IEnumerable<Estimate>> GetEstimatesByIdsAsync(string administrationId, string accessToken, EstimateListOptions options)
        {
            var relativeUrl = string.Format(EstimateSynchronizationUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);
            
            return JsonSerializer.Deserialize<IEnumerable<Estimate>>(responseJson, _config.SerializerOptions);
        }

        public async Task<Estimate> CreateAsync(string administrationId, EstimateCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(EstimateUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);

            var response = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Estimate>(response, _config.SerializerOptions);
        }
        
        public async Task<Estimate> UpdateByIdAsync(string administrationId, string estimateId, EstimateUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(EstimateIdUri, administrationId, estimateId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Estimate>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string estimateId, string accessToken)
        {
            var relativeUrl = string.Format(EstimateIdUri, administrationId, estimateId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<Estimate> SendEstimate(string administrationId, string estimateId, EstimateSendOptions options, string accessToken)
        {
            var relativeUrl = string.Format(EstimateSendUri, administrationId, estimateId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Estimate>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<Estimate> ChangeStateAsync(string administrationId, string estimateId, EstimateChangeStateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(EstimateChangeStateUri, administrationId, estimateId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Estimate>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<SalesInvoice> BillEstimateAsync(string administrationId, string estimateId, string accessToken)
        {
            var relativeUrl = string.Format(EstimateBillUri, administrationId, estimateId);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, "{}")
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<SalesInvoice>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<Stream> DownloadPdfAsync(string administrationId, string estimateId, string accessToken)
        {
            var relativeUrl = string.Format(EstimateDownloadPdfUri, administrationId, estimateId);

            return await _requester
                .CreateDownloadRequestAsync(_config.ApiUri, relativeUrl, accessToken, HttpMethod.Get)
                .ConfigureAwait(false);
        }

        public async Task AddAttachmentAsync(string administrationId, string estimateId, Stream body, string accessToken, string fileName = "estimate.pdf")
        {
            var relativeUrl = string.Format(EstimateAttachmentUri, administrationId, estimateId);

            await _requester
                .CreatePostFileRequestAsync(_config.ApiUri, relativeUrl, accessToken, fileName, body)
                .ConfigureAwait(false);
        }
        
        public async Task<Stream> DownloadAttachmentByIdAsync(string administrationId, string estimateId, string attachmentId, string accessToken)
        {
            var relativeUrl = string.Format(EstimateAttachmentIdDownloadUri, administrationId, estimateId, attachmentId);

            return await _requester
                .CreateDownloadRequestAsync(_config.ApiUri, relativeUrl, accessToken, HttpMethod.Get)
                .ConfigureAwait(false);
        }
        
        public async Task<bool> DeleteAttachmentByIdAsync(string administrationId, string estimateId, string attachmentId, string accessToken)
        {
            var relativeUrl = string.Format(EstimateAttachmentIdUri, administrationId, estimateId, attachmentId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
        
        public async Task<Note> CreateEstimateNoteAsync(string administrationId, string estimateId, NoteCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(EstimateNotesUri, administrationId, estimateId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Note>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<bool> DeleteEstimateNoteByIdAsync(string administrationId, string estimateId, string noteId, string accessToken)
        {
            var relativeUrl = string.Format(EstimateNoteIdUri, administrationId, estimateId, noteId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}
