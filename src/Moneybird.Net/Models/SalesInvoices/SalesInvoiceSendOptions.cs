using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.SalesInvoices
{
    public class SalesInvoiceSendOptions
    {
        [JsonPropertyName("sales_invoice_sending")]
        public SalesInvoiceSend SalesInvoiceSend { get; set; }
    }
}
