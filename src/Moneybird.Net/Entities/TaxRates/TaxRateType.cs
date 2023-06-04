using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.TaxRates
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum TaxRateType
    {
        [JsonPropertyName("all")]
        All,
        
        [JsonPropertyName("general_journal_document")]
        GeneralJournalDocument,
        
        [JsonPropertyName("purchase_invoice")]
        PurchaseInvoice,
        
        [JsonPropertyName("sales_invoice")]
        SalesInvoice
    }
}
