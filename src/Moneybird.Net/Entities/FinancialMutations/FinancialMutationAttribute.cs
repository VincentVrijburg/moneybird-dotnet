using System;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.FinancialMutations
{
    public class FinancialMutationAttribute
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("valutation_date")]
        public DateTime ValutationDate { get; set; }
        
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        [JsonPropertyName("amount")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Amount { get; set; }
        
        [JsonPropertyName("code")]
        public string Code { get; set; }
        
        [JsonPropertyName("contra_account_name")]
        public string ContraAccountName { get; set; }
        
        [JsonPropertyName("contra_account_number")]
        public string ContraAccountNumber { get; set; }
        
        [JsonPropertyName("batch_reference")]
        public string BatchReference { get; set; }
        
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
        
        [JsonPropertyName("account_servicer_transaction_id")]
        public string AccountServicerTransactionId { get; set; }
        
        [JsonPropertyName("adyen_payment_instrument_id")]
        public int AdyenPaymentInstrumentId { get; set; }
        
        [JsonPropertyName("_destroy")]
        public bool Destroy { get; set; }
    }
}