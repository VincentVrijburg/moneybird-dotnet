using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.GeneralDocuments;

public class GeneralDocumentCreate
{
    [JsonPropertyName("reference")]
    public string Reference { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("due_date")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("reminder_date")]
    public DateTime? ReminderDate { get; set; }

    [JsonPropertyName("contact_id")]
    public string ContactId { get; set; }

    [JsonPropertyName("reminder")]
    public GeneralDocumentReminder Reminder { get; set; }
}
