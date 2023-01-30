using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using Moneybird.Net.Authentication;
using Moneybird.Net.Authentication.Abstractions;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Authentication.Models;
using Moneybird.Net.Authentication.Utils;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Authentication
{
    public class MoneybirdAuthenticatorTests : CommonTestBase
    {
        private const string AccessTokenPath = "./Responses/Authentication/accessToken.json";
        
        [Fact]
        public void GetRequestTokenUri_ForOutOfBand_Returns_CorrectUri()
        {
            var moneybirdConfig = new MoneybirdConfig(ClientId, ClientSecret, RedirectUriOutOfBand);
            var expectedRequestTokenUri = new Uri($"{moneybirdConfig.AuthUri}authorize?client_id={ClientId}&redirect_uri={RedirectUriOutOfBand}&response_type=code");
            
            using var authenticator = new MoneybirdAuthenticator(moneybirdConfig);
            
            Assert.Equal(expectedRequestTokenUri, authenticator.GetRequestTokenUri());
        }
        
        [Fact]
        public void GetRequestTokenUri_ForOutOfBand_WithScopes_Returns_CorrectUri()
        {
            var moneybirdConfig = new MoneybirdConfig(ClientId, ClientSecret, RedirectUriOutOfBand);
            var scopes = new[] {AuthScope.SalesInvoices, AuthScope.Bank};
            var scopeString = StringUtils.GetScopeString(scopes);
            var expectedRequestTokenUri = new Uri($"{moneybirdConfig.AuthUri}authorize?client_id={ClientId}&redirect_uri={RedirectUriOutOfBand}&response_type=code&scope={scopeString}");

            using var authenticator = new MoneybirdAuthenticator(moneybirdConfig);
            
            Assert.Equal(expectedRequestTokenUri, authenticator.GetRequestTokenUri(scopes));
        }
        
        [Fact]
        public void GetRequestTokenUri_ForEndUser_Returns_CorrectUri()
        {
            var moneybirdConfig = new MoneybirdConfig(ClientId, ClientSecret, RedirectUriEndUser);
            var expectedRequestTokenUri = new Uri($"{moneybirdConfig.AuthUri}authorize?client_id={ClientId}&redirect_uri={RedirectUriEndUser}&response_type=code");
            
            using var authenticator = new MoneybirdAuthenticator(moneybirdConfig);

            Assert.Equal(expectedRequestTokenUri, authenticator.GetRequestTokenUri());
        }
        
        [Fact]
        public void GetRequestTokenUri_ForEndUser_WithScopes_Returns_CorrectUri()
        {
            var moneybirdConfig = new MoneybirdConfig(ClientId, ClientSecret, RedirectUriEndUser);
            var scopes = new[] {AuthScope.SalesInvoices, AuthScope.Bank};
            var scopeString = StringUtils.GetScopeString(scopes);
            var expectedRequestTokenUri = new Uri($"{moneybirdConfig.AuthUri}authorize?client_id={ClientId}&redirect_uri={RedirectUriEndUser}&response_type=code&scope={scopeString}");

            using var authenticator = new MoneybirdAuthenticator(moneybirdConfig);
            
            Assert.Equal(expectedRequestTokenUri, authenticator.GetRequestTokenUri(scopes));
        }

        [Fact]
        public async void GetGetAccessToken_With_RequestToken_Returns_CorrectAccessToken()
        {
            var accessTokenJson = await File.ReadAllTextAsync(AccessTokenPath);
            var expectedAccessToken = JsonSerializer.Deserialize<AccessToken>(accessTokenJson);
            
            var mockAuthenticator = new Mock<IMoneybirdAuthenticator>();
            mockAuthenticator
                .Setup(moq => moq.GetAccessTokenAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedAccessToken);

            var actualAccessToken = await mockAuthenticator.Object.GetAccessTokenAsync(AccessToken, CancellationToken.None);
            
            Assert.Equal(expectedAccessToken, actualAccessToken);
        }
        
        [Fact]
        public async void GetGetAccessToken_Without_RequestToken_Throws_ArgumentNullException()
        {
            var config = new MoneybirdConfig(ClientId, ClientSecret, RedirectUriEndUser);
            using var authenticator = new MoneybirdAuthenticator(config);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await authenticator.GetAccessTokenAsync(null, CancellationToken.None));
        }
    }
}