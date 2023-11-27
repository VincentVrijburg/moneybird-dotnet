using System;
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
using Moneybird.Net.Models.TimeEntries;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class TimeEntryEndpointTests : TimeEntryTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly TimeEntryEndpoint _timeEntryEndpoint;
    
    private const string GetTimeEntriesResponsePath = "./Responses/Endpoints/TimeEntries/getTimeEntries.json";
    private const string GetTimeEntryResponsePath = "./Responses/Endpoints/TimeEntries/getTimeEntry.json";
    private const string PostTimeEntryResponsePath = "./Responses/Endpoints/TimeEntries/postTimeEntry.json";
    private const string PatchTimeEntryResponsePath = "./Responses/Endpoints/TimeEntries/patchTimeEntry.json";
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
        var timeEntriesList = await File.ReadAllTextAsync(GetTimeEntriesResponsePath);

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
    public async void GetTimeEntriesAsync_UsingFilterOptions_ByAccessToken_Returns_TimeEntries()
    {
        var timeEntryListJson = await File.ReadAllTextAsync(GetTimeEntriesResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(timeEntryListJson);

        var timeEntries = JsonSerializer.Deserialize<List<TimeEntry>>(timeEntryListJson, _config.SerializerOptions);
        Assert.NotNull(timeEntries);
        
        var filterOptions = new TimeEntryFilterOptions
        {
            State = new [] { TimeEntryState.All },
            Period = "this_month",
            ContactId = "381666401394414610",
            IncludeNilContacts = true,
            IncludeActive = false,
            ProjectId = "386844401331200766",
            UserId = "252969831744742910",
            Day = DateTime.Parse("2023-11-10")
        };

        var actualTimeEntries = await _timeEntryEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualTimeEntries);
        
        var actualTimeEntryList = actualTimeEntries.ToList();
        Assert.Equal(timeEntries.Count, actualTimeEntryList.Count);
        
        foreach (var actualTimeEntry in actualTimeEntryList)
        {
            var timeEntry = timeEntries.FirstOrDefault(w => w.Id == actualTimeEntry.Id);
            Assert.NotNull(timeEntry);

            timeEntry.Should().BeEquivalentTo(actualTimeEntry);
        }
    }
    
    [Fact]
    public async void GetTimeEntryAsync_ByAccessToken_Returns_Single_TimeEntry()
    {
        var timeEntryJson = await File.ReadAllTextAsync(GetTimeEntryResponsePath);
            
        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(timeEntryJson);
            
        var expectedTimeEntry = JsonSerializer.Deserialize<TimeEntry>(timeEntryJson, _config.SerializerOptions);
        Assert.NotNull(expectedTimeEntry);

        var actualTimeEntry = await _timeEntryEndpoint.GetByIdAsync(AdministrationId, TimeEntryId, AccessToken);
        Assert.NotNull(actualTimeEntry);

        actualTimeEntry.Should().BeEquivalentTo(expectedTimeEntry);
    }
    
    [Fact]
    public async void CreateTimeEntryAsync_ByAccessToken_Returns_NewTimeEntry()
    {
        var timeEntryJson = await File.ReadAllTextAsync(PostTimeEntryResponsePath);
        var timeEntryCreateOptions = new TimeEntryCreateOptions
        {
            TimeEntry = new TimeEntryCreate
            {
                StartedAt = DateTime.Parse("2023-08-10 09:25:00"),
                EndedAt = DateTime.Parse("2023-08-10 10:25:00"),
                Description = "Test time entry",
                ContactId = "395774014807606787",
                ProjectId = "395774014821238277",
                UserId = "1691659319295",
                Billable = false,
                DetailId = null,
                PausedDuration = 0
            }
        };
        
        var serializedTimeEntryCreateOptions = JsonSerializer.Serialize(timeEntryCreateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedTimeEntryCreateOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(timeEntryJson);
    
        var expectedTimeEntry = JsonSerializer.Deserialize<TimeEntry>(timeEntryJson, _config.SerializerOptions);
        Assert.NotNull(expectedTimeEntry);

        var actualTimeEntry = await _timeEntryEndpoint.CreateAsync(AdministrationId, timeEntryCreateOptions, AccessToken);
        Assert.NotNull(actualTimeEntry);

        actualTimeEntry.Should().BeEquivalentTo(expectedTimeEntry);
    }
    
    [Fact]
    public async void UpdateTimeEntryAsync_ByAccessToken_Returns_UpdatedTimeEntry()
    {
        var timeEntryJson = await File.ReadAllTextAsync(PatchTimeEntryResponsePath);
        var timeEntryUpdateOptions = new TimeEntryUpdateOptions
        {
            TimeEntry = new TimeEntryUpdate
            {
                StartedAt = DateTime.Parse("2023-08-10 09:25:00"),
                EndedAt = DateTime.Parse("2023-08-10 10:25:00"),
                Description = "Updated description",
                ContactId = "395774015039342091",
                ProjectId = "395774015051925005",
                Billable = false,
                PausedDuration = 0
            }
        };
        
        var serializedTimeEntryOptions = JsonSerializer.Serialize(timeEntryUpdateOptions, _config.SerializerOptions);
    
        _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedTimeEntryOptions)), It.IsAny<List<string>>()))
            .ReturnsAsync(timeEntryJson);
    
        var expectedTimeEntry = JsonSerializer.Deserialize<TimeEntry>(timeEntryJson, _config.SerializerOptions);
        Assert.NotNull(expectedTimeEntry);

        var actualTimeEntry = await _timeEntryEndpoint.UpdateByIdAsync(AdministrationId, TimeEntryId, timeEntryUpdateOptions, AccessToken);
        Assert.NotNull(actualTimeEntry);

        actualTimeEntry.Should().BeEquivalentTo(expectedTimeEntry);
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