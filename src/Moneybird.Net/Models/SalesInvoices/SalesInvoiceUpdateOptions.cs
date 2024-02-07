using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Models.SalesInvoices
{
    public class SalesInvoiceUpdateOptions : IMoneybirdUpdateOptions
    {
        [JsonPropertyName("sales_invoice")]
        public SalesInvoiceUpdate SalesInvoice { get; set; }
    }
}