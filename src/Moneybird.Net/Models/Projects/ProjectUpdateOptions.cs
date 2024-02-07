using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Projects
{
    public class ProjectUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("project")]
        public ProjectUpdate Project { get; set; }
    }
}