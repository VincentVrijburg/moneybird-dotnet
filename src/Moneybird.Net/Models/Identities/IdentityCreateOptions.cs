using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Identities
{
    public class IdentityCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("identity")]
        public IdentityCreate Identity { get; set; }
    }
}
