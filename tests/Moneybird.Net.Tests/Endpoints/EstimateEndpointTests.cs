using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Entities.Estimates;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.Estimates;
using Moneybird.Net.Models.Notes;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class EstimateEndpointTests : EstimateTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly EstimateEndpoint _estimateEndpoint;
    
    private const string GetEstimatesResponsePath = "./Responses/Endpoints/Estimates/getEstimates.json";
    private const string GetEstimateResponsePath = "./Responses/Endpoints/Estimates/getEstimate.json";
    private const string GetSynchronizationEstimatesResponsePath = "./Responses/Endpoints/Estimates/getSynchronizationEstimates.json";
    private const string PostEstimateResponsePath = "./Responses/Endpoints/Estimates/postEstimate.json";
    private const string SendEstimateResponsePath = "./Responses/Endpoints/Estimates/sendEstimate.json";
    private const string NewEstimateNoteResponsePath = "./Responses/Endpoints/Estimates/newEstimateNote.json";
    private const string BillEstimateResponsePath = "./Responses/Endpoints/Estimates/billEstimate.json";

    public EstimateEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _estimateEndpoint = new EstimateEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async Task GetEstimatesAsync_ByAccessToken_Returns_Estimates()
    {
        var estimatesList = await File.ReadAllTextAsync(GetEstimatesResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(estimatesList);

        var estimates = JsonSerializer.Deserialize<List<Estimate>>(estimatesList, _config.SerializerOptions);
        Assert.NotNull(estimates);

        var actualEstimates = await _estimateEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualEstimates);
        
        var actualEstimateList = actualEstimates.ToList();
        Assert.Equal(estimates.Count, actualEstimateList.Count);
        
        foreach (var actualEstimate in actualEstimateList)
        {
            var estimate = estimates.FirstOrDefault(w => w.Id == actualEstimate.Id);
            Assert.NotNull(estimate);

            estimate.Should().BeEquivalentTo(actualEstimate);
        }
    }
    
    [Fact]
    public async Task GetEstimatesAsync_UsingFilterOptions_ByAccessToken_Returns_Estimates()
    {
        var estimateList = await File.ReadAllTextAsync(GetEstimatesResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(estimateList);

        var estimates = JsonSerializer.Deserialize<List<Estimate>>(estimateList, _config.SerializerOptions);
        Assert.NotNull(estimates);
        
        var filterOptions = new EstimateFilterOptions
        {
            ContactId = "493530535844382136",
            State = EstimateState.Open,
            Period = "ThisYear",
            WorkflowId = "493530504057848981"
        };

        var actualEstimates = await _estimateEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualEstimates);
        
        var actualEstimateList = actualEstimates.ToList();
        Assert.Equal(estimates.Count, actualEstimateList.Count);
        
        foreach (var actualEstimate in actualEstimateList)
        {
            var estimate = estimates.FirstOrDefault(w => w.Id == actualEstimate.Id);
            Assert.NotNull(estimate);

            estimate.Should().BeEquivalentTo(actualEstimate);
        }
    }
    
    [Fact]
    public async Task GetEstimateByIdAsync_ByAccessToken_Returns_Single_Estimate()
    {
        var estimateJson = await File.ReadAllTextAsync(GetEstimateResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(estimateJson);
            
        var estimate = JsonSerializer.Deserialize<Estimate>(estimateJson, _config.SerializerOptions);
        Assert.NotNull(estimate);

        var actualEstimate = await _estimateEndpoint.GetByIdAsync(AdministrationId, EstimateId, AccessToken);
        Assert.NotNull(actualEstimate);

        estimate.Should().BeEquivalentTo(actualEstimate);
    }
    
    [Fact]
    public async Task GetEstimateByEstimateIdAsync_ByAccessToken_Returns_Single_Estimate()
    {
        var estimateJson = await File.ReadAllTextAsync(GetEstimateResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(estimateJson);
            
        var estimate = JsonSerializer.Deserialize<Estimate>(estimateJson, _config.SerializerOptions);
        Assert.NotNull(estimate);

        var actualEstimate = await _estimateEndpoint.GetByEstimateIdAsync(AdministrationId, "2026-0001", AccessToken);
        Assert.NotNull(actualEstimate);

        estimate.Should().BeEquivalentTo(actualEstimate);
    }
    
    [Fact]
    public async Task GetSynchronizationEstimatesAsync_ByAccessToken_Returns_SynchronizationEstimates()
    {
        var synchronizationEstimatesList = await File.ReadAllTextAsync(GetSynchronizationEstimatesResponsePath);
        
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationEstimatesList);

        var synchronizationEstimates = JsonSerializer.Deserialize<List<SynchronizationEstimate>>(synchronizationEstimatesList, _config.SerializerOptions);
        Assert.NotNull(synchronizationEstimates);
        
        var actualSynchronizationEstimates = await _estimateEndpoint.GetSynchronizationEstimatesAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualSynchronizationEstimates);

        var actualSynchronizationEstimateList = actualSynchronizationEstimates.ToList();
        Assert.Equal(synchronizationEstimates.Count, actualSynchronizationEstimateList.Count);
        
        foreach (var actualSynchronizationEstimate in actualSynchronizationEstimateList)
        {
            var synchronizationEstimate = synchronizationEstimates.FirstOrDefault(w => w.Id == actualSynchronizationEstimate.Id);
            Assert.NotNull(synchronizationEstimate);

            synchronizationEstimate.Should().BeEquivalentTo(actualSynchronizationEstimate);
        }
    }
    
    [Fact]
    public async Task GetSynchronizationEstimatesAsync_UsingFilterOptions_ByAccessToken_Returns_SynchronizationEstimates()
    {
        var synchronizationEstimatesList = await File.ReadAllTextAsync(GetSynchronizationEstimatesResponsePath);
        
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationEstimatesList);

        var synchronizationEstimates = JsonSerializer.Deserialize<List<SynchronizationEstimate>>(synchronizationEstimatesList, _config.SerializerOptions);
        Assert.NotNull(synchronizationEstimates);
        
        var filterOptions = new EstimateFilterOptions
        {
            ContactId = "493530535844382136",
            State = EstimateState.Open,
            Period = "ThisYear",
            WorkflowId = "493530504057848981"
        };

        var actualSynchronizationEstimates = await _estimateEndpoint.GetSynchronizationEstimatesAsync(
            AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualSynchronizationEstimates);
        
        var actualSynchronizationEstimateList = actualSynchronizationEstimates.ToList();
        Assert.Equal(synchronizationEstimates.Count, actualSynchronizationEstimateList.Count);
        
        foreach (var actualSynchronizationEstimate in actualSynchronizationEstimateList)
        {
            var synchronizationEstimate = synchronizationEstimates.FirstOrDefault(w => w.Id == actualSynchronizationEstimate.Id);
            Assert.NotNull(synchronizationEstimate);

            synchronizationEstimate.Should().BeEquivalentTo(actualSynchronizationEstimate);
        }
    }
    
    [Fact]
    public async Task GetEstimatesByIdsAsync_ByAccessToken_Returns_Estimates()
    {
        var estimatesByIds = await File.ReadAllTextAsync(GetEstimatesResponsePath);
        var estimateListOptions = new EstimateListOptions
        {
            Ids =
            [
                "493530535883179453",
                "493530536050951622"
            ]
        };
        
        var serializedEstimateListOptions = JsonSerializer.Serialize(estimateListOptions, _config.SerializerOptions);
        
        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedEstimateListOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(estimatesByIds);

        var expectedEstimatesByIds = JsonSerializer.Deserialize<List<Estimate>>(estimatesByIds, _config.SerializerOptions);
        Assert.NotNull(expectedEstimatesByIds);
        
        var actualEstimatesByIds = await _estimateEndpoint.GetEstimatesByIdsAsync(AdministrationId, AccessToken, estimateListOptions);
        Assert.NotNull(actualEstimatesByIds);

        var actualEstimateList = actualEstimatesByIds.ToList();
        Assert.Equal(expectedEstimatesByIds.Count, actualEstimateList.Count);
        
        foreach (var actualEstimate in actualEstimateList)
        {
            var estimate = expectedEstimatesByIds.FirstOrDefault(w => w.Id == actualEstimate.Id);
            Assert.NotNull(estimate);

            estimate.Should().BeEquivalentTo(actualEstimate);
        }
    }
    
    [Fact]
    public async Task CreateEstimateAsync_ByAccessToken_Returns_NewEstimate()
    {
        var options = new EstimateCreateOptions
        {
            Estimate = new EstimateCreate
            {
                Reference = "Project X",
                ContactId = "493530535844382136",
                ContactPersonId = "493530535849625018",
                Currency = "EUR",
                Language = "nl",
                EstimateDate = DateTime.UtcNow,
                FirstDueInterval = 14,
                PricesAreInclTax = false,
                ShowTax = true,
                Discount = 0,
                PreText = "Hello, here is your quote",
                PostText = "Please sign it",
                DetailsAttributes =
                [
                    new EstimateCreateDetail
                    {
                        Id = "493530535885276606",
                        TaxRateId = "493530503450723466",
                        LedgerAccountId = "493530503283999866",
                        ProjectId = null,
                        ProductId = null,
                        Amount = 1,
                        Description = "Project X",
                        Price = 300.0,
                        Period = "20260701..20260731",
                        RowOrder = 1,
                        Destroy = false,
                        AutomatedTaxEnabled = true,
                        IsOptional = false,
                        IsSelected = true
                    }
                ],
                CustomFieldsAttributes =
                [
                    new CustomFieldAttribute
                    {
                        Id = "1",
                        Value = "Custom field value"
                    }
                ]
            }
        };

        var createResponse = await File.ReadAllTextAsync(PostEstimateResponsePath);

        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<string>>()))
            .ReturnsAsync(createResponse);

        var estimate = JsonSerializer.Deserialize<Estimate>(createResponse, _config.SerializerOptions);
        Assert.NotNull(estimate);

        var actualEstimate = await _estimateEndpoint.CreateAsync(AdministrationId, options, AccessToken);
        Assert.NotNull(actualEstimate);

        estimate.Should().BeEquivalentTo(actualEstimate);
    }
    
    [Fact]
    public async Task UpdateEstimateAsync_ByAccessToken_Returns_UpdatedEstimate()
    {
        var estimateJson = await File.ReadAllTextAsync(GetEstimateResponsePath);
        var estimateUpdateOptions = new EstimateUpdateOptions
        {
            Estimate = new EstimateUpdate
            {
                ContactId = "493530535844382136",
                ContactPersonId = "493530535849625018",
                UpdateContact = true,
                DocumentStyleId = "493530504221426841",
                WorkflowId = "493530504057848981",
                Reference = "Project X updated",
                EstimateDate = DateTime.UtcNow,
                FirstDueInterval = 7,
                Currency = "EUR",
                Language = "nl",
                PricesAreInclTax = false,
                ShowTax = true,
                Discount = 0,
                PreText = "Updated pre text",
                PostText = "Updated post text",
                DetailsAttributes =
                [
                    new EstimateUpdateDetail
                    {
                        Id = "493530535885276606",
                        TaxRateId = "493530503450723466",
                        LedgerAccountId = "493530503283999866",
                        ProjectId = null,
                        ProductId = null,
                        Amount = 2,
                        Description = "Updated project X",
                        Price = 150.0,
                        Period = "20260701..20260731",
                        RowOrder = 1,
                        Destroy = false,
                        AutomatedTaxEnabled = true,
                        IsOptional = false,
                        IsSelected = true
                    }
                ],
                CustomFieldsAttributes =
                [
                    new CustomFieldAttribute
                    {
                        Id = "1",
                        Value = "Updated custom field value"
                    }
                ]
            }
        };
        
        var serializedEstimateUpdateOptions = JsonSerializer.Serialize(estimateUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedEstimateUpdateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(estimateJson);
    
        var estimate = JsonSerializer.Deserialize<Estimate>(estimateJson, _config.SerializerOptions);
        Assert.NotNull(estimate);

        var actualEstimate = await _estimateEndpoint.UpdateByIdAsync(AdministrationId, EstimateId, estimateUpdateOptions, AccessToken);
        Assert.NotNull(actualEstimate);

        estimate.Should().BeEquivalentTo(actualEstimate);
    }
    
    [Fact]
    public async Task DeleteEstimateAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualEstimate = await _estimateEndpoint.DeleteByIdAsync(AdministrationId, EstimateId, AccessToken);
        Assert.True(actualEstimate);
    }

    [Fact]
    public async Task SendEstimateAsync_ByAccessToken_Returns_UpdatedEstimate()
    {
        var estimateJson = await File.ReadAllTextAsync(SendEstimateResponsePath);
        var estimateSendOptions = new EstimateSendOptions
        {
            EstimateSend = new EstimateSend
            {
                DeliveryMethod = DeliveryMethod.Email,
                SendingScheduled = false,
                DeliverUbl = false,
                Mergeable = false,
                EmailAddress = "info@example.com",
                EmailMessage = "Geachte Foobar Holding B.V.,\n\nHierbij ontvangt u van ons een prijsopgave 2026-0004 voor onze diensten.\n\nMet vriendelijke groet,\n\nParkietje B.V."
            }
        };

        var serializedEstimateSendOptions = JsonSerializer.Serialize(estimateSendOptions, _config.SerializerOptions);

        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedEstimateSendOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(estimateJson);

        var estimate = JsonSerializer.Deserialize<Estimate>(estimateJson, _config.SerializerOptions);
        Assert.NotNull(estimate);

        var actualEstimate = await _estimateEndpoint.SendEstimate(AdministrationId, EstimateId, estimateSendOptions, AccessToken);
        Assert.NotNull(actualEstimate);

        estimate.Should().BeEquivalentTo(actualEstimate);
    }
    
    [Fact]
    public async Task ChangeEstimateStateAsync_ByAccessToken_Returns_UpdatedEstimate()
    {
        var estimateJson = await File.ReadAllTextAsync(SendEstimateResponsePath);
        var changeStateOptions = new EstimateChangeStateOptions
        {
            State = EstimateChangeState.Accepted
        };
        
        var serializedChangeStateOptions = JsonSerializer.Serialize(changeStateOptions, _config.SerializerOptions);

        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedChangeStateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(estimateJson);
        
        var estimate = JsonSerializer.Deserialize<Estimate>(estimateJson, _config.SerializerOptions);
        Assert.NotNull(estimate);

        var actualEstimate = await _estimateEndpoint.ChangeStateAsync(AdministrationId, EstimateId, changeStateOptions, AccessToken);
        Assert.NotNull(actualEstimate);
        
        estimate.Should().BeEquivalentTo(actualEstimate);
    }
    
    [Fact]
    public async Task BillEstimateAsync_ByAccessToken_Returns_NewSalesInvoice()
    {
        var salesInvoiceJson = await File.ReadAllTextAsync(BillEstimateResponsePath);
        
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<string>(s => s.Equals("{}")), It.IsAny<List<string>>()))
            .ReturnsAsync(salesInvoiceJson);
        
        var salesInvoice = JsonSerializer.Deserialize<SalesInvoice>(salesInvoiceJson, _config.SerializerOptions);
        Assert.NotNull(salesInvoice);

        var actualSalesInvoice = await _estimateEndpoint.BillEstimateAsync(AdministrationId, EstimateId, AccessToken);
        Assert.NotNull(actualSalesInvoice);
        
        salesInvoice.Should().BeEquivalentTo(actualSalesInvoice);
    }

    [Fact]
    public async Task AddEstimateAttachmentAsync_ByAccessToken_Returns()
    {
        _requester.Setup(moq => moq.CreatePostFileRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Stream>(), It.IsAny<List<string>>()));
        
        var file = new MemoryStream();
        await _estimateEndpoint.AddAttachmentAsync(AdministrationId, EstimateId, file, AccessToken, "testfile.pdf");
    }
    
    [Fact]
    public async Task DownloadEstimatePdfAsync_ByAccessToken_Returns_DownloadStream()
    {
        var expectedContent = "pdf-content";
        _requester.Setup(moq => moq.CreateDownloadRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<HttpMethod>(m => m == HttpMethod.Get), It.IsAny<List<string>>()))
            .ReturnsAsync(new MemoryStream(Encoding.UTF8.GetBytes(expectedContent)));

        using var actualDownload = await _estimateEndpoint.DownloadPdfAsync(AdministrationId, EstimateId, AccessToken);
        using var reader = new StreamReader(actualDownload);
        var actualContent = await reader.ReadToEndAsync();

        Assert.Equal(expectedContent, actualContent);
    }
    
    [Fact]
    public async Task DownloadEstimateAttachmentByIdAsync_ByAccessToken_Returns_DownloadStream()
    {
        var expectedContent = "attachment-content";
        _requester.Setup(moq => moq.CreateDownloadRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<HttpMethod>(m => m == HttpMethod.Get), It.IsAny<List<string>>()))
            .ReturnsAsync(new MemoryStream(Encoding.UTF8.GetBytes(expectedContent)));

        using var actualDownload = await _estimateEndpoint.DownloadAttachmentByIdAsync(AdministrationId, EstimateId, "493530535999000001", AccessToken);
        using var reader = new StreamReader(actualDownload);
        var actualContent = await reader.ReadToEndAsync();

        Assert.Equal(expectedContent, actualContent);
    }
    
    [Fact]
    public async Task DeleteEstimateAttachmentByIdAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualEstimateAttachment = await _estimateEndpoint.DeleteAttachmentByIdAsync(
            AdministrationId, EstimateId, "493530535999000001", AccessToken);
        Assert.True(actualEstimateAttachment);
    }
    
    [Fact]
    public async Task CreateEstimateNoteAsync_ByAccessToken_Returns_NewNote()
    {
        var estimateNoteJson = await File.ReadAllTextAsync(NewEstimateNoteResponsePath);
        var noteCreateOptions = new NoteCreateOptions
        {
            Note = new NoteCreateItem
            {
                Note = "Text of the note",
                Todo = true,
                AssigneeId = "340087760888006110"
            }
        };
                
        var serializedNoteCreateOptions = JsonSerializer.Serialize(noteCreateOptions, _config.SerializerOptions);
        
        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedNoteCreateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(estimateNoteJson);
        
        var estimateNote = JsonSerializer.Deserialize<Note>(estimateNoteJson, _config.SerializerOptions);
        Assert.NotNull(estimateNote);

        var actualEstimateNote = await _estimateEndpoint.CreateEstimateNoteAsync(
            AdministrationId, EstimateId, noteCreateOptions, AccessToken);
        Assert.NotNull(actualEstimateNote);

        estimateNote.Should().BeEquivalentTo(actualEstimateNote);
    }
    
    [Fact]
    public async Task DeleteEstimateNoteByIdAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualEstimateNote = await _estimateEndpoint.DeleteEstimateNoteByIdAsync(
            AdministrationId, EstimateId, "340087760940434912", AccessToken);
        Assert.True(actualEstimateNote);
    }
}
