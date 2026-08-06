using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Moneybird.Net.Models.SalesInvoices;

namespace Moneybird.Net.Models.Subscriptions;

public class SubscriptionOneOffSalesInvoiceCreateOptions
{
    [JsonPropertyName("sales_invoice")]
    public SubscriptionOneOffSalesInvoiceCreate SalesInvoice { get; set; }
}
