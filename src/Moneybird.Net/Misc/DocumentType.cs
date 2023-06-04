using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum DocumentType
    {
        [JsonPropertyName("sales_invoice")]
        SalesInvoice,

        [JsonPropertyName("purchase_invoice")]
        PurchaseInvoice,

        [JsonPropertyName("general_journal_document")]
        GeneralJournalDocument,

        [JsonPropertyName("financial_mutation")]
        FinancialMutation,

        [JsonPropertyName("payment")]
        Payment
    }
}
