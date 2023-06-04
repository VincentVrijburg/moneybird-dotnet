using System.Text.Json.Serialization;
using Moneybird.Net.Endpoints.Abstractions.Options;

namespace Moneybird.Net.Endpoints.SalesInvoices.Models
{
    /// <remarks>
    /// https://developer.moneybird.com/api/sales_invoices/#post_sales_invoices
    /// </remarks>
    public class SalesInvoiceCreateOptions : IMoneybirdCreateOptions
    {
        [JsonPropertyName("sales_invoice")]
        public SalesInvoiceCreate SalesInvoice { get; set; }

        [JsonPropertyName("from_checkout")]
        public bool? FromCheckout { get; set; }
    }
}
