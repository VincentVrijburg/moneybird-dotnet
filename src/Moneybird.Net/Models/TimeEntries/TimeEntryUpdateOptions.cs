using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.TimeEntries
{
    public class TimeEntryUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("time_entry")]
        public TimeEntryUpdate TimeEntry { get; set; }
    }
}
