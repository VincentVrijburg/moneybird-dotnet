using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.CustomerContactPortals;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints
{
    public class CustomerContactPortalEndpointTests : CustomerContactPortalTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly MoneybirdConfig _config;
        private readonly CustomerContactPortalEndpoint _customerContactPortalEndpoint;

        private const string GetTemporaryPortalLinkResponsePath = "./Responses/Endpoints/CustomerContactPortal/getTemporaryPortalLink.json";
        private const string GetTemporaryInvoicesLinkResponsePath = "./Responses/Endpoints/CustomerContactPortal/getTemporaryInvoicesLink.json";
        private const string GetTemporarySubscriptionLinkResponsePath = "./Responses/Endpoints/CustomerContactPortal/getTemporarySubscriptionLink.json";

        public CustomerContactPortalEndpointTests()
        {
            _requester = new Mock<IRequester>();
            _config = new MoneybirdConfig();
            _customerContactPortalEndpoint = new CustomerContactPortalEndpoint(_config, _requester.Object);
        }

        [Fact]
        public async Task GetTemporaryPortalLinkAsync_ByAccessToken_Returns_TemporaryLink()
        {
            var temporaryLinkJson = await File.ReadAllTextAsync(GetTemporaryPortalLinkResponsePath);

            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(temporaryLinkJson);

            var temporaryLink = JsonSerializer.Deserialize<string>(temporaryLinkJson, _config.SerializerOptions);
            Assert.NotNull(temporaryLink);

            var actualTemporaryLink = await _customerContactPortalEndpoint.GetTemporaryPortalLinkAsync(AdministrationId, ContactId, AccessToken);
            Assert.NotNull(actualTemporaryLink);

            new CustomerContactPortalLink
            {
                Url = temporaryLink
            }.Should().BeEquivalentTo(actualTemporaryLink);
        }

        [Fact]
        public async Task GetTemporaryInvoicesLinkAsync_ByAccessToken_Returns_TemporaryLink()
        {
            var temporaryLinkJson = await File.ReadAllTextAsync(GetTemporaryInvoicesLinkResponsePath);

            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(temporaryLinkJson);

            var temporaryLink = JsonSerializer.Deserialize<string>(temporaryLinkJson, _config.SerializerOptions);
            Assert.NotNull(temporaryLink);

            var actualTemporaryLink = await _customerContactPortalEndpoint.GetTemporaryInvoicesLinkAsync(AdministrationId, ContactId, AccessToken);
            Assert.NotNull(actualTemporaryLink);

            new CustomerContactPortalLink
            {
                Url = temporaryLink
            }.Should().BeEquivalentTo(actualTemporaryLink);
        }

        [Fact]
        public async Task GetTemporarySubscriptionLinkAsync_ByAccessToken_Returns_TemporaryLink()
        {
            var temporaryLinkJson = await File.ReadAllTextAsync(GetTemporarySubscriptionLinkResponsePath);

            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(temporaryLinkJson);

            var temporaryLink = JsonSerializer.Deserialize<string>(temporaryLinkJson, _config.SerializerOptions);
            Assert.NotNull(temporaryLink);

            var actualTemporaryLink = await _customerContactPortalEndpoint.GetTemporarySubscriptionLinkAsync(AdministrationId, ContactId, SubscriptionId, AccessToken);
            Assert.NotNull(actualTemporaryLink);

            new CustomerContactPortalLink
            {
                Url = temporaryLink
            }.Should().BeEquivalentTo(actualTemporaryLink);
        }
    }
}
