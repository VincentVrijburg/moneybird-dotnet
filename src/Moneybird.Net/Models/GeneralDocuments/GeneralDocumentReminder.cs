using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.GeneralDocuments;

public class GeneralDocumentReminder
{
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }
}
