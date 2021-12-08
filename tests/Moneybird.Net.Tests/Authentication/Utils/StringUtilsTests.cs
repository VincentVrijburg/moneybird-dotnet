using System.IO;
using System.Text.Json;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Authentication.Models;
using Moneybird.Net.Authentication.Utils;
using Moneybird.Net.Extensions;
using Xunit;

namespace Moneybird.Net.Tests.Authentication.Utils
{
    public class StringUtilsTests : CommonTestBase
    {
        [Fact]
        public void GetScopeString_Empty_Returns_EmptyString()
        {
            var actualScopeString = StringUtils.GetScopeString();
            
            Assert.Equal(string.Empty, actualScopeString);
        }
        
        [Fact]
        public void GetScopeString_Returns_CorrectString()
        {
            var scopes = new[] {AuthScope.SalesInvoices, AuthScope.Bank, AuthScope.Settings};
            var expectedScopeString =
                $"{AuthScope.SalesInvoices.ToString().ToSnakeCase()} " +
                $"{AuthScope.Bank.ToString().ToSnakeCase()} " +
                $"{AuthScope.Settings.ToString().ToSnakeCase()}";

            var actualScopeString = StringUtils.GetScopeString(scopes);
            
            Assert.Equal(expectedScopeString, actualScopeString);
        }
        
        [Fact]
        public void GetRequestTokenString_WihtoutScopes_Returns_CorrectString()
        {
            var expectedUrlWithoutScope = $"client_id={ClientId}&redirect_uri={RedirectUriOutOfBand}&response_type=code";
            var actualUrlWithoutScope = StringUtils.GetRequestTokenString(ClientId, RedirectUriOutOfBand);
            
            Assert.True(expectedUrlWithoutScope.Equals(actualUrlWithoutScope));
        }
        
        [Fact]
        public void GetRequestTokenString_WithScopes_Returns_CorrectString()
        {
            var scopes = new[] {AuthScope.SalesInvoices};
            var scopeString = StringUtils.GetScopeString(scopes);
            var expectedUrlWithScope = $"client_id={ClientId}&redirect_uri={RedirectUriOutOfBand}&response_type=code&scope={scopeString}";
            var actualUrlWithScope = StringUtils.GetRequestTokenString(ClientId, RedirectUriOutOfBand, scopeString);
            
            Assert.True(expectedUrlWithScope.Equals(actualUrlWithScope));
        }
        
        [Fact]
        public void GetAccessTokenString_Returns_CorrectString()
        {
            var expectedTokenString = $"client_id={ClientId}&client_secret={ClientSecret}&code={RequestToken}&redirect_uri={RedirectUriOutOfBand}&grant_type=authorization_code";
            var actualTokenString = StringUtils.GetAccessTokenString(ClientId, ClientSecret, RequestToken, RedirectUriOutOfBand);
            
            Assert.True(expectedTokenString.Equals(actualTokenString));
        }
        
        [Fact]
        public async void GetRefreshTokenString_Returns_CorrectString()
        {
            var accessTokenJson = await File.ReadAllTextAsync("./Responses/Authentication/accessToken.json");
            var accessToken = JsonSerializer.Deserialize<AccessToken>(accessTokenJson);
            
            Assert.NotNull(accessToken);

            var expectedTokenString = $"client_id={ClientId}&client_secret={ClientSecret}&refresh_token={accessToken.RefreshToken}&grant_type=refresh_token";
            var actualTokenString = StringUtils.GetRefreshTokenString(ClientId, ClientSecret, accessToken.RefreshToken);
            
            Assert.True(expectedTokenString.Equals(actualTokenString));
        }
    }
}