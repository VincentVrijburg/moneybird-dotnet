using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Payments
{
    public class Payment : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("invoice_type")]
        public PaymentInvoiceType InvoiceType { get; set; }

        [JsonPropertyName("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonPropertyName("financial_account_id")]
        public string FinancialAccountId { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("payment_transaction_id")]
        public string PaymentTransactionId { get; set; }

        [JsonPropertyName("transaction_identifier")]
        public string TransactionIdentifier { get; set; }

        [JsonPropertyName("price")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? Price { get; set; }

        [JsonPropertyName("price_base")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double? PriceBase { get; set; }

        [JsonPropertyName("payment_date")]
        public DateTime PaymentDate { get; set; }

        [JsonPropertyName("credit_invoice_id")]
        public string CreditInvoiceId { get; set; }

        [JsonPropertyName("financial_mutation_id")]
        public string FinancialMutationId { get; set; }

        [JsonPropertyName("ledger_account_id")]
        public string LedgerAccountId { get; set; }

        [JsonPropertyName("linked_payment_id")]
        public string LinkedPaymentId { get; set; }

        [JsonPropertyName("manual_payment_action")]
        public string ManualPaymentAction { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
