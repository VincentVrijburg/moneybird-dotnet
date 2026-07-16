using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.RecurringSalesInvoices
{
    public class RecurringSalesInvoiceUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("recurring_sales_invoice")]
        public RecurringSalesInvoiceUpdate RecurringSalesInvoice { get; set; }
    }
}
