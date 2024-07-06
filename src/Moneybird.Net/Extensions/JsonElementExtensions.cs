using System.Linq;
using System.Text.Json;

namespace Moneybird.Net.Extensions
{
    internal static class JsonElementExtensions
    {
        /// <summary>
        /// Get the error message from the error JsonElement.
        /// </summary>
        /// <param name="jsonElement">The JsonElement from the error response content.</param>
        /// <returns>The error message as a string.</returns>
        public static string GetErrorMessage(this JsonElement jsonElement) {
            var error = jsonElement.GetProperty("error");
            var message = error.ValueKind switch
            {
                JsonValueKind.Object => string.Join(", ", error.EnumerateObject().SelectMany(prop => prop.Value.EnumerateArray().Select(val => $"{prop.Name}: {val.GetString()}")).ToList()),
                _ => error.GetString(),
            };

            return message;
        }
    }
}