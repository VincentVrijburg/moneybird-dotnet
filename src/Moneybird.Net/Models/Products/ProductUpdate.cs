using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Products;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Models.Products
{
    public class ProductUpdate
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        [JsonNumberHandling(JsonNumberHandling.WriteAsString)]
        public double Price { get; set; }

        [JsonPropertyName("document_style_id")]
        public string DocumentStyleId { get; set; }

        [JsonPropertyName("ledger_account_id")]
        public string LedgerAccountId { get; set; }

        [JsonPropertyName("tax_rate_id")]
        public string TaxRateId { get; set; }

        [JsonPropertyName("workflow_id")]
        public string WorkflowId { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("checkout_type")]
        public CheckoutType CheckoutType { get; set; }

        [JsonPropertyName("frequency_type")]
        public FrequencyType FrequencyType { get; set; }

        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }

        [JsonPropertyName("product_type")]
        public ProductType ProductType { get; set; }

        [JsonPropertyName("vat_rate_type")]
        public VatRateType VatRateType { get; set; }

        [JsonPropertyName("max_amount_per_order")]
        public int MaxAmountPerOrder { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("frequency_preset")]
        public string FrequencyPreset { get; set; }
    }
}
