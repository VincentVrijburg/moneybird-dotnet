using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Models.GeneralDocuments;

namespace Moneybird.Net.Extensions;

internal static class GeneralDocumentsExtensions
{
    public static string GetFilterString(this GeneralDocumentFilterOptions options)
    {
        var filterValues = new List<string>();

        if (!string.IsNullOrEmpty(options.Period))
        {
            filterValues.Add($"period:{options.Period}");
        }

        if (options.State != null && options.State.Any())
        {
            filterValues.Add($"state:{string.Join("|", options.State.Select(state => state.ToString().ToSnakeCase()))}");
        }

        if (options.Recurring != null && options.Recurring.Any())
        {
            filterValues.Add($"recurring:{string.Join("|", options.Recurring.Select(recurring => recurring.ToString().ToSnakeCase()))}");
        }

        if (options.Attachment != null && options.Attachment.Any())
        {
            filterValues.Add($"attachment:{string.Join("|", options.Attachment.Select(attachment => attachment.ToString().ToSnakeCase()))}");
        }

        if (!string.IsNullOrEmpty(options.Reference))
        {
            filterValues.Add($"reference:{options.Reference}");
        }

        if (!string.IsNullOrEmpty(options.ContactId))
        {
            filterValues.Add($"contact_id:{options.ContactId}");
        }

        if (!string.IsNullOrEmpty(options.LedgerAccountId))
        {
            filterValues.Add($"ledger_account_id:{options.LedgerAccountId}");
        }

        if (!string.IsNullOrEmpty(options.UpdatedAfter))
        {
            filterValues.Add($"updated_after:{options.UpdatedAfter}");
        }

        return filterValues.Any()
            ? $"filter={string.Join(",", filterValues)}"
            : string.Empty;
    }
}
