using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.CustomFields;

namespace Moneybird.Net.Models.Identities
{
    public class IdentityCreate
    {
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("bank_account_name")]
        public string BankAccountName { get; set; }

        [JsonPropertyName("bank_account_number")]
        public string BankAccountNumber { get; set; }

        [JsonPropertyName("bank_account_bic")]
        public string BankAccountBic { get; set; }

        [JsonPropertyName("custom_fields_attributes")]
        public List<CustomFieldAttribute> CustomFieldsAttributes { get; set; }

        [JsonPropertyName("chamber_of_commerce")]
        public string ChamberOfCommerce { get; set; }

        [JsonPropertyName("tax_number")]
        public string TaxNumber { get; set; }
    }
}
