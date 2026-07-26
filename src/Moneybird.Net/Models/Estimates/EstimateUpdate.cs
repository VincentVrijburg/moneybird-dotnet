using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.CustomFields;

namespace Moneybird.Net.Models.Estimates
{
    public class EstimateUpdate
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

        [JsonPropertyName("estimate_sequence_id")]
        public string EstimateSequenceId { get; set; }
        
        [JsonPropertyName("remove_estimate_sequence_id")]
        public bool? RemoveEstimateSequenceId { get; set; }

        /// <summary>
        /// The default document style is used if a value is not provided. Should be a valid document style id.
        /// </summary>
        [JsonPropertyName("document_style_id")]
        public string DocumentStyleId { get; set; }

        /// <summary>
        /// If value is not provided, the workflow saved in the contact is used.
        /// If the contact does not have a default workflow, the administration’s default workflow is used.
        /// Should be a valid workflow id.
        /// </summary>
        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        
        [JsonPropertyName("estimate_date")]
        public DateTime? EstimateDate { get; set; }
        
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// ISO three-character currency code, e.g. EUR or USD.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        [JsonPropertyName("prices_are_incl_tax")]
        public bool? PricesAreInclTax { get; set; }
        
        [JsonPropertyName("show_tax")]
        public bool? ShowTax { get; set; }
        
        [JsonPropertyName("first_due_interval")]
        public int? FirstDueInterval { get; set; }

        /// <summary>
        /// Discount percentage, e.g. 10,0%.
        /// </summary>
        [JsonPropertyName("discount")]
        public double? Discount { get; set; }
        
        [JsonPropertyName("original_sales_invoice_id")]
        public string OriginalSalesInvoiceId { get; set; }
        
        [JsonPropertyName("pre_text")]
        public string PreText { get; set; }
        
        [JsonPropertyName("post_text")]
        public string PostText { get; set; }

        [JsonPropertyName("details_attributes")]
        public List<EstimateUpdateDetail> DetailsAttributes { get; set; }

        [JsonPropertyName("custom_fields_attributes")]
        public List<CustomFieldAttribute> CustomFieldsAttributes { get; set; }
    }
}
