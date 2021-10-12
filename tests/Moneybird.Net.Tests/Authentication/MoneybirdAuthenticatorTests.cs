using System;
using Moneybird.Net.Authentication;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Authentication.Utils;
using Xunit;

namespace Moneybird.Net.Tests.Authentication
{
    public class MoneybirdAuthenticatorTests : CommonTestBase
    {
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
    }
}