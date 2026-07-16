using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Models.RecurringSalesInvoices
{
    public class RecurringSalesInvoiceCreate
    {
        [JsonPropertyName("document_style_id")]
        public string DocumentStyleId { get; set; }
        
        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }
        
        [JsonPropertyName("contact_person_id")]
        public string ContactPersonId { get; set; }
        
        [JsonPropertyName("update_contact")]
        public bool? UpdateContact { get; set; }
        
        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        
        [JsonPropertyName("invoice_date")]
        public DateTime? InvoiceDate { get; set; }
        
        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }
        
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        [JsonPropertyName("first_due_interval")]
        public int? FirstDueInterval { get; set; }
        
        [JsonPropertyName("prices_are_incl_tax")]
        public bool? PricesAreInclTax { get; set; }
        
        [JsonPropertyName("discount")]
        public double? Discount { get; set; }
        
        [JsonPropertyName("frequency_type")]
        public FrequencyType? FrequencyType { get; set; }
        
        [JsonPropertyName("frequency")]
        public int? Frequency { get; set; }
        
        [JsonPropertyName("has_desired_count")]
        public bool? HasDesiredCount { get; set; }
        
        [JsonPropertyName("desired_count")]
        public int? DesiredCount { get; set; }
        
        [JsonPropertyName("auto_send")]
        public bool? AutoSend { get; set; }
        
        [JsonPropertyName("mergeable")]
        public bool? Mergeable { get; set; }
        
        [JsonPropertyName("details_attributes")]
        public List<RecurringSalesInvoiceCreateDetail> DetailsAttributes { get; set; }
        
        [JsonPropertyName("custom_fields_attributes")]
        public List<CustomFieldAttribute> CustomFieldsAttributes { get; set; }
    }
}
