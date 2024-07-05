using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Entities.SalesInvoices;

namespace Moneybird.Net.Endpoints.SalesInvoices.Models
{
    public class SalesInvoiceUpdate
    {
        /// <summary>
        /// Should be a valid contact id.
        /// </summary>
        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        /// <summary>
        /// Should be a valid contact person id.
        /// </summary>
        [JsonPropertyName("contact_person_id")]
        public string ContactPersonId { get; set; }
        
        [JsonPropertyName("update_contact")]
        public bool UpdateContact { get; set; }

        [JsonPropertyName("original_estimate_id")]
        public string OriginalEstimateId { get; set; }

        /// <summary>
        /// Default document style is used if value is not provided. Should be a valid document style id.
        /// </summary>
        [JsonPropertyName("document_style_id")]
        public string DocumentStyleId { get; set; }

        /// <summary>
        /// If value is not provided, the workflow saved in the contact is used.
        /// If the contact doesn’t have a default workflow, the administration’s default workflow is used.
        /// Should be a valid workflow id.
        /// </summary>
        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("invoice_sequence_id")]
        public string InvoiceSequenceId { get; set; }
        
        [JsonPropertyName("remove_invoice_sequence_id")]
        public bool RemoveInvoiceSequenceId { get; set; }

        [JsonPropertyName("invoice_date")]
        public DateTime? InvoiceDate { get; set; }

        [JsonPropertyName("first_due_interval")]
        public int? FirstDueInterval { get; set; }

        /// <summary>
        /// ISO three-character currency code, e.g. EUR or USD.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("prices_are_incl_tax")]
        public bool? PricesAreInclTax { get; set; }

        [JsonPropertyName("payment_conditions")]
        public string PaymentConditions { get; set; }

        /// <summary>
        /// Discount percentage, e.g. 10,0%.
        /// </summary>
        [JsonPropertyName("discount")]
        public double? Discount { get; set; }

        [JsonPropertyName("details_attributes")]
        public IReadOnlyList<SalesInvoiceUpdateDetail> DetailsAttributes { get; set; }

        [JsonPropertyName("custom_fields_attributes")]
        public IReadOnlyList<CustomFieldAttribute> CustomFieldsAttributes { get; set; }
    }
}