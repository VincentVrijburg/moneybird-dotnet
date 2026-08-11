using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.SubscriptionTemplates;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class SubscriptionTemplateEndpointTests : CommonTestBase
{
    private const string TemplateId = "494722488146593096";
    private const string ResponsePath = "./Responses/Endpoints/SubscriptionTemplates/getSubscriptionTemplates.json";
    private const string SalesLinkResponse = "\"https://checkout.moneybird.com/o/PLD9QPK5DV85\"";

    private readonly Mock<IRequester> _requester = new();
    private readonly MoneybirdConfig _config = new();
    private readonly SubscriptionTemplateEndpoint _endpoint;

    public SubscriptionTemplateEndpointTests()
    {
        _endpoint = new SubscriptionTemplateEndpoint(_config, _requester.Object);
    }

    [Fact]
    public async Task GetAsync_ReturnsSubscriptionTemplatesAndIncludesPagination()
    {
        var json = await File.ReadAllTextAsync(ResponsePath);
        string relativeUrl = null;
        List<string> query = null;
        _requester
            .Setup(requester => requester.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<List<string>>()))
            .Callback<string, string, string, List<string>>((_, url, _, values) =>
            {
                relativeUrl = url;
                query = values;
            })
            .ReturnsAsync(json);

        var result = (await _endpoint.GetAsync(AdministrationId, AccessToken, 2, 100)).Single();

        relativeUrl.Should().Be($"/{AdministrationId}/subscription_templates.json");
        query.Should().BeEquivalentTo(new[] { "page=2", "per_page=100" });
        result.Id.Should().Be(TemplateId);
        result.AdministrationId.Should().Be(AdministrationId);
        result.WorkflowId.Should().Be("494722488131913026");
        result.DocumentStyleId.Should().Be("494722369162577049");
        result.Mergeable.Should().BeFalse();
        result.ContactCanUpdate.Should().BeTrue();

        var product = result.Products.Single();
        product.AdministrationId.Should().Be(AdministrationId);
        product.Title.Should().BeNull();
        product.Identifier.Should().BeNull();
        product.Price.Should().Be(10);
        product.Frequency.Should().Be(1);
        product.FrequencyType.Should().Be(FrequencyType.Month);
        product.CreatedAt.Should().Be(new DateTime(2026, 8, 6, 13, 49, 12, 409, DateTimeKind.Utc));
    }

    [Fact]
    public async Task CreateSalesLinkAsync_SendsOptionsAsQueryAndReturnsLink()
    {
        string relativeUrl = null;
        string body = null;
        List<string> query = null;
        _requester
            .Setup(requester => requester.CreatePostRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                AccessToken,
                It.IsAny<string>(),
                It.IsAny<List<string>>()))
            .Callback<string, string, string, string, List<string>>((_, url, _, content, values) =>
            {
                relativeUrl = url;
                body = content;
                query = values;
            })
            .ReturnsAsync(SalesLinkResponse);

        var options = new SubscriptionTemplateSalesLinkOptions
        {
            ContactId = "123 456",
            StartDate = new DateTime(2026, 8, 15),
            ProductId = "789"
        };

        var result = await _endpoint.CreateSalesLinkAsync(AdministrationId, TemplateId, AccessToken, options);

        relativeUrl.Should().Be($"/{AdministrationId}/subscription_templates/{TemplateId}/sales_link.json");
        body.Should().BeEmpty();
        query.Should().Equal("contact_id=123 456", "start_date=2026-08-15", "product_id=789");
        result.Url.Should().Be("https://checkout.moneybird.com/o/PLD9QPK5DV85");
    }

}
