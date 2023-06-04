using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.LedgerAccounts;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Endpoints.LegderAccounts.Models
{
    public class LedgerAccountUpdate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }
        
        [JsonPropertyName("account_type")]
        public LedgerAccountType AccountType { get; set; }

        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }
        
        [JsonPropertyName("allowed_document_types")]
        public IReadOnlyList<DocumentType> AllowedDocumentTypes { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
