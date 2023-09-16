using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Endpoints.Projects.Models
{
    public class ProjectUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("project")]
        public ProjectUpdate Project { get; set; }
    }
}