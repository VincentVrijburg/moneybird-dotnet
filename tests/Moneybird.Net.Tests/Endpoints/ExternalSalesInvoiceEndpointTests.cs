using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.ExternalSalesInvoices;
using Moneybird.Net.Http;
using Moneybird.Net.Models.ExternalSalesInvoices;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class ExternalSalesInvoiceEndpointTests : ExternalSalesInvoicesTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly ExternalSalesInvoiceEndpoint _externalSalesInvoiceEndpoint;
    
    private const string GetExternalSalesInvoicesResponsePath = "./Responses/Endpoints/ExternalSalesInvoices/getExternalSalesInvoices.json";
    private const string GetExternalSalesInvoiceResponsePath = "./Responses/Endpoints/ExternalSalesInvoices/getExternalSalesInvoice.json";
    private const string PostExternalSalesInvoiceResponsePath = "./Responses/Endpoints/ExternalSalesInvoices/postExternalSalesInvoice.json";

    public ExternalSalesInvoiceEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _externalSalesInvoiceEndpoint = new ExternalSalesInvoiceEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async Task GetExternalSalesInvoicesAsync_ByAccessToken_Returns_ExternalSalesInvoices()
    {
        var externalSalesInvoicesList = await File.ReadAllTextAsync(GetExternalSalesInvoicesResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(externalSalesInvoicesList);

        var externalSalesInvoices = JsonSerializer.Deserialize<List<ExternalSalesInvoice>>(externalSalesInvoicesList, _config.SerializerOptions);
        Assert.NotNull(externalSalesInvoices);

        var actualExternalSalesInvoices = await _externalSalesInvoiceEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualExternalSalesInvoices);
        
        var actualExternalSalesInvoicesList = actualExternalSalesInvoices.ToList();
        Assert.Equal(externalSalesInvoices.Count, actualExternalSalesInvoicesList.Count);
        
        foreach (var actualExternalSalesInvoice in actualExternalSalesInvoicesList)
        {
            var externalSalesInvoice = externalSalesInvoices.FirstOrDefault(w => w.Id == actualExternalSalesInvoice.Id);
            Assert.NotNull(externalSalesInvoice);

            externalSalesInvoice.Should().BeEquivalentTo(actualExternalSalesInvoice);
        }
    }
    
    [Fact]
    public async Task GetExternalSalesInvoicesAsync_UsingFilterOptions_ByAccessToken_Returns_ExternalSalesInvoices()
    {
        var externalSalesInvoiceList = await File.ReadAllTextAsync(GetExternalSalesInvoicesResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(externalSalesInvoiceList);

        var externalSalesInvoices = JsonSerializer.Deserialize<List<ExternalSalesInvoice>>(externalSalesInvoiceList, _config.SerializerOptions);
        Assert.NotNull(externalSalesInvoices);
        
        var filterOptions = new ExternalSalesInvoiceFilterOptions
        {
            ContactId = "369764545284015762",
            State = ExternalSalesInvoiceState.Open,
            Period = "ThisYear"
        };

        var actualExternalSalesInvoices = await _externalSalesInvoiceEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualExternalSalesInvoices);
        
        var actualExternalSalesInvoiceList = actualExternalSalesInvoices.ToList();
        Assert.Equal(externalSalesInvoices.Count, actualExternalSalesInvoiceList.Count);
        
        foreach (var actualExternalSalesInvoice in actualExternalSalesInvoiceList)
        {
            var externalSalesInvoice = externalSalesInvoices.FirstOrDefault(w => w.Id == actualExternalSalesInvoice.Id);
            Assert.NotNull(externalSalesInvoice);

            externalSalesInvoice.Should().BeEquivalentTo(actualExternalSalesInvoice);
        }
    }
    
    [Fact]
    public async Task GetExternalSalesInvoiceByIdAsync_ByAccessToken_Returns_Single_ExternalSalesInvoice()
    {
        var externalSalesInvoiceJson = await File.ReadAllTextAsync(GetExternalSalesInvoiceResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(externalSalesInvoiceJson);
            
        var externalSalesInvoice = JsonSerializer.Deserialize<ExternalSalesInvoice>(externalSalesInvoiceJson, _config.SerializerOptions);
        Assert.NotNull(externalSalesInvoice);

        var actualExternalSalesInvoice = await _externalSalesInvoiceEndpoint.GetByIdAsync(AdministrationId, ExternalSalesInvoiceId, AccessToken);
        Assert.NotNull(actualExternalSalesInvoice);

        externalSalesInvoice.Should().BeEquivalentTo(actualExternalSalesInvoice);
    }
    
    [Fact]
    public async Task CreateExternalSalesInvoiceAsync_ByAccessToken_Returns_NewExternalSalesInvoice()
    {
        var options = new ExternalSalesInvoiceCreateOptions
        {
            ExternalInvoice = new ExternalSalesInvoiceCreate
            {
                Reference = "30052",
                ContactId = "370131045504255127",
                Currency = "USD",
                DetailsAttributes =
                [
                    new ExternalSalesInvoiceCreateDetail
                    {
                        Id = "369764595235030036",
                        TaxRateId = "369764439469065326",
                        LedgerAccountId = "369764439364207706",
                        ProjectId = null,
                        Amount = 1,
                        Description = "Project X",
                        Price = 300.0,
                        Period = "20221001..20221031",
                        RowOrder = 1,
                        Destroy = false
                    }
                ],
                PricesAreInclTax = true,
                Date = DateTime.UtcNow,
                Source = "webshop",
                DueDate = DateTime.UtcNow.AddDays(14),
                SourceUrl = "https://www.example.com/checkout/1234"
            },
            UserAgent = "Moneybird .NET Client"
        };

        var createResponse = await File.ReadAllTextAsync(PostExternalSalesInvoiceResponsePath);

        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<string>>()))
            .ReturnsAsync(createResponse);

        var externalSalesInvoice = JsonSerializer.Deserialize<ExternalSalesInvoice>(createResponse, _config.SerializerOptions);
        Assert.NotNull(externalSalesInvoice);

        var actualExternalSalesInvoice = await _externalSalesInvoiceEndpoint.CreateAsync(AdministrationId, options, AccessToken);
        Assert.NotNull(actualExternalSalesInvoice);

        externalSalesInvoice.Should().BeEquivalentTo(actualExternalSalesInvoice);
    }
    
    [Fact]
    public async Task UpdateExternalSalesInvoiceAsync_ByAccessToken_Returns_UpdatedExternalSalesInvoice()
    {
        var externalSalesInvoiceJson = await File.ReadAllTextAsync(GetExternalSalesInvoiceResponsePath);
        var externalSalesInvoiceUpdateOptions = new ExternalSalesInvoiceUpdateOptions
        {
            ExternalInvoice = new ExternalSalesInvoiceUpdate
            {
                ContactId = "369764595159532558",
                Reference = "Project X",
                Currency = "EUR",
                PricesAreInclTax = true,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(14),
                Source = "webshop",
                SourceUrl = "https://www.example.com/checkout/1234",
                DetailsAttributes =
                [
                    new ExternalSalesInvoiceUpdateDetail
                    {
                        Id = "369764595235030036",
                        TaxRateId = "369764439469065326",
                        LedgerAccountId = "369764439364207706",
                        ProjectId = null,
                        Amount = 1,
                        Description = "Project X",
                        Price = 300.0,
                        Period = "20221001..20221031",
                        RowOrder = 1,
                        Destroy = false
                    }
                ]
            },
            UserAgent = "Moneybird .NET Client"
        };
        
        var serializedExternalSalesInvoiceUpdateOptions = JsonSerializer.Serialize(externalSalesInvoiceUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedExternalSalesInvoiceUpdateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(externalSalesInvoiceJson);
    
        var externalSalesInvoice = JsonSerializer.Deserialize<ExternalSalesInvoice>(externalSalesInvoiceJson, _config.SerializerOptions);
        Assert.NotNull(externalSalesInvoice);

        var actualExternalSalesInvoice = await _externalSalesInvoiceEndpoint.UpdateByIdAsync(AdministrationId, ExternalSalesInvoiceId, externalSalesInvoiceUpdateOptions, AccessToken);
        Assert.NotNull(actualExternalSalesInvoice);

        externalSalesInvoice.Should().BeEquivalentTo(actualExternalSalesInvoice);
    }

    [Fact]
    public async Task DeleteExternalSalesInvoiceAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var response = await _externalSalesInvoiceEndpoint.DeleteByIdAsync(AdministrationId, ExternalSalesInvoiceId, AccessToken);
        Assert.True(response);
    }

    [Fact]
    public async Task AddExternalSalesInvoiceAttachmentAsync_ByAccessToken_Returns()
    {
        _requester.Setup(moq => moq.CreatePostFileRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Stream>(), It.IsAny<List<string>>()));
        
        var file = new MemoryStream();
        await _externalSalesInvoiceEndpoint.AddAttachmentAsync(AdministrationId, ExternalSalesInvoiceId, file, AccessToken, "testfile.pdf");
    }
}