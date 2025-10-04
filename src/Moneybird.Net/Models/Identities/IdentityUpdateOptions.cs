using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Identities
{
    public class IdentityUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("identity")]
        public IdentityUpdate Identity { get; set; }
    }
}
