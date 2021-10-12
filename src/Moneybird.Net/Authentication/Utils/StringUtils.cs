using System.Collections.Generic;
using System.Linq;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Extensions;

namespace Moneybird.Net.Authentication.Utils
{
    internal static class StringUtils
    {
        /// <summary>
        /// Get a string representation of the scopes.
        /// </summary>
        /// <param name="scopes">A set of authentication scopes.</param>
        /// <returns>A scope string.</returns>
        public static string GetScopeString(IEnumerable<AuthScope> scopes = null)
        {
            return scopes == null
                ? string.Empty
                : string.Join(" ", scopes.Select(s => s.ToString().ToSnakeCase()));
        }
        
        /// <summary>
        /// Get request token string by client id and redirect uri.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="redirectUri">The redirect uri.</param>
        /// <returns>A request token string.</returns>
        public static string GetRequestTokenString(string clientId, string redirectUri)
        {
            return $"client_id={clientId}&redirect_uri={redirectUri}&response_type=code";
        }
        
        /// <summary>
        /// Get request token string by client id, redirect uri and scopes.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="redirectUri">The redirect uri.</param>
        /// <param name="scope">The scope string</param>
        /// <returns>A request token string.</returns>
        public static string GetRequestTokenString(string clientId, string redirectUri , string scope)
        {
            return $"client_id={clientId}&redirect_uri={redirectUri}&response_type=code&scope={scope}";
        }
        
        /// <summary>
        /// Get access token string by client id, client secret, request token and redirect uri.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="requestToken">The request token.</param>
        /// <param name="redirectUri">The redirect uri.</param>
        /// <returns>An access token string.</returns>
        public static string GetAccessTokenString(string clientId, string clientSecret, string requestToken, string redirectUri)
        {
            return $"client_id={clientId}" +
                   $"&client_secret={clientSecret}" +
                   $"&code={requestToken}" +
                   $"&redirect_uri={redirectUri}" +
                   "&grant_type=authorization_code";
        }
        
        /// <summary>
        /// Get refresh token string by client id, client secret and refresh token.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="refreshToken">The refresh token.</param>
        /// <returns>A refresh token string.</returns>
        public static string GetRefreshTokenString(string clientId, string clientSecret, string refreshToken)
        {
            return $"client_id={clientId}" +
                   $"&client_secret={clientSecret}" +
                   $"&refresh_token={refreshToken}" +
                   "&grant_type=refresh_token";
        }
    }
}