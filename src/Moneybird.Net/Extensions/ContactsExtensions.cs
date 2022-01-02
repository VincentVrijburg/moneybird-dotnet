using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Endpoints.Contacts.Models;

namespace Moneybird.Net.Extensions
{
    internal static class ContactsExtensions
    {
        public static string GetFilterString(this ContactFilterOptions options)
        {
            var filterValues = new List<string>();

            if (options.CreatedAfter.HasValue)
            {
                filterValues.Add($"created_after:{options.CreatedAfter.Value:O}");
            }

            if (options.UpdatedAfter.HasValue)
            {
                filterValues.Add($"updated_after:{options.UpdatedAfter.Value:O}");
            }
            
            if (!string.IsNullOrEmpty(options.FirstName))
            {
                filterValues.Add($"first_name:{options.FirstName}");
            }
            
            if (!string.IsNullOrEmpty(options.LastName))
            {
                filterValues.Add($"last_name:{options.LastName}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}