using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Entities.RecurringSalesInvoices
{
    public class RecurringSalesInvoice : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }

        [JsonPropertyName("contact_person_id")]
        public string ContactPersonId { get; set; }

        [JsonPropertyName("contact_person")]
        public ContactPerson ContactPerson { get; set; }

        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("invoice_date")]
        public DateTime InvoiceDate { get; set; }

        [JsonPropertyName("last_date")]
        public DateTime? LastDate { get; set; }

        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        [JsonPropertyName("payment_conditions")]
        public string PaymentConditions { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("discount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? Discount { get; set; }

        [JsonPropertyName("first_due_interval")]
        public int? FirstDueInterval { get; set; }

        [JsonPropertyName("auto_send")]
        public bool? AutoSend { get; set; }

        [JsonPropertyName("sending_scheduled_at")]
        public DateTime? SendingScheduledAt { get; set; }

        [JsonPropertyName("sending_scheduled_user_id")]
        public string SendingScheduledUserId { get; set; }

        [JsonPropertyName("frequency_type")]
        public FrequencyType FrequencyType { get; set; }

        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("prices_are_incl_tax")]
        public bool PricesAreInclTax { get; set; }

        [JsonPropertyName("total_price_excl_tax")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalPriceExclTax { get; set; }

        [JsonPropertyName("total_price_excl_tax_base")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalPriceExclTaxBase { get; set; }

        [JsonPropertyName("total_price_incl_tax")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalPriceInclTax { get; set; }

        [JsonPropertyName("total_price_incl_tax_base")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalPriceInclTaxBase { get; set; }

        [JsonPropertyName("details")]
        public List<SalesInvoiceDetail> Details { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<CustomFieldAttribute> CustomFields { get; set; }

        [JsonPropertyName("notes")]
        public List<Note> Notes { get; set; }

        [JsonPropertyName("attachments")]
        public List<SalesInvoiceAttachment> Attachments { get; set; }

        [JsonPropertyName("events")]
        public List<Event> Events { get; set; }

    }
}
