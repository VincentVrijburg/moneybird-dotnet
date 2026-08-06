using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Models.SalesInvoices;

namespace Moneybird.Net.Models.Subscriptions;

public class SubscriptionOneOffSalesInvoiceCreate
{
    [JsonPropertyName("details_attributes")]
    public List<SalesInvoiceCreateDetail> DetailsAttributes { get; set; }

    [JsonPropertyName("invoice_date")]
    public DateTime? InvoiceDate { get; set; }
}
