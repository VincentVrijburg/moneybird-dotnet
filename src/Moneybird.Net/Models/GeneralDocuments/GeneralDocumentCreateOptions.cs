using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.GeneralDocuments;

public class GeneralDocumentCreateOptions : IMoneybirdCreateOptions
{
    [JsonPropertyName("general_document")]
    public GeneralDocumentCreate GeneralDocument { get; set; }
}
