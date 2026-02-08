using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.Projects;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Entities.Users;

namespace Moneybird.Net.Entities.TimeEntries
{
    public class TimeEntry : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }
        
        [JsonPropertyName("sales_invoice_id")]
        public string SalesInvoiceId { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("paused_duration")]
        public int PausedDuration { get; set; }

        [JsonPropertyName("billable")]
        public bool Billable { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("project")]
        public Project Project { get; set; }
        
        [JsonPropertyName("sales_invoice")]
        public SalesInvoice SalesInvoice { get; set; }

        [JsonPropertyName("events")]
        public List<Event> Events { get; set; }

        [JsonPropertyName("notes")]
        public List<Note> Notes { get; set; }
    }
}