using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Entities.Contacts
{
    public class Contact : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("delivery_method")]
        public DeliveryMethod DeliveryMethod { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("tax_number")]
        public string TaxNumber { get; set; }

        [JsonPropertyName("chamber_of_commerce")]
        public string ChamberOfCommerce { get; set; }

        [JsonPropertyName("bank_account")]
        public string BankAccount { get; set; }

        [JsonPropertyName("attention")]
        public string Attention { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("email_ubl")]
        public bool EmailUbl { get; set; }

        [JsonPropertyName("send_invoices_to_attention")]
        public string SendInvoicesToAttention { get; set; }

        [JsonPropertyName("send_invoices_to_email")]
        public string SendInvoicesToEmail { get; set; }

        [JsonPropertyName("send_estimates_to_attention")]
        public string SendEstimatesToAttention { get; set; }

        [JsonPropertyName("send_estimates_to_email")]
        public string SendEstimatesToEmail { get; set; }

        [JsonPropertyName("sepa_active")]
        public bool SepaActive { get; set; }

        [JsonPropertyName("sepa_iban")]
        public string SepaIban { get; set; }

        [JsonPropertyName("sepa_iban_account_name")]
        public string SepaIbanAccountName { get; set; }

        [JsonPropertyName("sepa_bic")]
        public string SepaBic { get; set; }

        [JsonPropertyName("sepa_mandate_id")]
        public string SepaMandateId { get; set; }

        [JsonPropertyName("sepa_mandate_date")]
        public DateTime? SepaMandateDate { get; set; }

        [JsonPropertyName("sepa_sequence_type")]
        public SepaSequenceType SepaSequenceType { get; set; }

        [JsonPropertyName("credit_card_number")]
        public string CreditCardNumber { get; set; }

        [JsonPropertyName("credit_card_reference")]
        public string CreditCardReference { get; set; }

        [JsonPropertyName("credit_card_type")]
        public object CreditCardType { get; set; }

        [JsonPropertyName("tax_number_validated_at")]
        public DateTime? TaxNumberValidatedAt { get; set; }

        [JsonPropertyName("tax_number_valid")]
        public bool? TaxNumberValid { get; set; }

        [JsonPropertyName("invoice_workflow_id")]
        public string InvoiceWorkflowId { get; set; }

        [JsonPropertyName("estimate_workflow_id")]
        public string EstimateWorkflowId { get; set; }

        [JsonPropertyName("si_identifier")]
        public string SiIdentifier { get; set; }

        [JsonPropertyName("si_identifier_type")]
        public string SiIdentifierTypeType { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("sales_invoices_url")]
        public string SalesInvoicesUrl { get; set; }

        [JsonPropertyName("notes")]
        public List<Note> Notes { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<ContactCustomFieldsAttribute> CustomFields { get; set; }

        [JsonPropertyName("contact_people")]
        public List<ContactPerson> ContactPeople { get; set; }

        [JsonPropertyName("events")]
        public List<Event> Events { get; set; }
    }
}
