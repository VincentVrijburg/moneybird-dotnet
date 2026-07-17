using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Downloads;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Downloads;

namespace Moneybird.Net.Endpoints
{
    public class DownloadEndpoint : IDownloadEndpoint
    {
        private const string DownloadsUri = "/{0}/downloads.json";
        private const string DownloadsIdDownloadUri = "/{0}/downloads/{1}/download.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public DownloadEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _config = config;
            _requester = requester;
        }

        public async Task<IEnumerable<Download>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(DownloadsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Download>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<Download>> GetAsync(
            string administrationId,
            string accessToken,
            DownloadFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            paramValues.AddRange(options.GetQueryParameters());

            var relativeUrl = string.Format(DownloadsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Download>>(responseJson, _config.SerializerOptions);
        }

        public async Task<Stream> DownloadByIdAsync(string administrationId, string downloadId, string accessToken)
        {
            var relativeUrl = string.Format(DownloadsIdDownloadUri, administrationId, downloadId);

            return await _requester
                .CreatePostDownloadRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);
        }
    }
}
