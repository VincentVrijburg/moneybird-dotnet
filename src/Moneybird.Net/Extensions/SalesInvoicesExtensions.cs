using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Endpoints.SalesInvoices.Models;

namespace Moneybird.Net.Extensions
{
    public static class SalesInvoicesExtensions
    {
        public static string GetFilterString(this SalesInvoiceFilterOptions options)
        {
            var filterValues = new List<string>();

            if (options.State.HasValue)
            {
                filterValues.Add($"state:{options.State.Value}");
            }
            
            if (options.Period.HasValue)
            {
                filterValues.Add($"period:{options.Period.Value}");
            }
            
            if (!string.IsNullOrEmpty(options.Reference))
            {
                filterValues.Add($"reference:{options.Reference}");
            }

            if (options.ContactId.HasValue)
            {
                filterValues.Add($"contact_id:{options.ContactId.Value}");
            }
            
            if (options.RecurringSalesInvoiceId.HasValue)
            {
                filterValues.Add($"recurring_sales_invoice_id:{options.RecurringSalesInvoiceId.Value}");
            }
            
            if (options.WorkflowId.HasValue)
            {
                filterValues.Add($"workflow_id:{options.WorkflowId.Value}");
            }
            
            if (options.CreatedAfter.HasValue)
            {
                filterValues.Add($"created_after:{options.CreatedAfter.Value:O}");
            }

            if (options.UpdatedAfter.HasValue)
            {
                filterValues.Add($"updated_after:{options.UpdatedAfter.Value:O}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}