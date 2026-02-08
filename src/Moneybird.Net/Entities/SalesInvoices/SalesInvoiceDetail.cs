using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.SalesInvoices
{
    public class SalesInvoiceDetail
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
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Price { get; set; }

        [JsonPropertyName("period")]
        public string Period { get; set; }

        [JsonPropertyName("row_order")]
        public int RowOrder { get; set; }

        [JsonPropertyName("total_price_excl_tax_with_discount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalPriceExclTaxWithDiscount { get; set; }

        [JsonPropertyName("total_price_excl_tax_with_discount_base")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double TotalPriceExclTaxWithDiscountBase { get; set; }

        [JsonPropertyName("tax_report_reference")]
        public List<string> TaxReportReference { get; set; }

        [JsonPropertyName("mandatory_tax_text")]
        public string MandatoryTaxText { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonPropertyName("is_optional")]
        public bool IsOptional { get; set; }
        
        [JsonPropertyName("is_selected")]
        public bool IsSelected { get; set; }
    }
}
