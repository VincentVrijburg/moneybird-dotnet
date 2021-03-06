using System.Text.Json;
using AutoFixture;
using FluentAssertions;
using Moneybird.Net.Authentication.Enums;
using Moneybird.Net.Authentication.Models;
using Moneybird.Net.Extensions;
using Xunit;

namespace Moneybird.Net.Tests.Authentication.Models
{
    public class AccessTokenTests
    {
        [Fact]
        public void AccessToken_Serializing_Deserializing_Should_Remain_Correct()
        {
            // Create fictional model, excluding the ignored properties.
            var fixture = new Fixture();
            var accessToken = fixture.Build<AccessToken>().Without(p => p.ExpiresIn).Without(p => p.IsExpired).Create();
            
            // Fix the scope string since AutoFixture will produce a random string not bound by the AuthScope restrictions.
            accessToken.Scope = $"{AuthScope.SalesInvoices.ToString().ToSnakeCase()} {AuthScope.Bank.ToString().ToSnakeCase()}";
            
            var json = JsonSerializer.Serialize(accessToken);
            var deserializedAccessToken = JsonSerializer.Deserialize<AccessToken>(json);

            deserializedAccessToken.Should().BeEquivalentTo(accessToken);
        }
    }
}