using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Downloads
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DownloadType
    {
        [JsonStringEnumMemberName("auditfile")]
        Auditfile,

        [JsonStringEnumMemberName("brugstaat")]
        Brugstaat,

        [JsonStringEnumMemberName("export_contacts")]
        ExportContacts,

        [JsonStringEnumMemberName("export_documents")]
        ExportDocuments,

        [JsonStringEnumMemberName("export_documents_details")]
        ExportDocumentsDetails,

        [JsonStringEnumMemberName("export_financial_mutations")]
        ExportFinancialMutations,

        [JsonStringEnumMemberName("export_ledger_account_report")]
        ExportLedgerAccountReport,

        [JsonStringEnumMemberName("export_report_profit_loss")]
        ExportReportProfitLoss,

        [JsonStringEnumMemberName("export_sales_invoices")]
        ExportSalesInvoices,

        [JsonStringEnumMemberName("export_time_entries")]
        ExportTimeEntries
    }
}
