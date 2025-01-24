using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.TaxRates
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaxRateType
    {
        [JsonStringEnumMemberName("all")]
        All,
        
        [JsonStringEnumMemberName("general_journal_document")]
        GeneralJournalDocument,
        
        [JsonStringEnumMemberName("purchase_invoice")]
        PurchaseInvoice,
        
        [JsonStringEnumMemberName("sales_invoice")]
        SalesInvoice
    }
}
