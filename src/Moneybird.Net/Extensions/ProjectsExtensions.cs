using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Models.Projects;

namespace Moneybird.Net.Extensions
{
    internal static class ProjectsExtensions
    {
        public static string GetFilterString(this ProjectFilterOptions options)
        {
            var filterValues = new List<string>();

            if (options.State.HasValue)
            {
                filterValues.Add($"state:{options.State.Value.ToString().ToSnakeCase()}");
            }

            return filterValues.Any()
                ? $"filter={string.Join(",", filterValues)}"
                : string.Empty;
        }
    }
}