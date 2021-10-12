using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Authentication.Models;

namespace Moneybird.Net.Authentication.Interfaces
{
    public interface IMoneybirdAuthenticator
    {
        public Uri GetRequestTokenUri(IEnumerable<AuthScope> scopes = default);
        public Task<AccessToken> GetAccessTokenAsync(string requestToken, CancellationToken cancellationToken = default);
        public Task<AccessToken> RefreshAccessTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    }
}