using System.IO;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Downloads;
using Moneybird.Net.Models.Downloads;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IDownloadEndpoint :
        IReadEndpoint<Download>,
        IReadFilterEndpoint<Download, DownloadFilterOptions>
    {
        /// <summary>
        /// Download a generated export file by download id.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="downloadId">The download id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A stream containing the downloaded file contents.</returns>
        Task<Stream> DownloadByIdAsync(string administrationId, string downloadId, string accessToken);
    }
}
