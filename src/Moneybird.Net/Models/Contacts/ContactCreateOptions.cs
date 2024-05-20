using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.Contacts
{
    public class ContactCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("contact")]
        public ContactCreateItem Contact { get; set; }
    }
}