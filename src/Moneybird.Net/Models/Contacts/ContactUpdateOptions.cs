using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Contacts
{
    public class ContactUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("contact")]
        public ContactUpdateItem Contact { get; set; }
    }
}