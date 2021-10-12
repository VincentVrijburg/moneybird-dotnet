using System;
using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Extensions;

namespace Moneybird.Net.Authentication.Utils
{
    internal static class StringUtils
    {
        public static string GetScopeString(IEnumerable<AuthScope> scopes = null)
        {
            return scopes == null
                ? string.Empty
                : string.Join(" ", scopes.Select(s => s.ToString().ToSnakeCase()));
        }
        
        public static string GetRequestTokenString(string clientId, string redirectUri)
        {
            return $"client_id={clientId}&redirect_uri={redirectUri}&response_type=code";
        }
        
        public static string GetRequestTokenString(string clientId, string redirectUri , string scopes)
        {
            return $"client_id={clientId}&redirect_uri={redirectUri}&response_type=code&scope={scopes}";
        }
        
        public static string GetAccessTokenString(string clientId, string clientSecret, string requestToken, string redirectUri)
        {
            return $"client_id={clientId}" +
                   $"&client_secret={clientSecret}" +
                   $"&code={requestToken}" +
                   $"&redirect_uri={redirectUri}" +
                   "&grant_type=authorization_code";
        }
        
        public static string GetRefreshTokenString(string clientId, string clientSecret, string refreshToken)
        {
            return $"client_id={clientId}" +
                   $"&client_secret={clientSecret}" +
                   $"&refresh_token={refreshToken}" +
                   "&grant_type=refresh_token";
        }
    }
}