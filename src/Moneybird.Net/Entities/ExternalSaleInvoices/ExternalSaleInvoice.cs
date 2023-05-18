using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Entities.Payments;
using Moneybird.Net.Entities.SaleInvoices;

namespace Moneybird.Net.Entities.ExternalSaleInvoices
{
    public class ExternalSaleInvoiceDetail
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

    public class ExternalSaleInvoice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("due_date")]
        public string DueDate { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("paid_at")]
        public string PaidAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

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

        [JsonPropertyName("marked_dubious_on")]
        public string MarkedDubiousOn { get; set; }

        [JsonPropertyName("marked_uncollectible_on")]
        public string MarkedUncollectibleOn { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("source_url")]
        public string SourceUrl { get; set; }

        [JsonPropertyName("payment_url")]
        public string PaymentUrl { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<ExternalSaleInvoiceCustomField> CustomFields { get; set; }

        [JsonPropertyName("tax_totals")]
        public List<ExternalSaleInvoiceTaxTotal> TaxTotals { get; set; }
    }

    public class ExternalSaleInvoiceTaxTotal
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
