using Moneybird.Net.Endpoints.Abstractions.Options;
using Moneybird.Net.Entities.Downloads;

namespace Moneybird.Net.Models.Downloads
{
    public class DownloadFilterOptions : IMoneybirdFilterOptions
    {
        public DownloadType? DownloadType { get; set; }

        public bool? Downloaded { get; set; }

        public bool? Failed { get; set; }
    }
}
