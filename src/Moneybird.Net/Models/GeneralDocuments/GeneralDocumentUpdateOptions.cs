using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.GeneralDocuments;

public class GeneralDocumentUpdateOptions : IMoneybirdUpdateOptions
{
    [JsonPropertyName("general_document")]
    public GeneralDocumentUpdate GeneralDocument { get; set; }

    [JsonPropertyName("remove_contact")]
    public bool? RemoveContact { get; set; }
}
