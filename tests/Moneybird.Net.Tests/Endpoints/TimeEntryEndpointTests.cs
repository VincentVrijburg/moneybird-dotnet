using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.TimeEntries;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Notes;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class TimeEntryEndpointTests : TimeEntryTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly TimeEntryEndpoint _timeEntryEndpoint;
    
    private const string ResponsePath = "./Responses/Endpoints/TimeEntries/getTimeEntries.json";
    private const string NewTimeEntryNoteResponsePath = "./Responses/Endpoints/TimeEntries/newTimeEntryNote.json";
    
    public TimeEntryEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _timeEntryEndpoint = new TimeEntryEndpoint(_config, _requester.Object);
    }
    
    [Fact]
    public async void GetTimeEntriesAsync_ByAccessToken_Returns_TimeEntries()
    {
        var timeEntriesList = await File.ReadAllTextAsync(ResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(timeEntriesList);

        var timeEntries = JsonSerializer.Deserialize<List<TimeEntry>>(timeEntriesList, _config.SerializerOptions);
        Assert.NotNull(timeEntries);

        var actualTimeEntries = await _timeEntryEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualTimeEntries);
        
        var actualTimeEntryList = actualTimeEntries.ToList();
        Assert.Equal(timeEntries.Count, actualTimeEntryList.Count);
        
        foreach (var actualTimeEntry in actualTimeEntryList)
        {
            var user = timeEntries.FirstOrDefault(w => w.Id == actualTimeEntry.Id);
            Assert.NotNull(user);

            user.Should().BeEquivalentTo(actualTimeEntry);
        }
    }
    
    [Fact]
    public async void DeleteTimeEntryAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualTimeEntry = await _timeEntryEndpoint.DeleteByIdAsync(AdministrationId, TimeEntryId, AccessToken);
        Assert.True(actualTimeEntry);
    }
    
    [Fact]
    public async void CreateTimeEntryNoteAsync_ByAccessToken_Returns_NewNote()
    {
        var timeEntryNoteJson = await File.ReadAllTextAsync(NewTimeEntryNoteResponsePath);
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
            .ReturnsAsync(timeEntryNoteJson);
        
        var timeEntryNote = JsonSerializer.Deserialize<Note>(timeEntryNoteJson, _config.SerializerOptions);
        Assert.NotNull(timeEntryNote);

        var actualTimeEntryNote = await _timeEntryEndpoint.CreateTimeEntryNoteAsync(AdministrationId, TimeEntryId, noteCreateOptions, AccessToken);
        Assert.NotNull(actualTimeEntryNote);

        timeEntryNote.Should().BeEquivalentTo(actualTimeEntryNote);
    }
    
    [Fact]
    public async void DeleteTimeEntryNoteByIdAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
        var actualTimeEntryNote = await _timeEntryEndpoint.DeleteTimeEntryNoteByIdAsync(AdministrationId, TimeEntryId, NoteId, AccessToken);
        Assert.True(actualTimeEntryNote);
    }
}