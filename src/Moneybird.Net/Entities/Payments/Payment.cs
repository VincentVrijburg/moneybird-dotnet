using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Payments
{
    public class Payment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("invoice_type")]
        public string InvoiceType { get; set; }

        [JsonPropertyName("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonPropertyName("financial_account_id")]
        public string FinancialAccountId { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("payment_transaction_id")]
        public object PaymentTransactionId { get; set; }

        [JsonPropertyName("transaction_identifier")]
        public object TransactionIdentifier { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("price_base")]
        public string PriceBase { get; set; }

        [JsonPropertyName("payment_date")]
        public DateTime PaymentDate { get; set; }

        [JsonPropertyName("credit_invoice_id")]
        public object CreditInvoiceId { get; set; }

        [JsonPropertyName("financial_mutation_id")]
        public string FinancialMutationId { get; set; }

        [JsonPropertyName("ledger_account_id")]
        public string LedgerAccountId { get; set; }

        [JsonPropertyName("linked_payment_id")]
        public object LinkedPaymentId { get; set; }

        [JsonPropertyName("manual_payment_action")]
        public object ManualPaymentAction { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}