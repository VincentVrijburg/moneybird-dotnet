using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Entities.LedgerAccounts
{
    public class LedgerAccount : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public string AdministrationId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("account_type")]
        public LedgerAccountType AccountType { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }
        
        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("allowed_document_types")]
        public List<DocumentType> AllowedDocumentTypes { get; set; }
        
        [JsonPropertyName("taxonomy_item")]
        public TaxonomyItem TaxonomyItem { get; set; }
        
        [JsonPropertyName("financial_account_id")]
        public string FinancialAccountId { get; set; }
    }
}
