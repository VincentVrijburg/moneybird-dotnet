using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.RecurringSalesInvoices;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.Notes;
using Moneybird.Net.Models.RecurringSalesInvoices;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class RecurringSalesInvoiceEndpointTests : RecurringSalesInvoiceTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly IRecurringSalesInvoiceEndpoint _recurringSalesInvoiceEndpoint;
    
    private const string GetRecurringSalesInvoicesResponsePath = "./Responses/Endpoints/RecurringSalesInvoices/getRecurringSalesInvoices.json";
    private const string GetSynchronizationRecurringSalesInvoicesResponsePath = "./Responses/Endpoints/RecurringSalesInvoices/getSynchronizationRecurringSalesInvoices.json";
    private const string GetRecurringSalesInvoiceResponsePath = "./Responses/Endpoints/RecurringSalesInvoices/getRecurringSalesInvoice.json";
    private const string PostRecurringSalesInvoiceResponsePath = "./Responses/Endpoints/RecurringSalesInvoices/postRecurringSalesInvoice.json";
    private const string PatchRecurringSalesInvoiceResponsePath = "./Responses/Endpoints/RecurringSalesInvoices/patchRecurringSalesInvoice.json";
    private const string NewRecurringSalesInvoiceNoteResponsePath = "./Responses/Endpoints/RecurringSalesInvoices/newRecurringSalesInvoiceNote.json";

    public RecurringSalesInvoiceEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _recurringSalesInvoiceEndpoint = new RecurringSalesInvoiceEndpoint(_config, _requester.Object);
    }

    [Fact]
    public async Task GetRecurringSalesInvoicesAsync_ByAccessToken_Returns_RecurringSalesInvoices()
    {
        var recurringSalesInvoicesList = await File.ReadAllTextAsync(GetRecurringSalesInvoicesResponsePath);
        
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(recurringSalesInvoicesList);

        var recurringSalesInvoices = JsonSerializer.Deserialize<List<RecurringSalesInvoice>>(recurringSalesInvoicesList, _config.SerializerOptions);
        Assert.NotNull(recurringSalesInvoices);
        
        var actualRecurringSalesInvoices = await _recurringSalesInvoiceEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualRecurringSalesInvoices);

        var actualRecurringSalesInvoiceList = actualRecurringSalesInvoices.ToList();
        Assert.Equal(recurringSalesInvoices.Count, actualRecurringSalesInvoiceList.Count);
        
        foreach (var actualRecurringSalesInvoice in actualRecurringSalesInvoiceList)
        {
            var recurringSalesInvoice = recurringSalesInvoices.FirstOrDefault(w => w.Id == actualRecurringSalesInvoice.Id);
            Assert.NotNull(recurringSalesInvoice);

            recurringSalesInvoice.Should().BeEquivalentTo(actualRecurringSalesInvoice);
        }
    }
    
    [Fact]
    public async Task GetRecurringSalesInvoicesAsync_UsingFilterOptions_ByAccessToken_Returns_RecurringSalesInvoices()
    {
        var recurringSalesInvoicesList = await File.ReadAllTextAsync(GetRecurringSalesInvoicesResponsePath);
        
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(recurringSalesInvoicesList);

        var recurringSalesInvoices = JsonSerializer.Deserialize<List<RecurringSalesInvoice>>(recurringSalesInvoicesList, _config.SerializerOptions);
        Assert.NotNull(recurringSalesInvoices);

        var filterOptions = new RecurringSalesInvoiceFilterOptions
        {
            State = "active",
            Frequency = FrequencyType.Month,
            AutoSend = false,
            ContactId = "492734981118887600",
            WorkflowId = "492734879064130703"
        };

        var actualRecurringSalesInvoices = await _recurringSalesInvoiceEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualRecurringSalesInvoices);
        
        var actualRecurringSalesInvoiceList = actualRecurringSalesInvoices.ToList();
        Assert.Equal(recurringSalesInvoices.Count, actualRecurringSalesInvoiceList.Count);
        
        foreach (var actualRecurringSalesInvoice in actualRecurringSalesInvoiceList)
        {
            var recurringSalesInvoice = recurringSalesInvoices.FirstOrDefault(w => w.Id == actualRecurringSalesInvoice.Id);
            Assert.NotNull(recurringSalesInvoice);

            recurringSalesInvoice.Should().BeEquivalentTo(actualRecurringSalesInvoice);
        }
    }
    
    [Fact]
    public async Task GetSynchronizationRecurringSalesInvoicesAsync_ByAccessToken_Returns_SynchronizationRecurringSalesInvoices()
    {
        var synchronizationRecurringSalesInvoicesList = await File.ReadAllTextAsync(GetSynchronizationRecurringSalesInvoicesResponsePath);
        
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationRecurringSalesInvoicesList);

        var synchronizationRecurringSalesInvoices = JsonSerializer.Deserialize<List<SynchronizationRecurringSalesInvoice>>(synchronizationRecurringSalesInvoicesList, _config.SerializerOptions);
        Assert.NotNull(synchronizationRecurringSalesInvoices);
        
        var actualSynchronizationRecurringSalesInvoices = await _recurringSalesInvoiceEndpoint.GetSynchronizationRecurringSalesInvoicesAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualSynchronizationRecurringSalesInvoices);

        var actualSynchronizationRecurringSalesInvoiceList = actualSynchronizationRecurringSalesInvoices.ToList();
        Assert.Equal(synchronizationRecurringSalesInvoices.Count, actualSynchronizationRecurringSalesInvoiceList.Count);
        
        foreach (var actualSynchronizationRecurringSalesInvoice in actualSynchronizationRecurringSalesInvoiceList)
        {
            var synchronizationRecurringSalesInvoice = synchronizationRecurringSalesInvoices.FirstOrDefault(w => w.Id == actualSynchronizationRecurringSalesInvoice.Id);
            Assert.NotNull(synchronizationRecurringSalesInvoice);

            synchronizationRecurringSalesInvoice.Should().BeEquivalentTo(actualSynchronizationRecurringSalesInvoice);
        }
    }
    
    [Fact]
    public async Task GetSynchronizationRecurringSalesInvoicesAsync_UsingFilterOptions_ByAccessToken_Returns_SynchronizationRecurringSalesInvoices()
    {
        var synchronizationRecurringSalesInvoicesList = await File.ReadAllTextAsync(GetSynchronizationRecurringSalesInvoicesResponsePath);
        
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationRecurringSalesInvoicesList);

        var synchronizationRecurringSalesInvoices = JsonSerializer.Deserialize<List<SynchronizationRecurringSalesInvoice>>(synchronizationRecurringSalesInvoicesList, _config.SerializerOptions);
        Assert.NotNull(synchronizationRecurringSalesInvoices);

        var filterOptions = new RecurringSalesInvoiceFilterOptions
        {
            State = "active",
            Frequency = FrequencyType.Month,
            AutoSend = false,
            ContactId = "492734981118887600",
            WorkflowId = "492734879064130703"
        };

        var actualSynchronizationRecurringSalesInvoices = await _recurringSalesInvoiceEndpoint
            .GetSynchronizationRecurringSalesInvoicesAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualSynchronizationRecurringSalesInvoices);
        
        var actualSynchronizationRecurringSalesInvoiceList = actualSynchronizationRecurringSalesInvoices.ToList();
        Assert.Equal(synchronizationRecurringSalesInvoices.Count, actualSynchronizationRecurringSalesInvoiceList.Count);
        
        foreach (var actualSynchronizationRecurringSalesInvoice in actualSynchronizationRecurringSalesInvoiceList)
        {
            var synchronizationRecurringSalesInvoice = synchronizationRecurringSalesInvoices.FirstOrDefault(w => w.Id == actualSynchronizationRecurringSalesInvoice.Id);
            Assert.NotNull(synchronizationRecurringSalesInvoice);

            synchronizationRecurringSalesInvoice.Should().BeEquivalentTo(actualSynchronizationRecurringSalesInvoice);
        }
    }
    
    [Fact]
    public async Task GetRecurringSalesInvoicesByIdsAsync_ByAccessToken_Returns_RecurringSalesInvoices()
    {
        var recurringSalesInvoicesByIds = await File.ReadAllTextAsync(GetRecurringSalesInvoicesResponsePath);
        var recurringSalesInvoiceListOptions = new RecurringSalesInvoiceListOptions
        {
            Ids = [
                "492734981166073525",
                "492734981138810545"
            ]
        };
        
        var serializedRecurringSalesInvoiceListOptions = JsonSerializer.Serialize(recurringSalesInvoiceListOptions, _config.SerializerOptions);
        
        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedRecurringSalesInvoiceListOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(recurringSalesInvoicesByIds);

        var expectedRecurringSalesInvoicesByIds = JsonSerializer.Deserialize<List<RecurringSalesInvoice>>(recurringSalesInvoicesByIds, _config.SerializerOptions);
        Assert.NotNull(expectedRecurringSalesInvoicesByIds);
        
        var actualRecurringSalesInvoicesByIds = await _recurringSalesInvoiceEndpoint.GetRecurringSalesInvoicesByIdsAsync(
            AdministrationId, AccessToken, recurringSalesInvoiceListOptions);
        Assert.NotNull(actualRecurringSalesInvoicesByIds);

        var actualRecurringSalesInvoiceList = actualRecurringSalesInvoicesByIds.ToList();
        Assert.Equal(expectedRecurringSalesInvoicesByIds.Count, actualRecurringSalesInvoiceList.Count);
        
        foreach (var actualRecurringSalesInvoice in actualRecurringSalesInvoiceList)
        {
            var recurringSalesInvoice = expectedRecurringSalesInvoicesByIds.FirstOrDefault(w => w.Id == actualRecurringSalesInvoice.Id);
            Assert.NotNull(recurringSalesInvoice);

            recurringSalesInvoice.Should().BeEquivalentTo(actualRecurringSalesInvoice);
        }
    }
    
    [Fact]
    public async Task GetRecurringSalesInvoiceAsync_ByAccessToken_Returns_Single_RecurringSalesInvoice()
    {
        var recurringSalesInvoiceJson = await File.ReadAllTextAsync(GetRecurringSalesInvoiceResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(recurringSalesInvoiceJson);
            
        var expectedRecurringSalesInvoice = JsonSerializer.Deserialize<RecurringSalesInvoice>(recurringSalesInvoiceJson, _config.SerializerOptions);
        Assert.NotNull(expectedRecurringSalesInvoice);

        var actualRecurringSalesInvoice = await _recurringSalesInvoiceEndpoint.GetByIdAsync(AdministrationId, RecurringSalesInvoiceId, AccessToken);
        Assert.NotNull(actualRecurringSalesInvoice);

        actualRecurringSalesInvoice.Should().BeEquivalentTo(expectedRecurringSalesInvoice);
    }
    
    [Fact]
    public async Task CreateRecurringSalesInvoiceAsync_ByAccessToken_Returns_NewRecurringSalesInvoice()
    {
        var recurringSalesInvoiceJson = await File.ReadAllTextAsync(PostRecurringSalesInvoiceResponsePath);
        var recurringSalesInvoiceCreateOptions = new RecurringSalesInvoiceCreateOptions
        {
            RecurringSalesInvoice = new RecurringSalesInvoiceCreate
            {
                ContactId = "492734981118887600",
                Reference = "My recurring invoice",
                InvoiceDate = DateTime.Parse("2030-01-01"),
                FrequencyType = FrequencyType.Month,
                Frequency = 1,
                AutoSend = false,
                DetailsAttributes =
                [
                    new RecurringSalesInvoiceCreateDetail
                    {
                        Description = "Table",
                        Price = 10.5,
                        TaxRateId = "492734878839735434",
                        LedgerAccountId = "492734878695031930"
                    }
                ]
            }
        };
        
        var serializedRecurringSalesInvoiceCreateOptions = JsonSerializer.Serialize(recurringSalesInvoiceCreateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedRecurringSalesInvoiceCreateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(recurringSalesInvoiceJson);
    
        var expectedRecurringSalesInvoice = JsonSerializer.Deserialize<RecurringSalesInvoice>(recurringSalesInvoiceJson, _config.SerializerOptions);
        Assert.NotNull(expectedRecurringSalesInvoice);

        var actualRecurringSalesInvoice = await _recurringSalesInvoiceEndpoint.CreateAsync(AdministrationId, recurringSalesInvoiceCreateOptions, AccessToken);
        Assert.NotNull(actualRecurringSalesInvoice);

        actualRecurringSalesInvoice.Should().BeEquivalentTo(expectedRecurringSalesInvoice);
    }
    
    [Fact]
    public async Task UpdateRecurringSalesInvoiceAsync_ByAccessToken_Returns_UpdatedRecurringSalesInvoice()
    {
        var recurringSalesInvoiceJson = await File.ReadAllTextAsync(PatchRecurringSalesInvoiceResponsePath);
        var recurringSalesInvoiceUpdateOptions = new RecurringSalesInvoiceUpdateOptions
        {
            RecurringSalesInvoice = new RecurringSalesInvoiceUpdate
            {
                Reference = "Updated recurring invoice",
                FrequencyType = FrequencyType.Month,
                DetailsAttributes =
                [
                    new RecurringSalesInvoiceUpdateDetail
                    {
                        Id = "492734981167122102",
                        Price = 20.0
                    }
                ]
            }
        };
        
        var serializedRecurringSalesInvoiceUpdateOptions = JsonSerializer.Serialize(recurringSalesInvoiceUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedRecurringSalesInvoiceUpdateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(recurringSalesInvoiceJson);
    
        var expectedRecurringSalesInvoice = JsonSerializer.Deserialize<RecurringSalesInvoice>(recurringSalesInvoiceJson, _config.SerializerOptions);
        Assert.NotNull(expectedRecurringSalesInvoice);

        var actualRecurringSalesInvoice = await _recurringSalesInvoiceEndpoint.UpdateByIdAsync(
            AdministrationId, RecurringSalesInvoiceId, recurringSalesInvoiceUpdateOptions, AccessToken);
        Assert.NotNull(actualRecurringSalesInvoice);

        actualRecurringSalesInvoice.Should().BeEquivalentTo(expectedRecurringSalesInvoice);
    }
    
    [Fact]
    public async Task DeleteRecurringSalesInvoiceAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualRecurringSalesInvoice = await _recurringSalesInvoiceEndpoint.DeleteByIdAsync(AdministrationId, RecurringSalesInvoiceId, AccessToken);
        Assert.True(actualRecurringSalesInvoice);
    }
    
    [Fact]
    public async Task CreateRecurringSalesInvoiceNoteAsync_ByAccessToken_Returns_NewNote()
    {
        var recurringSalesInvoiceNoteJson = await File.ReadAllTextAsync(NewRecurringSalesInvoiceNoteResponsePath);
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
            .ReturnsAsync(recurringSalesInvoiceNoteJson);
        
        var recurringSalesInvoiceNote = JsonSerializer.Deserialize<Note>(recurringSalesInvoiceNoteJson, _config.SerializerOptions);
        Assert.NotNull(recurringSalesInvoiceNote);

        var actualRecurringSalesInvoiceNote = await _recurringSalesInvoiceEndpoint.CreateRecurringSalesInvoiceNoteAsync(
            AdministrationId, RecurringSalesInvoiceId, noteCreateOptions, AccessToken);
        Assert.NotNull(actualRecurringSalesInvoiceNote);

        recurringSalesInvoiceNote.Should().BeEquivalentTo(actualRecurringSalesInvoiceNote);
    }
    
    [Fact]
    public async Task DeleteRecurringSalesInvoiceNoteByIdAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualRecurringSalesInvoiceNote = await _recurringSalesInvoiceEndpoint.DeleteRecurringSalesInvoiceNoteByIdAsync(
            AdministrationId, RecurringSalesInvoiceId, NoteId, AccessToken);
        Assert.True(actualRecurringSalesInvoiceNote);
    }
}
