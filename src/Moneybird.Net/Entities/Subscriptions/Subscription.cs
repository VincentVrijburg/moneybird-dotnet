using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Entities.Products;
using Moneybird.Net.Misc;

namespace Moneybird.Net.Entities.Subscriptions
{
    public class Subscription : IMoneybirdEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("administration_id")]
        public int AdministrationId { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("frequency")]
        public int Frequency { get; set; }

        [JsonPropertyName("frequency_type")]
        public FrequencyType FrequencyType { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("cancelled_at")]
        public DateTime CancelledAt { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("product")]
        public Product Product { get; set; }

        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }

        [JsonPropertyName("contact_person_id")]
        public string ContactPersonId { get; set; }

        [JsonPropertyName("contact_person")]
        public ContactPerson ContactPerson { get; set; }

        [JsonPropertyName("subscription_products")]
        public List<SubscriptionProduct> SubscriptionProducts { get; set; }

        [JsonPropertyName("recurring_sales_invoice_id")]
        public string RecurringSalesInvoiceId { get; set; }
    }
}