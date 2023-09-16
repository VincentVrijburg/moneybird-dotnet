using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Endpoints.Projects.Models
{
    public class ProjectCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("project")]
        public ProjectCreate Project { get; set; }
    }
}