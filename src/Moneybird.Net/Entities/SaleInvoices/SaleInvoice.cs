using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.CustomFields;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Entities.Payments;

namespace Moneybird.Net.Entities.SaleInvoices
{
    public class SaleInvoiceDetail
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("tax_rate_id")]
        public string TaxRateId { get; set; }

        [JsonPropertyName("ledger_account_id")]
        public string LedgerAccountId { get; set; }

        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("amount_decimal")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double AmountDecimal { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("period")]
        public string Period { get; set; }

        [JsonPropertyName("row_order")]
        public int RowOrder { get; set; }

        [JsonPropertyName("total_price_excl_tax_with_discount")]
        public string TotalPriceExclTaxWithDiscount { get; set; }

        [JsonPropertyName("total_price_excl_tax_with_discount_base")]
        public string TotalPriceExclTaxWithDiscountBase { get; set; }

        [JsonPropertyName("tax_report_reference")]
        public List<string> TaxReportReference { get; set; }

        [JsonPropertyName("mandatory_tax_text")]
        public string MandatoryTaxText { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class SaleInvoice
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
        public string ContactPerson { get; set; }

        [JsonPropertyName("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonPropertyName("recurring_sales_invoice_id")]
        public string RecurringSalesInvoiceId { get; set; }

        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonPropertyName("document_style_id")]
        public string DocumentStyleId { get; set; }

        [JsonPropertyName("identity_id")]
        public string IdentityId { get; set; }

        [JsonPropertyName("draft_id")]
        public int DraftId { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("invoice_date")]
        public string InvoiceDate { get; set; }

        [JsonPropertyName("due_date")]
        public string DueDate { get; set; }

        [JsonPropertyName("payment_conditions")]
        public string PaymentConditions { get; set; }

        [JsonPropertyName("payment_reference")]
        public string PaymentReference { get; set; }

        [JsonPropertyName("short_payment_reference")]
        public string ShortPaymentReference { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("discount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Discount { get; set; }

        [JsonPropertyName("original_sales_invoice_id")]
        public string OriginalSalesInvoiceId { get; set; }

        [JsonPropertyName("paused")]
        public bool Paused { get; set; }

        [JsonPropertyName("paid_at")]
        public string PaidAt { get; set; }

        [JsonPropertyName("sent_at")]
        public string SentAt { get; set; }

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

        [JsonPropertyName("details")]
        public List<SaleInvoiceDetail> Details { get; set; }

        [JsonPropertyName("payments")]
        public List<Payment> Payments { get; set; }

        [JsonPropertyName("total_paid")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalPaid { get; set; }

        [JsonPropertyName("total_unpaid")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalUnpaid { get; set; }

        [JsonPropertyName("total_unpaid_base")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalUnpaidBase { get; set; }

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

        [JsonPropertyName("marked_dubious_on")]
        public string MarkedDubiousOn { get; set; }

        [JsonPropertyName("marked_uncollectible_on")]
        public string MarkedUncollectibleOn { get; set; }

        [JsonPropertyName("reminder_count")]
        public int ReminderCount { get; set; }

        [JsonPropertyName("next_reminder")]
        public string NextReminder { get; set; }

        [JsonPropertyName("original_estimate_id")]
        public string OriginalEstimateId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("payment_url")]
        public string PaymentUrl { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<SaleInvoiceCustomField> CustomFields { get; set; }

        [JsonPropertyName("tax_totals")]
        public List<SaleInvoiceTaxTotal> TaxTotals { get; set; }
    }

    public class SaleInvoiceTaxTotal
    {
        [JsonPropertyName("tax_rate_id")]
        public string TaxRateId { get; set; }

        [JsonPropertyName("taxable_amount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TaxableAmount { get; set; }

        [JsonPropertyName("taxable_amount_base")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TaxableAmountBase { get; set; }

        [JsonPropertyName("tax_amount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TaxAmount { get; set; }

        [JsonPropertyName("tax_amount_base")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TaxAmountBase { get; set; }
    }


}
