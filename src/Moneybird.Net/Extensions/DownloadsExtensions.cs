using System.Collections.Generic;
using Moneybird.Net.Models.Downloads;

namespace Moneybird.Net.Extensions
{
    internal static class DownloadsExtensions
    {
        public static IEnumerable<string> GetQueryParameters(this DownloadFilterOptions options)
        {
            var queryParameters = new List<string>();

            if (options.DownloadType.HasValue)
            {
                queryParameters.Add($"download_type={options.DownloadType.Value.ToString().ToSnakeCase()}");
            }

            if (options.Downloaded.HasValue)
            {
                queryParameters.Add($"downloaded={options.Downloaded.Value.ToString().ToLowerInvariant()}");
            }

            if (options.Failed.HasValue)
            {
                queryParameters.Add($"failed={options.Failed.Value.ToString().ToLowerInvariant()}");
            }

            return queryParameters;
        }
    }
}
