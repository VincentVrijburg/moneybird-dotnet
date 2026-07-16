using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.RecurringSalesInvoices
{
    public class RecurringSalesInvoiceUpdateDetail
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("period")]
        public string Period { get; set; }
        
        [JsonPropertyName("price")]
        public double? Price { get; set; }
        
        [JsonPropertyName("amount")]
        public double? Amount { get; set; }
        
        [JsonPropertyName("tax_rate_id")]
        public string TaxRateId { get; set; }
        
        [JsonPropertyName("ledger_account_id")]
        public string LedgerAccountId { get; set; }
        
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }
        
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }
        
        [JsonPropertyName("row_order")]
        public int? RowOrder { get; set; }
        
        [JsonPropertyName("_destroy")]
        public bool? Destroy { get; set; }
        
        [JsonPropertyName("automated_tax_enabled")]
        public bool? AutomatedTaxEnabled { get; set; }
    }
}
