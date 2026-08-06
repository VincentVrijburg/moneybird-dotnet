using System;
using System.Collections.Generic;
using Moneybird.Net.Models.SubscriptionTemplates;

namespace Moneybird.Net.Extensions;

internal static class SubscriptionTemplatesExtensions
{
    public static List<string> GetQueryParameters(this SubscriptionTemplateSalesLinkOptions options)
    {
        if (options == null)
        {
            return null;
        }

        var queryParameters = new List<string>();

        if (!string.IsNullOrWhiteSpace(options.ContactId))
        {
            queryParameters.Add($"contact_id={Uri.EscapeDataString(options.ContactId)}");
        }

        if (options.StartDate.HasValue)
        {
            queryParameters.Add($"start_date={options.StartDate.Value:yyyy-MM-dd}");
        }

        if (!string.IsNullOrWhiteSpace(options.ProductId))
        {
            queryParameters.Add($"product_id={Uri.EscapeDataString(options.ProductId)}");
        }

        return queryParameters.Count > 0 ? queryParameters : null;
    }
}
