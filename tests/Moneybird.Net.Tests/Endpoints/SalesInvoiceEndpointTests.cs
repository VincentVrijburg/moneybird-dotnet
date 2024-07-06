using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Http;
using Moneybird.Net.Models.SalesInvoices;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class SalesInvoiceEndpointTests : SalesInvoiceTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly SalesInvoiceEndpoint _salesInvoiceEndpoint;
    
    private const string GetSalesInvoicesResponsePath = "./Responses/Endpoints/SalesInvoices/getSalesInvoices.json";
    private const string GetSalesInvoiceResponsePath = "./Responses/Endpoints/SalesInvoices/getSalesInvoice.json";
    private const string PostSalesInvoiceResponsePath = "./Responses/Endpoints/SalesInvoices/postSalesInvoice.json";

    public SalesInvoiceEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _salesInvoiceEndpoint = new SalesInvoiceEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetSalesInvoicesAsync_ByAccessToken_Returns_SalesInvoices()
    {
        var salesInvoicesList = await File.ReadAllTextAsync(GetSalesInvoicesResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(salesInvoicesList);

        var salesInvoices = JsonSerializer.Deserialize<List<SalesInvoice>>(salesInvoicesList, _config.SerializerOptions);
        Assert.NotNull(salesInvoices);

        var actualSalesInvoices = await _salesInvoiceEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualSalesInvoices);
        
        var actualSalesInvoicesList = actualSalesInvoices.ToList();
        Assert.Equal(salesInvoices.Count, actualSalesInvoicesList.Count);
        
        foreach (var actualSalesInvoice in actualSalesInvoicesList)
        {
            var salesInvoice = salesInvoices.FirstOrDefault(w => w.Id == actualSalesInvoice.Id);
            Assert.NotNull(salesInvoice);

            salesInvoice.Should().BeEquivalentTo(actualSalesInvoice);
        }
    }
    
    [Fact]
    public async void GetSalesInvoicesAsync_UsingFilterOptions_ByAccessToken_Returns_SalesInvoices()
    {
        var salesInvoiceList = await File.ReadAllTextAsync(GetSalesInvoicesResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(salesInvoiceList);

        var salesInvoices = JsonSerializer.Deserialize<List<SalesInvoice>>(salesInvoiceList, _config.SerializerOptions);
        Assert.NotNull(salesInvoices);
        
        var filterOptions = new SalesInvoiceFilterOptions
        {
            ContactId = "369764595159532558",
            State = SalesInvoiceState.Open,
            Period = "ThisYear",
            Reference = "30052",
            RecurringSalesInvoiceId = null,
            WorkflowId = "369764439669343349",
            CreatedAfter = DateTime.UtcNow,
            UpdatedAfter = DateTime.UtcNow
        };

        var actualSalesInvoices = await _salesInvoiceEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualSalesInvoices);
        
        var actualSalesInvoiceList = actualSalesInvoices.ToList();
        Assert.Equal(salesInvoices.Count, actualSalesInvoiceList.Count);
        
        foreach (var actualSalesInvoice in actualSalesInvoiceList)
        {
            var salesInvoice = salesInvoices.FirstOrDefault(w => w.Id == actualSalesInvoice.Id);
            Assert.NotNull(salesInvoice);

            salesInvoice.Should().BeEquivalentTo(actualSalesInvoice);
        }
    }
    
    [Fact]
    public async void GetSalesInvoiceByIdAsync_ByAccessToken_Returns_Single_SalesInvoice()
    {
        var salesInvoiceJson = await File.ReadAllTextAsync(GetSalesInvoiceResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(salesInvoiceJson);
            
        var salesInvoice = JsonSerializer.Deserialize<SalesInvoice>(salesInvoiceJson, _config.SerializerOptions);
        Assert.NotNull(salesInvoice);

        var actualSalesInvoice = await _salesInvoiceEndpoint.GetByIdAsync(AdministrationId, SalesInvoiceId, AccessToken);
        Assert.NotNull(actualSalesInvoice);

        salesInvoice.Should().BeEquivalentTo(actualSalesInvoice);
    }
    
    [Fact]
    public async void CreateSalesInvoiceAsync_ByAccessToken_Returns_NewSalesInvoice()
    {
        var options = new SalesInvoiceCreateOptions
        {
            SalesInvoice = new SalesInvoiceCreate
            {
                Reference = "30052",
                ContactId = "370131045504255127",
                Currency = "USD",
                DetailsAttributes = new []
                {
                    new SalesInvoiceCreateDetail
                    {
                        Id = "369764595235030036",
                        TaxRateId = "369764439469065326",
                        LedgerAccountId= "369764439364207706",
                        ProjectId=  null,
                        ProductId = null,
                        Amount = 1,
                        Description = "Project X",
                        Price = 300.0,
                        Period = "20221001..20221031",
                        RowOrder = 1,
                        Destroy = false,
                        AutomatedTaxEnabled = true,
                        TimeEntryIds = new []
                        {
                            "369764595235030037"
                        }
                    }
                },
                ContactPersonId = "369764595176309777",
                OriginalEstimateId = null,
                DocumentStyleId = "369764439814046847",
                WorkflowId = "369764439669343349",
                InvoiceSequenceId = "2023",
                InvoiceDate = DateTime.UtcNow,
                FirstDueInterval = 30,
                PaymentConditions = "Payment within 30 days",
                PricesAreInclTax = true,
                Discount = 0,
                CustomFieldsAttributes = new []
                {
                    new CustomFieldAttribute
                    {
                        Id = "1",
                        Value = "Custom field value"
                    }
                }
            },
            FromCheckout = true
        };

        var createResponse = await File.ReadAllTextAsync(PostSalesInvoiceResponsePath);

        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<string>>()))
            .ReturnsAsync(createResponse);

        var salesInvoice = JsonSerializer.Deserialize<SalesInvoice>(createResponse, _config.SerializerOptions);
        Assert.NotNull(salesInvoice);

        var actualSalesInvoice = await _salesInvoiceEndpoint.CreateAsync(AdministrationId, options, AccessToken);
        Assert.NotNull(actualSalesInvoice);

        salesInvoice.Should().BeEquivalentTo(actualSalesInvoice);
    }
    
    [Fact]
    public async void UpdateSalesInvoiceAsync_ByAccessToken_Returns_UpdatedSalesInvoice()
    {
        var salesInvoiceJson = await File.ReadAllTextAsync(GetSalesInvoiceResponsePath);
        var salesInvoiceUpdateOptions = new SalesInvoiceUpdateOptions
        {
            SalesInvoice = new SalesInvoiceUpdate
            {
                ContactId = "369764595159532558",
                ContactPersonId = "369764595176309777",
                UpdateContact = true,
                OriginalEstimateId = null,
                DocumentStyleId = "369764439814046847",
                WorkflowId = "369764439669343349",
                Reference = "Project X",
                InvoiceSequenceId = "2023",
                RemoveInvoiceSequenceId = false,
                InvoiceDate = DateTime.UtcNow,
                FirstDueInterval = 14,
                Currency = "EUR",
                PricesAreInclTax = true,
                PaymentConditions = "Payment within 14 days",
                Discount = 0,
                DetailsAttributes = new []
                {
                    new SalesInvoiceUpdateDetail
                    {
                        Id = "369764595235030036",
                        TaxRateId = "369764439469065326",
                        LedgerAccountId= "369764439364207706",
                        ProjectId=  null,
                        ProductId = null,
                        Amount = 1,
                        Description = "Project X",
                        Price = 300.0,
                        Period = "20221001..20221031",
                        RowOrder = 1,
                        Destroy = false,
                        AutomatedTaxEnabled = true,
                        TimeEntryIds = new []
                        {
                            "369764595235030037"
                        }
                    }
                },
                CustomFieldsAttributes = new []
                {
                    new CustomFieldAttribute()
                    {
                        Id = "1",
                        Value = "Custom field value"
                    },
                    new CustomFieldAttribute
                    {
                        Id = "2",
                        Value = "Second custom field value"
                    }
                }
            }
        };
        
        var serializedSalesInvoiceUpdateOptions = JsonSerializer.Serialize(salesInvoiceUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedSalesInvoiceUpdateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(salesInvoiceJson);
    
        var salesInvoice = JsonSerializer.Deserialize<SalesInvoice>(salesInvoiceJson, _config.SerializerOptions);
        Assert.NotNull(salesInvoice);

        var actualSalesInvoice = await _salesInvoiceEndpoint.UpdateByIdAsync(AdministrationId, SalesInvoiceId, salesInvoiceUpdateOptions, AccessToken);
        Assert.NotNull(actualSalesInvoice);

        salesInvoice.Should().BeEquivalentTo(actualSalesInvoice);
    }
    
    [Fact]
    public async void DeleteSalesInvoiceAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualSalesInvoice = await _salesInvoiceEndpoint.DeleteByIdAsync(AdministrationId, SalesInvoiceId, AccessToken);
        Assert.True(actualSalesInvoice);
    }

    [Fact]
    public async void AddSalesInvoiceAttachmentAsync_ByAccessToken_Returns()
    {
        _requester.Setup(moq => moq.CreatePostFileRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Stream>(), It.IsAny<List<string>>()));
        
        var file = new MemoryStream();
        await _salesInvoiceEndpoint.AddAttachmentAsync(AdministrationId, SalesInvoiceId, file, AccessToken, "testfile.pdf");
    }
}