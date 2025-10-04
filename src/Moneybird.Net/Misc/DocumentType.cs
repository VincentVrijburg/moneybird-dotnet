using System.Text.Json.Serialization;

namespace Moneybird.Net.Misc
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DocumentType
    {
        [JsonStringEnumMemberName("sales_invoice")]
        SalesInvoice,

        [JsonStringEnumMemberName("purchase_invoice")]
        PurchaseInvoice,

        [JsonStringEnumMemberName("general_journal_document")]
        GeneralJournalDocument,

        [JsonStringEnumMemberName("financial_mutation")]
        FinancialMutation,

        [JsonStringEnumMemberName("payment")]
        Payment
    }
}
