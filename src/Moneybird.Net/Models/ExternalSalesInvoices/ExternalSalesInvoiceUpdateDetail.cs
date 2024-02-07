using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.ExternalSalesInvoices
{
    public class ExternalSalesInvoiceUpdateDetail
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// String with a date range: 20140101..20141231
        /// Presets are also allowed: this_month, prev_month, next_month, etc.
        /// </summary>
        [JsonPropertyName("period")]
        public string Period { get; set; }

        /// <summary>
        /// Both a decimal and a string ‘10,95’ are accepted.
        /// </summary>
        [JsonPropertyName("price")]
        public double? Price { get; set; }

        [JsonPropertyName("amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// Should be a valid tax rate id.
        /// </summary>
        [JsonPropertyName("tax_rate_id")]
        public string TaxRateId { get; set; }

        /// <summary>
        /// Should be a valid ledger account id.
        /// </summary>
        [JsonPropertyName("ledger_account_id")]
        public string LedgerAccountId { get; set; }

        /// <summary>
        /// Should be a valid project id.
        /// </summary>
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("row_order")]
        public int? RowOrder { get; set; }

        [JsonPropertyName("_destroy")]
        public bool? Destroy { get; set; }
    }
}
