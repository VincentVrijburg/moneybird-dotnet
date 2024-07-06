using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.TimeEntries
{
    public class TimeEntryCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("time_entry")]
        public TimeEntryCreate TimeEntry { get; set; }
    }
}
