using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Authentication.Interfaces;
using Moneybird.Net.Authentication.Models;
using Moneybird.Net.Authentication.Utils;

namespace Moneybird.Net.Authentication
{
    public class MoneybirdAuthenticator : IMoneybirdAuthenticator, IDisposable
    {
        private readonly MoneybirdConfig _config;
        private readonly HttpClient _httpClient;

        public MoneybirdAuthenticator(MoneybirdConfig config)
        {
            ArgumentGuard.NotNull(config, nameof(config));
            ArgumentGuard.NotNullNorEmpty(config.AuthUri, nameof(config.AuthUri));
            ArgumentGuard.NotNullNorEmpty(config.ClientId, nameof(config.ClientId));
            ArgumentGuard.NotNullNorEmpty(config.ClientSecret, nameof(config.ClientSecret));
            ArgumentGuard.NotNullNorEmpty(config.RedirectUri, nameof(config.RedirectUri));
            
            _config = config;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_config.AuthUri)
            };
        }
        
        public Uri GetRequestTokenUri(IEnumerable<AuthScope> scopes = default)
        {
            var scopeString = StringUtils.GetScopeString(scopes);
            var requestTokenString = string.IsNullOrEmpty(scopeString)
                ? StringUtils.GetRequestTokenString(_config.ClientId, _config.RedirectUri)
                : StringUtils.GetRequestTokenString(_config.ClientId, _config.RedirectUri, scopeString);

            return new Uri(_httpClient.BaseAddress, $"authorize?{requestTokenString}");
        }

        public async Task<AccessToken> GetAccessTokenAsync(string requestToken, CancellationToken cancellationToken = default)
        {
            ArgumentGuard.NotNull(requestToken, nameof(requestToken));
            
            var accessTokenString = StringUtils.GetAccessTokenString(_config.ClientId, _config.ClientSecret, requestToken, _config.RedirectUri);
            return await RequestAccessTokenAsync(accessTokenString, cancellationToken);
        }

        public async Task<AccessToken> RefreshAccessTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
        {
            ArgumentGuard.NotNull(refreshToken, nameof(refreshToken));
            
            var refreshTokenString = StringUtils.GetRefreshTokenString(_config.ClientId, _config.ClientSecret, refreshToken);
            return await RequestAccessTokenAsync(refreshTokenString, cancellationToken);
        }
        
        private async Task<AccessToken> RequestAccessTokenAsync(string tokenString, CancellationToken cancellationToken = default)
        {
            ArgumentGuard.NotNull(tokenString, nameof(tokenString));
            
            using var body = new StringContent(
                tokenString,
                Encoding.Default,
                "application/x-www-form-urlencoded");
            
            var response = await _httpClient.PostAsync("token", body, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<AccessToken>(content);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}