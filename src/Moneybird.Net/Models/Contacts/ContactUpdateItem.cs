using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Models.Contacts
{
    public class ContactUpdateItem
    {
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }
        
        [JsonPropertyName("address1")]
        public string Address1 { get; set; }
        
        [JsonPropertyName("address2")]
        public string Address2 { get; set; }
        
        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }
        
        [JsonPropertyName(("city"))]
        public string City { get; set; }
        
        [JsonPropertyName("country")]
        public string CountryCode { get; set; }
        
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        
        [JsonPropertyName("delivery_method")]
        public DeliveryMethod DeliveryMethod { get; set; }
        
        [JsonPropertyName("email_ubl")]
        public bool? EmailUbl { get; set; }
        
        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }
        
        [JsonPropertyName("tax_number")]
        public string TaxNumber { get; set; }
        
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }
        
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }
        
        [JsonPropertyName("chamber_of_commerce")]
        public string ChamberOfCommerce { get; set; }
        
        [JsonPropertyName("bank_account")]
        public string BankAccount { get; set; }
        
        [JsonPropertyName("send_invoices_to_attention")]
        public string SendInvoicesToAttention { get; set; }
        
        [JsonPropertyName("send_invoices_to_email")]
        public string SendInvoicesToEmail { get; set; }
        
        [JsonPropertyName("send_estimates_to_attention")]
        public string SendEstimatesToAttention { get; set; }
        
        [JsonPropertyName("send_estimates_to_email")]
        public string SendEstimatesToEmail { get; set; }
        
        [JsonPropertyName("sepa_active")]
        public bool? SepaActive { get; set; }

        [JsonPropertyName("sepa_iban")]
        public string SepaIban { get; set; }
        
        [JsonPropertyName("sepa_iban_account_name")]
        public string SepaIbanAccountName { get; set; }
        
        [JsonPropertyName("sepa_bic")]
        public string SepaBic { get; set; }
        
        [JsonPropertyName("sepa_mandate_id")]
        public string SepaMandateId { get; set; }
        
        [JsonPropertyName("sepa_mandate_date")]
        public string SepaMandateDate { get; set; }
        
        [JsonPropertyName("sepa_sequence_type")]
        public SepaSequenceType SepaSequenceType { get; set; }

        [JsonPropertyName("invoice_workflow_id")]
        public string InvoiceWorkflowId { get; set; }
        
        [JsonPropertyName("estimate_workflow_id")]
        public string EstimateWorkflowId { get; set; }

        [JsonPropertyName("si_identifier_type")]
        public string SiIdentifierTypeType { get; set; }
        
        [JsonPropertyName("si_identifier")]
        public string SiIdentifier { get; set; }
        
        [JsonPropertyName("direct_debit")]
        public bool? DirectDebit { get; set; }
         
        [JsonPropertyName("custom_fields_attributes")]
        public List<CustomFieldAttribute> CustomFieldsAttributes { get; set; }
    }
}