using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Verifications
{
    public class Verification
    {
        [JsonPropertyName("emails")]
        public List<string> Emails { get; set; }
        
        [JsonPropertyName("bank_account_numbers")]
        public List<string> BankAccountNumbers { get; set; }
        
        [JsonPropertyName("chamber_of_commerce_number")]
        public string ChamberOfCommerceNumber { get; set; }
        
        [JsonPropertyName("tax_number")]
        public string TaxNumber { get; set; }
    }
}