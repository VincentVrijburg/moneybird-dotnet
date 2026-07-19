using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.PurchaseTransactions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.PurchaseTransactions;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class PurchaseTransactionEndpointTests : PurchaseTransactionTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly PurchaseTransactionEndpoint _purchaseTransactionEndpoint;

    private const string GetPurchaseTransactionsResponsePath = "./Responses/Endpoints/PurchaseTransactions/getPurchaseTransactions.json";
    private const string GetPurchaseTransactionResponsePath = "./Responses/Endpoints/PurchaseTransactions/getPurchaseTransaction.json";
    private const string PostSepaCreditTransferResponsePath = "./Responses/Endpoints/PurchaseTransactions/postSepaCreditTransfer.json";

    public PurchaseTransactionEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _purchaseTransactionEndpoint = new PurchaseTransactionEndpoint(_config, _requester.Object);
    }

    [Fact]
    public async Task GetPurchaseTransactionsAsync_ByAccessToken_Returns_PurchaseTransactions()
    {
        var purchaseTransactionsJson = await File.ReadAllTextAsync(GetPurchaseTransactionsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(purchaseTransactionsJson);

        var purchaseTransactions = JsonSerializer.Deserialize<List<PurchaseTransaction>>(purchaseTransactionsJson, _config.SerializerOptions);
        Assert.NotNull(purchaseTransactions);

        var actualPurchaseTransactions = await _purchaseTransactionEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualPurchaseTransactions);

        var actualPurchaseTransactionsList = actualPurchaseTransactions.ToList();
        Assert.Equal(purchaseTransactions.Count, actualPurchaseTransactionsList.Count);

        foreach (var actualPurchaseTransaction in actualPurchaseTransactionsList)
        {
            var purchaseTransaction = purchaseTransactions.FirstOrDefault(w => w.Id == actualPurchaseTransaction.Id);
            Assert.NotNull(purchaseTransaction);

            purchaseTransaction.Should().BeEquivalentTo(actualPurchaseTransaction);
        }
    }

    [Fact]
    public async Task GetPurchaseTransactionsAsync_UsingFilterOptions_ByAccessToken_Returns_PurchaseTransactions()
    {
        var purchaseTransactionsJson = await File.ReadAllTextAsync(GetPurchaseTransactionsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(purchaseTransactionsJson);

        var purchaseTransactions = JsonSerializer.Deserialize<List<PurchaseTransaction>>(purchaseTransactionsJson, _config.SerializerOptions);
        Assert.NotNull(purchaseTransactions);

        var filterOptions = new PurchaseTransactionFilterOptions
        {
            State = new[] { PurchaseTransactionState.Open, PurchaseTransactionState.AwaitingAuthorization },
            Period = "this_month",
            Unbatched = true,
            SignableByUser = true
        };

        var actualPurchaseTransactions = await _purchaseTransactionEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualPurchaseTransactions);

        var actualPurchaseTransactionsList = actualPurchaseTransactions.ToList();
        Assert.Equal(purchaseTransactions.Count, actualPurchaseTransactionsList.Count);

        foreach (var actualPurchaseTransaction in actualPurchaseTransactionsList)
        {
            var purchaseTransaction = purchaseTransactions.FirstOrDefault(w => w.Id == actualPurchaseTransaction.Id);
            Assert.NotNull(purchaseTransaction);

            purchaseTransaction.Should().BeEquivalentTo(actualPurchaseTransaction);
        }
    }

    [Fact]
    public async Task GetPurchaseTransactionByIdAsync_ByAccessToken_Returns_PurchaseTransaction()
    {
        var purchaseTransactionJson = await File.ReadAllTextAsync(GetPurchaseTransactionResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(purchaseTransactionJson);

        var purchaseTransaction = JsonSerializer.Deserialize<PurchaseTransaction>(purchaseTransactionJson, _config.SerializerOptions);
        Assert.NotNull(purchaseTransaction);

        var actualPurchaseTransaction = await _purchaseTransactionEndpoint.GetByIdAsync(AdministrationId, PurchaseTransactionId, AccessToken);
        Assert.NotNull(actualPurchaseTransaction);

        purchaseTransaction.Should().BeEquivalentTo(actualPurchaseTransaction);
    }

    [Fact]
    public async Task DeletePurchaseTransactionAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);

        var response = await _purchaseTransactionEndpoint.DeleteByIdAsync(AdministrationId, PurchaseTransactionId, AccessToken);
        Assert.True(response);
    }

    [Fact]
    public async Task UploadSepaCreditTransferAsync_ByAccessToken_Returns_PurchaseTransactionBatches()
    {
        var purchaseTransactionBatchesJson = await File.ReadAllTextAsync(PostSepaCreditTransferResponsePath);
        var options = new PurchaseTransactionSepaCreditTransferOptions
        {
            LedgerAccountId = "492897314064566057",
            FinancialAccountId = "492897313893648153"
        };

        _requester.Setup(moq => moq.CreatePostMultipartFormRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<Dictionary<string, string>>()))
            .ReturnsAsync(purchaseTransactionBatchesJson);

        var purchaseTransactionBatches = JsonSerializer.Deserialize<List<PurchaseTransactionBatch>>(purchaseTransactionBatchesJson, _config.SerializerOptions);
        Assert.NotNull(purchaseTransactionBatches);

        var file = new MemoryStream();
        var actualPurchaseTransactionBatches = await _purchaseTransactionEndpoint.UploadSepaCreditTransferAsync(
            AdministrationId,
            file,
            AccessToken,
            options);
        Assert.NotNull(actualPurchaseTransactionBatches);

        purchaseTransactionBatches.Should().BeEquivalentTo(actualPurchaseTransactionBatches);
    }

    [Fact]
    public async Task UploadSepaCreditTransferAsync_WithNullOptions_SendsNoFormFields()
    {
        var purchaseTransactionBatchesJson = await File.ReadAllTextAsync(PostSepaCreditTransferResponsePath);

        _requester.Setup(moq => moq.CreatePostMultipartFormRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<Dictionary<string, string>>()))
            .ReturnsAsync(purchaseTransactionBatchesJson);

        var file = new MemoryStream();
        _ = await _purchaseTransactionEndpoint.UploadSepaCreditTransferAsync(AdministrationId, file, AccessToken);

        _requester.Verify(moq => moq.CreatePostMultipartFormRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.Is<Dictionary<string, string>>(fields => fields == null)),
            Times.Once);
    }

    [Fact]
    public async Task UploadSepaCreditTransferAsync_WithLedgerAccountOnly_SendsOnlyLedgerField()
    {
        var purchaseTransactionBatchesJson = await File.ReadAllTextAsync(PostSepaCreditTransferResponsePath);
        var options = new PurchaseTransactionSepaCreditTransferOptions
        {
            LedgerAccountId = "492897314064566057"
        };

        _requester.Setup(moq => moq.CreatePostMultipartFormRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<Dictionary<string, string>>()))
            .ReturnsAsync(purchaseTransactionBatchesJson);

        var file = new MemoryStream();
        _ = await _purchaseTransactionEndpoint.UploadSepaCreditTransferAsync(AdministrationId, file, AccessToken, options);

        _requester.Verify(moq => moq.CreatePostMultipartFormRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.Is<Dictionary<string, string>>(fields =>
                    fields.Count == 1 &&
                    fields["ledger_account_id"] == options.LedgerAccountId)),
            Times.Once);
    }

    [Fact]
    public async Task UploadSepaCreditTransferAsync_WithFinancialAccountOnly_SendsOnlyFinancialField()
    {
        var purchaseTransactionBatchesJson = await File.ReadAllTextAsync(PostSepaCreditTransferResponsePath);
        var options = new PurchaseTransactionSepaCreditTransferOptions
        {
            FinancialAccountId = "492897313893648153"
        };

        _requester.Setup(moq => moq.CreatePostMultipartFormRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<Dictionary<string, string>>()))
            .ReturnsAsync(purchaseTransactionBatchesJson);

        var file = new MemoryStream();
        _ = await _purchaseTransactionEndpoint.UploadSepaCreditTransferAsync(AdministrationId, file, AccessToken, options);

        _requester.Verify(moq => moq.CreatePostMultipartFormRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.Is<Dictionary<string, string>>(fields =>
                    fields.Count == 1 &&
                    fields["financial_account_id"] == options.FinancialAccountId)),
            Times.Once);
    }
}
