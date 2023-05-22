using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public string AccountType { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("allowed_document_types")]
        public IReadOnlyList<AllowedDocumentType> AllowedDocumentTypes { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum AllowedDocumentType
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

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum AccountType
    {
        [JsonPropertyName("non_current_assets")]
        NonCurrentAssets,

        [JsonPropertyName("current_assets")]
        CurrentAssets,

        [JsonPropertyName("equity")]
        Equity,

        [JsonPropertyName("provisions")]
        Provisions,

        [JsonPropertyName("non_current_liabilities")]
        NonCurrentLiabilities,

        [JsonPropertyName("current_liabilities")]
        CurrentLiabilities,

        [JsonPropertyName("revenue")]
        Revenue,

        [JsonPropertyName("direct_costs")]
        DirectCosts,

        [JsonPropertyName("expenses")]
        Expenses,

        [JsonPropertyName("other_income_expenses")]
        OtherIncomeExpenses
    }
}
