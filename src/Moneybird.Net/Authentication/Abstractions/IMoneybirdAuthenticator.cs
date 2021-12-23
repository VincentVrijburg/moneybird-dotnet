using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Authentication.Models;

namespace Moneybird.Net.Authentication.Abstractions
{
    /// <summary>
    /// The Moneybird authenticator.
    /// </summary>
    public interface IMoneybirdAuthenticator
    {
        /// <summary>
        /// Get the request token URI by scopes.
        /// </summary>
        /// <param name="scopes">A set of authentication scopes.</param>
        /// <returns>A request token URI.</returns>
        public Uri GetRequestTokenUri(IEnumerable<AuthScope> scopes = default);
        
        /// <summary>
        /// Get the access token by request token.
        /// </summary>
        /// <param name="requestToken">The request token.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The access token object.</returns>
        public Task<AccessToken> GetAccessTokenAsync(string requestToken, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Refresh the access token by refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token (from the access token object).</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The new (refreshed) access token object.</returns>
        public Task<AccessToken> RefreshAccessTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    }
}