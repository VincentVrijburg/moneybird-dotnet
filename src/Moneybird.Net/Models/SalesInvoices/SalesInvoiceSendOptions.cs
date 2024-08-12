using Moneybird.Net.Misc;
using System.Text.Json.Serialization;

namespace Moneybird.Net.Models.SalesInvoices
{
    public class SalesInvoiceSendOptions
    {
        [JsonPropertyName("delivery_method")]
        public DeliveryMethod DeliveryMethod { get; set; }

        [JsonPropertyName("sending_scheduled")]
        public bool SendingScheduled { get; set; }

        [JsonPropertyName("sending_ubl")]
        public bool SendingUbl { get; set; }

        [JsonPropertyName("mergable")]
        public bool Mergeable { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("email_message")]
        public string EmailMessage { get; set; }

        [JsonPropertyName("invoice_date")]
        public string InvoiceDate { get; set; }
    }
}
