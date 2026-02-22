using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.SalesInvoices;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SalesInvoiceAttachmentType
{
    [JsonStringEnumMemberName("SalesInvoice")]
    SalesInvoice,
    
    [JsonStringEnumMemberName("RecurringSalesInvoice")]
    RecurringSalesInvoice,
    
    [JsonStringEnumMemberName("Document")]
    Document,
    
    [JsonStringEnumMemberName("FinancialStatement")]
    FinancialStatement,
    
    [JsonStringEnumMemberName("Workflow")]
    Workflow,
    
    [JsonStringEnumMemberName("Estimate")]
    Estimate,
    
    [JsonStringEnumMemberName("ExternalSalesInvoice")]
    ExternalSalesInvoice
}