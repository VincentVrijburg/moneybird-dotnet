using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.RecurringSalesInvoices
{
    public class RecurringSalesInvoiceCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("recurring_sales_invoice")]
        public RecurringSalesInvoiceCreate RecurringSalesInvoice { get; set; }
    }
}
