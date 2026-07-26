using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Attachments;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Entities.Notes;

namespace Moneybird.Net.Entities.Estimates
{
    public class Estimate : IMoneybirdEntity
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

        [JsonPropertyName("estimate_id")]
        public string EstimateId { get; set; }

        [JsonPropertyName("estimate_sequence_id")]
        public string EstimateSequenceId { get; set; }
        
        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }
        
        [JsonPropertyName("document_style_id")]
        public string DocumentStyleId { get; set; }
        
        [JsonPropertyName("identity_id")]
        public string IdentityId { get; set; }
        
        [JsonPropertyName("draft_id")]
        public string DraftId { get; set; }
        
        [JsonPropertyName("state")]
        public EstimateState State { get; set; }
        
        [JsonPropertyName("estimate_date")]
        public DateTime? EstimateDate { get; set; }
        
        [JsonPropertyName("due_date")]
        public DateTime? DueDate { get; set; }
        
        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        
        [JsonPropertyName("language")]
        public string Language { get; set; }
        
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        [JsonPropertyName("exchange_rate")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? ExchangeRate { get; set; }
        
        [JsonPropertyName("discount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? Discount { get; set; }
        
        [JsonPropertyName("original_estimate_id")]
        public string OriginalEstimateId { get; set; }
        
        [JsonPropertyName("show_tax")]
        public bool ShowTax { get; set; }
        
        [JsonPropertyName("sign_online")]
        public bool SignOnline { get; set; }
        
        [JsonPropertyName("sent_at")]
        public DateTime? SentAt { get; set; }
        
        [JsonPropertyName("accepted_at")]
        public DateTime? AcceptedAt { get; set; }
        
        [JsonPropertyName("rejected_at")]
        public DateTime? RejectedAt { get; set; }
        
        [JsonPropertyName("archived_at")]
        public DateTime? ArchivedAt { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonPropertyName("public_view_code")]
        public string PublicViewCode { get; set; }
        
        [JsonPropertyName("public_view_code_expires_at")]
        public string PublicViewCodeExpiresAt { get; set; }
        
        [JsonPropertyName("version")]
        public int Version { get; set; }
        
        [JsonPropertyName("pre_text")]
        public string PreText { get; set; }
        
        [JsonPropertyName("post_text")]
        public string PostText { get; set; }
        
        [JsonPropertyName("details")]
        public List<EstimateDetail> Details { get; set; }
        
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
        
        [JsonPropertyName("total_discount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalDiscount { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        [JsonPropertyName("custom_fields")]
        public List<CustomFieldAttribute> CustomFields { get; set; }
        
        [JsonPropertyName("notes")]
        public List<Note> Notes { get; set; }
        
        [JsonPropertyName("attachments")]
        public List<Attachment> Attachments { get; set; }
        
        [JsonPropertyName("events")]
        public List<Event> Events { get; set; }
        
        [JsonPropertyName("tax_totals")]
        public List<EstimateTaxTotal> TaxTotals { get; set; }
    }
}
