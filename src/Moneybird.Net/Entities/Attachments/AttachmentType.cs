using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Attachments;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AttachmentType
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
