using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.SaleInvoices
{
    /// <remarks>
    /// https://developer.moneybird.com/api/sales_invoices/#post_sales_invoices
    /// </remarks>
    public class SaleInvoiceCreateOptions
    {
        [JsonPropertyName("sales_invoice")]
        public SaleInvoiceCreate SaleInvoice { get; set; }

        [JsonPropertyName("from_checkout")]
        public bool? FromCheckout { get; set; }
    }
}
