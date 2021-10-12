using System.Linq;

namespace Moneybird.Net.Extensions
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Convert a camelCase or PascalCase string to snake_case.
        /// </summary>
        /// <param name="value">The camelCase or PascalCase string.</param>
        /// <returns>The snake_case string.</returns>
        public static string ToSnakeCase(this string value) {
            return string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())).ToLower();
        }
    }
}