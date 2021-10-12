using System;
using System.Linq;

namespace Moneybird.Net.Extensions
{
    internal static class StringExtensions
    {
        public static string ToSnakeCase(this string value) {
            return string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())).ToLower();
        }
        
        public static string UrlEncode(this string input)
        {
            return Uri.EscapeDataString(input);
        }
    }
}