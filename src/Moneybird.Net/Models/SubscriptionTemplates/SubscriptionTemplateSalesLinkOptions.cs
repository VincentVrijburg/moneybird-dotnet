using System;

namespace Moneybird.Net.Models.SubscriptionTemplates;

public class SubscriptionTemplateSalesLinkOptions
{
    public string ContactId { get; set; }

    public DateTime? StartDate { get; set; }

    public string ProductId { get; set; }
}
