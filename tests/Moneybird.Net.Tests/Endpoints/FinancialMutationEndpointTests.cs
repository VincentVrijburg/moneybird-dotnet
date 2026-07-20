using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.FinancialMutations;
using Moneybird.Net.Http;
using Moneybird.Net.Models.FinancialMutations;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class FinancialMutationEndpointTests : FinancialMutationTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly FinancialMutationEndpoint _financialMutationEndpoint;

    private const string GetFinancialMutationsResponsePath = "./Responses/Endpoints/FinancialMutations/getFinancialMutations.json";
    private const string GetFinancialMutationResponsePath = "./Responses/Endpoints/FinancialMutations/getFinancialMutation.json";
    private const string GetSynchronizationFinancialMutationsResponsePath = "./Responses/Endpoints/FinancialMutations/getSynchronizationFinancialMutations.json";
    private const string PostSynchronizationFinancialMutationsResponsePath = "./Responses/Endpoints/FinancialMutations/postSynchronizationFinancialMutations.json";
    private const string DeleteUnlinkBookingFinancialMutationResponsePath = "./Responses/Endpoints/FinancialMutations/deleteUnlinkBookingFinancialMutation.json";

    public FinancialMutationEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _financialMutationEndpoint = new FinancialMutationEndpoint(_config, _requester.Object);
    }

    [Fact]
    public async Task GetFinancialMutationsAsync_ByAccessToken_Returns_FinancialMutations()
    {
        var financialMutationsList = await File.ReadAllTextAsync(GetFinancialMutationsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(financialMutationsList);

        var expectedFinancialMutations = JsonSerializer.Deserialize<List<FinancialMutation>>(financialMutationsList, _config.SerializerOptions);
        Assert.NotNull(expectedFinancialMutations);

        var actualFinancialMutations = await _financialMutationEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualFinancialMutations);

        var actualFinancialMutationsList = actualFinancialMutations.ToList();
        Assert.Equal(expectedFinancialMutations.Count, actualFinancialMutationsList.Count);

        foreach (var actualFinancialMutation in actualFinancialMutationsList)
        {
            var financialMutation = expectedFinancialMutations.FirstOrDefault(w => w.Id == actualFinancialMutation.Id);
            Assert.NotNull(financialMutation);

            financialMutation.Should().BeEquivalentTo(actualFinancialMutation);
        }
    }

    [Fact]
    public async Task GetFinancialMutationsAsync_UsingFilterOptions_ByAccessToken_Returns_FinancialMutations()
    {
        var financialMutationsList = await File.ReadAllTextAsync(GetFinancialMutationsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(financialMutationsList);

        var expectedFinancialMutations = JsonSerializer.Deserialize<List<FinancialMutation>>(financialMutationsList, _config.SerializerOptions);
        Assert.NotNull(expectedFinancialMutations);

        var filterOptions = new FinancialMutationFilterOptions
        {
            Period = "this_month",
            State = new[] { FinancialMutationState.Unprocessed, FinancialMutationState.Processed },
            MutationType = new[] { FinancialMutationType.Debit },
            FinancialAccountId = "492897320871921275",
            AmountFrom = 10.0,
            AmountTo = 100.0
        };

        var actualFinancialMutations = await _financialMutationEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualFinancialMutations);

        var actualFinancialMutationsList = actualFinancialMutations.ToList();
        Assert.Equal(expectedFinancialMutations.Count, actualFinancialMutationsList.Count);

        foreach (var actualFinancialMutation in actualFinancialMutationsList)
        {
            var financialMutation = expectedFinancialMutations.FirstOrDefault(w => w.Id == actualFinancialMutation.Id);
            Assert.NotNull(financialMutation);

            financialMutation.Should().BeEquivalentTo(actualFinancialMutation);
        }
    }

    [Fact]
    public async Task GetFinancialMutationByIdAsync_ByAccessToken_Returns_Single_FinancialMutation()
    {
        var financialMutationJson = await File.ReadAllTextAsync(GetFinancialMutationResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(financialMutationJson);

        var expectedFinancialMutation = JsonSerializer.Deserialize<FinancialMutation>(financialMutationJson, _config.SerializerOptions);
        Assert.NotNull(expectedFinancialMutation);

        var actualFinancialMutation = await _financialMutationEndpoint.GetByIdAsync(AdministrationId, FinancialMutationId, AccessToken);
        Assert.NotNull(actualFinancialMutation);

        actualFinancialMutation.Should().BeEquivalentTo(expectedFinancialMutation);
    }

    [Fact]
    public async Task GetSynchronizationFinancialMutationsAsync_ByAccessToken_Returns_SynchronizationFinancialMutations()
    {
        var synchronizationFinancialMutations = await File.ReadAllTextAsync(GetSynchronizationFinancialMutationsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationFinancialMutations);

        var expectedSynchronizationFinancialMutations = JsonSerializer.Deserialize<List<SynchronizationFinancialMutation>>(synchronizationFinancialMutations, _config.SerializerOptions);
        Assert.NotNull(expectedSynchronizationFinancialMutations);

        var actualSynchronizationFinancialMutations = await _financialMutationEndpoint.GetSynchronizationFinancialMutationsAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualSynchronizationFinancialMutations);

        var actualSynchronizationFinancialMutationsList = actualSynchronizationFinancialMutations.ToList();
        Assert.Equal(expectedSynchronizationFinancialMutations.Count, actualSynchronizationFinancialMutationsList.Count);

        foreach (var actualSynchronizationFinancialMutation in actualSynchronizationFinancialMutationsList)
        {
            var synchronizationFinancialMutation = expectedSynchronizationFinancialMutations
                .FirstOrDefault(w => w.Id == actualSynchronizationFinancialMutation.Id);
            Assert.NotNull(synchronizationFinancialMutation);

            synchronizationFinancialMutation.Should().BeEquivalentTo(actualSynchronizationFinancialMutation);
        }
    }

    [Fact]
    public async Task GetSynchronizationFinancialMutationsAsync_UsingFilterOptions_ByAccessToken_Returns_SynchronizationFinancialMutations()
    {
        var synchronizationFinancialMutations = await File.ReadAllTextAsync(GetSynchronizationFinancialMutationsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationFinancialMutations);

        var expectedSynchronizationFinancialMutations = JsonSerializer.Deserialize<List<SynchronizationFinancialMutation>>(synchronizationFinancialMutations, _config.SerializerOptions);
        Assert.NotNull(expectedSynchronizationFinancialMutations);

        var filterOptions = new FinancialMutationFilterOptions
        {
            Period = "this_month",
            State = new[] { FinancialMutationState.Processed },
            MutationType = new[] { FinancialMutationType.Credit }
        };

        var actualSynchronizationFinancialMutations = await _financialMutationEndpoint
            .GetSynchronizationFinancialMutationsAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualSynchronizationFinancialMutations);

        var actualSynchronizationFinancialMutationsList = actualSynchronizationFinancialMutations.ToList();
        Assert.Equal(expectedSynchronizationFinancialMutations.Count, actualSynchronizationFinancialMutationsList.Count);

        foreach (var actualSynchronizationFinancialMutation in actualSynchronizationFinancialMutationsList)
        {
            var synchronizationFinancialMutation = expectedSynchronizationFinancialMutations
                .FirstOrDefault(w => w.Id == actualSynchronizationFinancialMutation.Id);
            Assert.NotNull(synchronizationFinancialMutation);

            synchronizationFinancialMutation.Should().BeEquivalentTo(actualSynchronizationFinancialMutation);
        }
    }

    [Fact]
    public async Task GetFinancialMutationsByIdsAsync_ByAccessToken_Returns_FinancialMutations()
    {
        var financialMutationsByIdsJson = await File.ReadAllTextAsync(PostSynchronizationFinancialMutationsResponsePath);
        var financialMutationListOptions = new FinancialMutationListOptions
        {
            Ids =
            [
                "492897318491653419",
                "492897318468584738"
            ]
        };

        var serializedFinancialMutationListOptions = JsonSerializer.Serialize(financialMutationListOptions, _config.SerializerOptions);

        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedFinancialMutationListOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(financialMutationsByIdsJson);

        var expectedFinancialMutationsByIds = JsonSerializer.Deserialize<List<FinancialMutation>>(financialMutationsByIdsJson, _config.SerializerOptions);
        Assert.NotNull(expectedFinancialMutationsByIds);

        var actualFinancialMutationsByIds = await _financialMutationEndpoint.GetFinancialMutationsByIdsAsync(
            AdministrationId, AccessToken, financialMutationListOptions);
        Assert.NotNull(actualFinancialMutationsByIds);

        var actualFinancialMutationsByIdsList = actualFinancialMutationsByIds.ToList();
        Assert.Equal(expectedFinancialMutationsByIds.Count, actualFinancialMutationsByIdsList.Count);

        foreach (var actualFinancialMutation in actualFinancialMutationsByIdsList)
        {
            var financialMutation = expectedFinancialMutationsByIds.FirstOrDefault(w => w.Id == actualFinancialMutation.Id);
            Assert.NotNull(financialMutation);

            financialMutation.Should().BeEquivalentTo(actualFinancialMutation);
        }
    }

    [Fact]
    public async Task LinkBookingAsync_ByAccessToken_Returns_True()
    {
        var financialMutationLinkBookingOptions = new FinancialMutationLinkBookingOptions
        {
            BookingType = FinancialMutationLinkBookingType.SalesInvoice,
            BookingId = FinancialMutationBookingId,
            PriceBase = 80.0,
            Price = 80.0,
            Description = "Linked invoice payment"
        };

        var serializedFinancialMutationLinkBookingOptions = JsonSerializer.Serialize(financialMutationLinkBookingOptions, _config.SerializerOptions);

        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedFinancialMutationLinkBookingOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync("200");

        var response = await _financialMutationEndpoint.LinkBookingAsync(AdministrationId, FinancialMutationId, financialMutationLinkBookingOptions, AccessToken);
        Assert.True(response);
    }

    [Fact]
    public async Task UnlinkBookingAsync_ByAccessToken_Returns_UpdatedFinancialMutation()
    {
        var financialMutationJson = await File.ReadAllTextAsync(DeleteUnlinkBookingFinancialMutationResponsePath);
        var financialMutationUnlinkBookingOptions = new FinancialMutationUnlinkBookingOptions
        {
            BookingType = FinancialMutationUnlinkBookingType.Payment,
            BookingId = "492897321692956350"
        };

        var serializedFinancialMutationUnlinkBookingOptions = JsonSerializer.Serialize(financialMutationUnlinkBookingOptions, _config.SerializerOptions);

        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedFinancialMutationUnlinkBookingOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(financialMutationJson);

        var expectedFinancialMutation = JsonSerializer.Deserialize<FinancialMutation>(financialMutationJson, _config.SerializerOptions);
        Assert.NotNull(expectedFinancialMutation);

        var actualFinancialMutation = await _financialMutationEndpoint
            .UnlinkBookingAsync(AdministrationId, FinancialMutationId, financialMutationUnlinkBookingOptions, AccessToken);
        Assert.NotNull(actualFinancialMutation);

        actualFinancialMutation.Should().BeEquivalentTo(expectedFinancialMutation);
    }
}
