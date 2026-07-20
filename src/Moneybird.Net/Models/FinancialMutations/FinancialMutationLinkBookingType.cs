using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.FinancialMutations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FinancialMutationLinkBookingType
    {
        [JsonStringEnumMemberName("SalesInvoice")]
        SalesInvoice,
        [JsonStringEnumMemberName("Document")]
        Document,
        [JsonStringEnumMemberName("LedgerAccount")]
        LedgerAccount,
        [JsonStringEnumMemberName("PaymentTransactionBatch")]
        PaymentTransactionBatch,
        [JsonStringEnumMemberName("PurchaseTransaction")]
        PurchaseTransaction,
        [JsonStringEnumMemberName("NewPurchaseInvoice")]
        NewPurchaseInvoice,
        [JsonStringEnumMemberName("NewReceipt")]
        NewReceipt,
        [JsonStringEnumMemberName("PaymentTransaction")]
        PaymentTransaction,
        [JsonStringEnumMemberName("PurchaseTransactionBatch")]
        PurchaseTransactionBatch,
        [JsonStringEnumMemberName("ExternalSalesInvoice")]
        ExternalSalesInvoice,
        [JsonStringEnumMemberName("Payment")]
        Payment,
        [JsonStringEnumMemberName("VatDocument")]
        VatDocument
    }
}
