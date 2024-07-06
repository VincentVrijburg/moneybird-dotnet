using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.LedgerAccounts;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.LedgerAccounts;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class LedgerAccountEndpointTests : LedgerAccountTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly LedgerAccountEndpoint _ledgerAccountEndpoint;
    
    private const string GetLedgerAccountsResponsePath = "./Responses/Endpoints/LedgerAccounts/getLedgerAccounts.json";
    private const string GetLedgerAccountResponsePath = "./Responses/Endpoints/LedgerAccounts/getLedgerAccount.json";
    private const string PostLedgerAccountResponsePath = "./Responses/Endpoints/LedgerAccounts/postLedgerAccount.json";
    private const string PatchLedgerAccountResponsePath = "./Responses/Endpoints/LedgerAccounts/patchLedgerAccount.json";

    public LedgerAccountEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _ledgerAccountEndpoint = new LedgerAccountEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetLedgerAccountsAsync_ByAccessToken_Returns_LedgerAccounts()
    {
        var ledgerAccountListJson = await File.ReadAllTextAsync(GetLedgerAccountsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(ledgerAccountListJson);

        var expectedLedgerAccountList = JsonSerializer.Deserialize<List<LedgerAccount>>(ledgerAccountListJson, _config.SerializerOptions);
        Assert.NotNull(expectedLedgerAccountList);

        var actualLedgerAccounts = await _ledgerAccountEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualLedgerAccounts);
        
        var actualLedgerAccountList = actualLedgerAccounts.ToList();
        Assert.Equal(expectedLedgerAccountList.Count, actualLedgerAccountList.Count);
        foreach (var actualLedgerAccount in actualLedgerAccountList)
        {
            var expectedLedgerAccount = expectedLedgerAccountList.FirstOrDefault(w => w.Id == actualLedgerAccount.Id);
            Assert.NotNull(expectedLedgerAccount);

            actualLedgerAccount.Should().BeEquivalentTo(expectedLedgerAccount);
        }
    }
    
    [Fact]
    public async void GetLedgerAccountAsync_ByAccessToken_Returns_Single_LedgerAccount()
    {
        var ledgerAccountJson = await File.ReadAllTextAsync(GetLedgerAccountResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(ledgerAccountJson);
            
        var expectedLedgerAccount = JsonSerializer.Deserialize<LedgerAccount>(ledgerAccountJson, _config.SerializerOptions);
        Assert.NotNull(expectedLedgerAccount);

        var actualLedgerAccount = await _ledgerAccountEndpoint.GetByIdAsync(AdministrationId, LedgerAccountId, AccessToken);
        Assert.NotNull(actualLedgerAccount);

        actualLedgerAccount.Should().BeEquivalentTo(expectedLedgerAccount);
    }
    
    [Fact]
    public async void CreateLedgerAccountAsync_ByAccessToken_Returns_NewLedgerAccount()
    {
        var ledgerAccountJson = await File.ReadAllTextAsync(PostLedgerAccountResponsePath);
        var ledgerAccountCreateOptions = new LedgerAccountCreateOptions
        {
            LedgerAccount = new LedgerAccountCreate
            {
                Name = "Test ledger account",
                AccountId = "2182",
                AccountType = LedgerAccountType.Expenses,
                Description = "Test description", // TODO: Check if this description is also in response.
                ParentId = null,
                AllowedDocumentTypes = new[]
                {
                    DocumentType.PurchaseInvoice,
                    DocumentType.FinancialMutation,
                    DocumentType.GeneralJournalDocument
                }
            }
        };
        
        var serializedLedgerAccountCreateOptions = JsonSerializer.Serialize(ledgerAccountCreateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedLedgerAccountCreateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(ledgerAccountJson);
    
        var expectedLedgerAccount = JsonSerializer.Deserialize<LedgerAccount>(ledgerAccountJson, _config.SerializerOptions);
        Assert.NotNull(expectedLedgerAccount);

        var actualLedgerAccount = await _ledgerAccountEndpoint.CreateAsync(AdministrationId, ledgerAccountCreateOptions, AccessToken);
        Assert.NotNull(actualLedgerAccount);

        actualLedgerAccount.Should().BeEquivalentTo(expectedLedgerAccount);
    }
    
    [Fact]
    public async void UpdateLedgerAccountAsync_ByAccessToken_Returns_UpdatedLedgerAccount()
    {
        var ledgerAccountJson = await File.ReadAllTextAsync(PatchLedgerAccountResponsePath);
        var ledgerAccountUpdateOptions = new LedgerAccountUpdateOptions
        {
            LedgerAccount = new LedgerAccountUpdate
            {
                Name = "New name",
                AccountId = null,
                AccountType = LedgerAccountType.Revenue,
                AllowedDocumentTypes = new []
                {
                    DocumentType.SalesInvoice,
                    DocumentType.FinancialMutation,
                    DocumentType.GeneralJournalDocument
                },
                ParentId = null,
                Description = null
            }
        };
        
        var serializedLedgerAccountOptions = JsonSerializer.Serialize(ledgerAccountUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedLedgerAccountOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(ledgerAccountJson);
    
        var expectedLedgerAccount = JsonSerializer.Deserialize<LedgerAccount>(ledgerAccountJson, _config.SerializerOptions);
        Assert.NotNull(expectedLedgerAccount);

        var actualLedgerAccount = await _ledgerAccountEndpoint.UpdateByIdAsync(AdministrationId, LedgerAccountId, ledgerAccountUpdateOptions, AccessToken);
        Assert.NotNull(actualLedgerAccount);

        actualLedgerAccount.Should().BeEquivalentTo(expectedLedgerAccount);
    }
    
    [Fact]
    public async void DeleteLedgerAccountByIdAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var response = await _ledgerAccountEndpoint.DeleteByIdAsync(AdministrationId, LedgerAccountId, AccessToken);
        Assert.True(response);
    }
}
