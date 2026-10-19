using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.GeneralDocuments;

public class GeneralDocumentCreate
{
    /// <summary>
    /// Required.
    /// </summary>
    [JsonPropertyName("reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Required.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("due_date")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("reminder_date")]
    public DateTime? ReminderDate { get; set; }

    /// <summary>
    /// Should be a valid contact id.
    /// </summary>
    [JsonPropertyName("contact_id")]
    public string ContactId { get; set; }

    /// <summary>
    /// Creates a reminder to-do for this document.
    /// </summary>
    [JsonPropertyName("reminder")]
    public GeneralDocumentReminder Reminder { get; set; }
}
