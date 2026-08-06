using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Entities.Subscriptions;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.SalesInvoices;
using Moneybird.Net.Models.Subscriptions;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class SubscriptionEndpointTests
{
    private const string AdministrationId = "123";
    private const string AccessToken = "token";
    private const string SubscriptionId = "494090758556485059";
    private const string ContactId = "494090758106645938";
    private const string GetSubscriptionsResponsePath = "./Responses/Endpoints/Subscriptions/getSubscriptions.json";
    private const string GetSubscriptionResponsePath = "./Responses/Endpoints/Subscriptions/getSubscription.json";
    private const string PostSubscriptionResponsePath = "./Responses/Endpoints/Subscriptions/postSubscription.json";
    private const string PatchSubscriptionResponsePath = "./Responses/Endpoints/Subscriptions/patchSubscription.json";
    private const string DeleteSubscriptionResponsePath = "./Responses/Endpoints/Subscriptions/deleteSubscription.json";
    private const string PostAdditionalChargeResponsePath = "./Responses/Endpoints/Subscriptions/postAdditionalCharge.json";
    private const string GetAdditionalChargesResponsePath = "./Responses/Endpoints/Subscriptions/getAdditionalCharges.json";
    private const string PostOneOffSalesInvoiceResponsePath = "./Responses/Endpoints/Subscriptions/postOneOffSalesInvoice.json";

    private readonly Mock<IRequester> _requester = new();
    private readonly MoneybirdConfig _config = new();
    private readonly SubscriptionEndpoint _endpoint;

    public SubscriptionEndpointTests()
    {
        _endpoint = new SubscriptionEndpoint(_config, _requester.Object);
    }

    [Fact]
    public async Task GetAsync_ByContact_ReturnsSubscriptionsAndIncludesContactQuery()
    {
        var json = await File.ReadAllTextAsync(GetSubscriptionsResponsePath);

        List<string> query = null;
        _requester
            .Setup(requester => requester.CreateGetRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<List<string>>()))
            .Callback<string, string, string, List<string>>((_, _, _, values) => query = values)
            .ReturnsAsync(json);

        var result = (await _endpoint.GetAsync(AdministrationId, AccessToken, ContactId)).Single();

        result.Id.Should().Be(SubscriptionId);
        result.FrequencyType.Should().Be(FrequencyType.Month);
        result.SubscriptionProducts.Single().Discount.Should().Be(10);
        query.Should().BeEquivalentTo(new[] { $"contact_id={ContactId}", "page=1", "per_page=50" });
    }

    [Fact]
    public async Task GetByIdAsync_ByAccessToken_ReturnsSingleSubscriptionWithOptionalProperties()
    {
        var json = await File.ReadAllTextAsync(GetSubscriptionResponsePath);
        _requester
            .Setup(requester => requester.CreateGetRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<List<string>>()))
            .ReturnsAsync(json);

        var expected = JsonSerializer.Deserialize<Subscription>(json, _config.SerializerOptions);
        var actual = await _endpoint.GetByIdAsync(AdministrationId, SubscriptionId, AccessToken);

        actual.Should().BeEquivalentTo(expected);
        actual.EndDate.Should().Be(new DateTime(2026, 8, 31));
        actual.CancelledAt.Should().Be(new DateTime(2026, 7, 30, 14, 28, 10, DateTimeKind.Utc));
        actual.Reference.Should().Be("Annual plan");
        actual.Product.Title.Should().Be("Premium product");
        actual.Contact.CompanyName.Should().Be("Foobar Holding B.V.");
        actual.SubscriptionProducts.Single().EndDate.Should().Be(new DateTime(2026, 8, 31));
    }

    [Fact]
    public async Task CreateAsync_SerializesSubscriptionAndReturnsEntity()
    {
        var options = new SubscriptionCreateOptions
        {
            Subscription = new SubscriptionCreate
            {
                StartDate = new DateTime(2026, 7, 31),
                ProductId = "product-1",
                ContactId = ContactId,
                Amount = "5 x",
                Frequency = 1,
                FrequencyType = FrequencyType.Month,
                Mergeable = true
            }
        };
        var response = await File.ReadAllTextAsync(PostSubscriptionResponsePath);
        string body = null;

        _requester
            .Setup(requester => requester.CreatePostRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<string>(), It.IsAny<List<string>>()))
            .Callback<string, string, string, string, List<string>>((_, _, _, value, _) => body = value)
            .ReturnsAsync(response);

        var result = await _endpoint.CreateAsync(AdministrationId, options, AccessToken);

        result.Id.Should().Be("subscription-1");
        body.Should().Be(JsonSerializer.Serialize(options, _config.SerializerOptions));
    }

    [Fact]
    public async Task UpdateAsync_SerializesSubscriptionAndReturnsEntity()
    {
        var options = new SubscriptionUpdateOptions
        {
            Subscription = new SubscriptionUpdate
            {
                ProductId = "product-2",
                StartDate = new DateTime(2026, 8, 1),
                Amount = "3 x",
                Discount = 10
            }
        };
        var response = await File.ReadAllTextAsync(PatchSubscriptionResponsePath);
        string body = null;

        _requester
            .Setup(requester => requester.CreatePatchRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<string>(), It.IsAny<List<string>>()))
            .Callback<string, string, string, string, List<string>>((_, _, _, value, _) => body = value)
            .ReturnsAsync(response);

        var result = await _endpoint.UpdateByIdAsync(AdministrationId, SubscriptionId, options, AccessToken);

        result.ProductId.Should().Be("product-2");
        body.Should().Be(JsonSerializer.Serialize(options, _config.SerializerOptions));
    }

    [Fact]
    public async Task CancelAsync_SendsDeleteBodyAndReturnsCancelledSubscription()
    {
        var options = new SubscriptionCancelOptions
        {
            Subscription = new SubscriptionCancel { EndDate = new DateTime(2026, 8, 1) }
        };
        var response = await File.ReadAllTextAsync(DeleteSubscriptionResponsePath);
        string body = null;

        _requester
            .Setup(requester => requester.CreateDeleteRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<string>(), It.IsAny<List<string>>()))
            .Callback<string, string, string, string, List<string>>((_, _, _, value, _) => body = value)
            .ReturnsAsync(response);

        var result = await _endpoint.CancelAsync(AdministrationId, SubscriptionId, options, AccessToken);

        result.CancelledAt.Should().NotBeNull();
        body.Should().Be(JsonSerializer.Serialize(options, _config.SerializerOptions));
    }

    [Fact]
    public async Task AdditionalCharges_CreateAndListUseSubscriptionRoutes()
    {
        var create = new SubscriptionAdditionalChargeCreate
        {
            ProductId = "product-1",
            Amount = "5 x",
            Price = 100,
            Period = "20210601..20210630",
            Description = "Transaction Costs"
        };
        var chargeJson = await File.ReadAllTextAsync(PostAdditionalChargeResponsePath);
        string body = null;
        _requester
            .Setup(requester => requester.CreatePostRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<string>(), It.IsAny<List<string>>()))
            .Callback<string, string, string, string, List<string>>((_, _, _, value, _) => body = value)
            .ReturnsAsync(chargeJson);
        _requester
            .Setup(requester => requester.CreateGetRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<List<string>>()))
            .ReturnsAsync(await File.ReadAllTextAsync(GetAdditionalChargesResponsePath));

        var created = await _endpoint.CreateAdditionalChargeAsync(AdministrationId, SubscriptionId, create, AccessToken);
        var listed = await _endpoint.GetAdditionalChargesAsync(AdministrationId, SubscriptionId, AccessToken, true);

        created.Id.Should().Be("charge-1");
        listed.Single().Price.Should().Be(100);
        body.Should().Be(JsonSerializer.Serialize(create, _config.SerializerOptions));
        _requester.Verify(requester => requester.CreateGetRequestAsync(
            It.IsAny<string>(), It.IsAny<string>(), AccessToken,
            It.Is<List<string>>(values => values.Single() == "include_billed=true")), Times.Once);
    }

    [Fact]
    public async Task CreateAndScheduleOneOffSalesInvoice_ReturnsSalesInvoice()
    {
        var options = new SubscriptionOneOffSalesInvoiceCreateOptions
        {
            SalesInvoice = new SubscriptionOneOffSalesInvoiceCreate
            {
                InvoiceDate = new DateTime(2026, 8, 1),
                DetailsAttributes = new List<SalesInvoiceCreateDetail>
                {
                    new() { Description = "Usage", Price = 10.5 }
                }
            }
        };
        var response = await File.ReadAllTextAsync(PostOneOffSalesInvoiceResponsePath);
        string body = null;
        _requester
            .Setup(requester => requester.CreatePostRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<string>(), It.IsAny<List<string>>()))
            .Callback<string, string, string, string, List<string>>((_, _, _, value, _) => body = value)
            .ReturnsAsync(response);

        var result = await _endpoint.CreateAndScheduleOneOffSalesInvoiceAsync(
            AdministrationId, SubscriptionId, options, AccessToken);

        result.Should().BeOfType<SalesInvoice>();
        result.Id.Should().Be("invoice-1");
        body.Should().Be(JsonSerializer.Serialize(options, _config.SerializerOptions));
    }
}
