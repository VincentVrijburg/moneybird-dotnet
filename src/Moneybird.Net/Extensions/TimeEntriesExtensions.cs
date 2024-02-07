using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Models.TimeEntries;

namespace Moneybird.Net.Extensions
{
    internal static class TimeEntriesExtensions
    {
        public static string GetFilterString(this TimeEntryFilterOptions options)
        {
            var filterValues = new List<string>();

            if (options.State != null && options.State.Any())
            {
                filterValues.Add($"state:{string.Join("|", options.State.Select(s => s.ToString().ToSnakeCase()))}");
            }
            
            if (!string.IsNullOrEmpty(options.Period))
            {
                filterValues.Add($"period:{options.Period}");
            }
            
            if (!string.IsNullOrEmpty(options.ContactId))
            {
                filterValues.Add($"contact_id:{options.ContactId}");
            }
            
            if (options.IncludeNilContacts.HasValue)
            {
                filterValues.Add($"include_nil_contacts:{options.IncludeNilContacts.Value.ToString().ToLowerInvariant()}");
            }
            
            if (options.IncludeActive.HasValue)
            {
                filterValues.Add($"include_active:{options.IncludeActive.Value.ToString().ToLowerInvariant()}");
            }
            
            if (!string.IsNullOrEmpty(options.ProjectId))
            {
                filterValues.Add($"project_id:{options.ProjectId}");
            }
            
            if (!string.IsNullOrEmpty(options.UserId))
            {
                filterValues.Add($"user_id:{options.UserId}");
            }
            
            if (options.Day != default)
            {
                filterValues.Add($"day:{options.Day:yyyy-MM-dd}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}