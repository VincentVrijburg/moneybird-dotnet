using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.FinancialStatements;
using Moneybird.Net.Endpoints.FinancialStatements.Models;
using Moneybird.Net.Entities.FinancialMutations;
using Moneybird.Net.Entities.FinancialStatements;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.FinancialStatements;

public class FinancialStatementEndpointTests : FinancialStatementTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly FinancialStatementEndpoint _financialStatementEndpoint;
    
    private const string PostFinancialStatementResponsePath = "./Responses/Endpoints/FinancialStatements/postFinancialStatement.json";
    private const string PatchFinancialStatementResponsePath = "./Responses/Endpoints/FinancialStatements/patchFinancialStatement.json";

    public FinancialStatementEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _financialStatementEndpoint = new FinancialStatementEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void CreateFinancialStatementAsync_ByAccessToken_Returns_NewFinancialStatement()
    {
        var options = new FinancialStatementCreateOptions
        {
            FinancialStatement = new FinancialStatementCreate
            {
                FinancialAccountId = "395773914661258696",
                Reference = "31012014",
                OfficialDate = new DateTime(2023, 8, 10),
                OfficialBalance = 1000.00,
                ImporterService = "moneybird-dotnet",
                FinancialMutationAttributes = new List<FinancialMutationAttribute>
                {
                    new ()
                    {
                        Date = new DateTime(2023, 8, 10),
                        ValutationDate = new DateTime(2023, 8, 11),
                        Message = "Foobar 1",
                        Amount = 10.96,
                        Code = "code 1",
                        ContraAccountName = "contra account name 1",
                        ContraAccountNumber = "NL00ABNA0123456789",
                        BatchReference = "batch reference 1",
                        Offset = 1,
                        AccountServicerTransactionId = "account servicer transaction id 1",
                        AdyenPaymentInstrumentId = 1,
                        Destroy = false
                    },
                    new ()
                    {
                        Date = new DateTime(2023, 8, 10),
                        ValutationDate = new DateTime(2023, 8, 11),
                        Message = "Foobar 2",
                        Amount = 10.97,
                        Code = "code 2",
                        ContraAccountName = "contra account name 2",
                        ContraAccountNumber = "NL00ABNA0123456789",
                        BatchReference = "batch reference 2",
                        Offset = 2,
                        AccountServicerTransactionId = "account servicer transaction id 2",
                        AdyenPaymentInstrumentId = 2,
                        Destroy = false
                    }
                }
            }
        };

        var createResponse = await File.ReadAllTextAsync(PostFinancialStatementResponsePath);

        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<string>>()))
            .ReturnsAsync(createResponse);

        var financialStatement = JsonSerializer.Deserialize<FinancialStatement>(createResponse, _config.SerializerOptions);
        Assert.NotNull(financialStatement);

        var actualFinancialStatement = await _financialStatementEndpoint.CreateAsync(AdministrationId, options, AccessToken);
        Assert.NotNull(actualFinancialStatement);

        financialStatement.Should().BeEquivalentTo(actualFinancialStatement);
    }
    
    [Fact]
    public async void UpdateFinancialStatementAsync_ByAccessToken_Returns_UpdatedFinancialStatement()
    {
        var financialStatementJson = await File.ReadAllTextAsync(PatchFinancialStatementResponsePath);
        var financialStatementUpdateOptions = new FinancialStatementUpdateOptions
        {
            FinancialStatement = new FinancialStatementUpdate
            {
                FinancialAccountId = "395773914661258696",
                Reference = "new_reference",
                OfficialDate = null,
                OfficialBalance = null,
                ImporterService = null,
                FinancialMutationAttributes = new List<FinancialMutationAttribute> {
                    new ()
                    {
                        Amount = -20.0,
                        Code = null,
                        Date = new DateTime(2023, 8, 9),
                        Message = "Afboeking",
                        ContraAccountName = "Krant",
                        ContraAccountNumber = "CH0108877380006003301",
                        BatchReference = null,
                        AccountServicerTransactionId = null
                    }
                }
            }
        };
        
        var serializedFinancialStatementUpdateOptions = JsonSerializer.Serialize(financialStatementUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedFinancialStatementUpdateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(financialStatementJson);
    
        var financialStatement = JsonSerializer.Deserialize<FinancialStatement>(financialStatementJson, _config.SerializerOptions);
        Assert.NotNull(financialStatement);

        var actualFinancialStatement = await _financialStatementEndpoint.UpdateByIdAsync(AdministrationId, FinancialStatementId, financialStatementUpdateOptions, AccessToken);
        Assert.NotNull(actualFinancialStatement);

        financialStatement.Should().BeEquivalentTo(actualFinancialStatement);
    }
    
    [Fact]
    public async void DeleteFinancialStatementAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var response = await _financialStatementEndpoint.DeleteByIdAsync(AdministrationId, FinancialStatementId, AccessToken);
        Assert.True(response);
    }
}