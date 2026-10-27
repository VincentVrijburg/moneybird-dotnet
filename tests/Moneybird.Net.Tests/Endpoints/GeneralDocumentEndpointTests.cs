using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.GeneralDocuments;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.GeneralDocuments;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class GeneralDocumentEndpointTests : GeneralDocumentTestBase
{
    private const string GetGeneralDocumentsResponsePath = "./Responses/Endpoints/GeneralDocuments/getGeneralDocuments.json";
    private const string GetGeneralDocumentResponsePath = "./Responses/Endpoints/GeneralDocuments/getGeneralDocument.json";
    private const string GetGeneralDocumentNewResponsePath = "./Responses/Endpoints/GeneralDocuments/getGeneralDocumentNew.json";
    private const string PostGeneralDocumentResponsePath = "./Responses/Endpoints/GeneralDocuments/postGeneralDocument.json";
    private const string PatchGeneralDocumentResponsePath = "./Responses/Endpoints/GeneralDocuments/patchGeneralDocument.json";

    private readonly Mock<IRequester> _requester = new();
    private readonly MoneybirdConfig _config = new();
    private readonly GeneralDocumentEndpoint _endpoint;

    public GeneralDocumentEndpointTests()
    {
        _endpoint = new GeneralDocumentEndpoint(_config, _requester.Object);
    }

    [Fact]
    public async Task GetAsync_ByAccessToken_ReturnsGeneralDocuments()
    {
        var json = await File.ReadAllTextAsync(GetGeneralDocumentsResponsePath);
        List<string> query = null;
        _requester
            .Setup(requester => requester.CreateGetRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<List<string>>()))
            .Callback<string, string, string, List<string>>((_, relativeUrl, _, values) =>
            {
                relativeUrl.Should().Be($"/{AdministrationId}/documents/general_documents.json");
                query = values;
            })
            .ReturnsAsync(json);

        var expected = JsonSerializer.Deserialize<List<GeneralDocument>>(json, _config.SerializerOptions);
        var actual = (await _endpoint.GetAsync(AdministrationId, AccessToken, 2, 25)).ToList();

        actual.Should().BeEquivalentTo(expected);
        actual.Should().OnlyContain(document => document.AdministrationId == AdministrationId);
        actual.Select(document => document.EntryNumber).Should().Equal(5, 4, 3, 2);
        query.Should().BeEquivalentTo(new[] { "page=2", "per_page=25" });
    }

    [Fact]
    public async Task GetAsync_UsingFilterOptions_IncludesFilter()
    {
        var json = await File.ReadAllTextAsync(GetGeneralDocumentsResponsePath);
        List<string> query = null;
        _requester
            .Setup(requester => requester.CreateGetRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<List<string>>()))
            .Callback<string, string, string, List<string>>((_, _, _, values) => query = values)
            .ReturnsAsync(json);

        var options = new GeneralDocumentFilterOptions
        {
            Period = "20251016..20261016",
            State = new[] { GeneralDocumentState.Saved }
        };

        var actual = await _endpoint.GetAsync(AdministrationId, AccessToken, options);

        actual.Should().NotBeEmpty();
        query.Should().BeEquivalentTo(new[]
        {
            "page=1",
            "per_page=50",
            "filter=period:20251016..20261016,state:saved"
        });
    }

    [Fact]
    public async Task GetByIdAsync_DeserializesOfficialExample()
    {
        var json = await File.ReadAllTextAsync(GetGeneralDocumentResponsePath);
        _requester
            .Setup(requester => requester.CreateGetRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<List<string>>()))
            .ReturnsAsync(json);

        var expected = JsonSerializer.Deserialize<GeneralDocument>(json, _config.SerializerOptions);
        var actual = await _endpoint.GetByIdAsync(AdministrationId, GeneralDocumentId, AccessToken);

        actual.Should().BeEquivalentTo(expected);
        actual.Id.Should().Be(GeneralDocumentId);
        actual.AdministrationId.Should().Be(AdministrationId);
        actual.Reference.Should().Be("Contract");
        actual.State.Should().Be(GeneralDocumentState.Saved);
        actual.Date.Should().Be(new DateTime(2026, 10, 16));
        actual.EntryNumber.Should().Be(2);
        actual.ExchangeRate.Should().Be("1.0");
        actual.Contact.Should().BeNull();
        actual.Events.Single().Action.Should().Be("document_saved");
        actual.Events.Single().AdministrationId.Should().Be(AdministrationId);
    }

    [Fact]
    public async Task GetByIdAsync_DeserializesNullableEntryNumber()
    {
        var json = await File.ReadAllTextAsync(GetGeneralDocumentNewResponsePath);
        _requester
            .Setup(requester => requester.CreateGetRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<List<string>>()))
            .ReturnsAsync(json);

        var actual = await _endpoint.GetByIdAsync(AdministrationId, NewGeneralDocumentId, AccessToken);

        actual.State.Should().Be(GeneralDocumentState.New);
        actual.EntryNumber.Should().BeNull();
        actual.Events.Should().BeEmpty();
        actual.Date.Should().Be(new DateTime(2025, 10, 16));
    }

    [Fact]
    public async Task CreateAsync_SerializesRequestAndDeserializesOfficialExample()
    {
        var options = new GeneralDocumentCreateOptions
        {
            GeneralDocument = new GeneralDocumentCreate
            {
                Reference = "foobar",
                ContactId = ContactId,
                Date = new DateTime(2026, 10, 16),
                Reminder = new GeneralDocumentReminder
                {
                    Date = new DateTime(2026, 10, 20),
                    Message = "Follow up"
                }
            }
        };
        var json = await File.ReadAllTextAsync(PostGeneralDocumentResponsePath);
        string body = null;
        _requester
            .Setup(requester => requester.CreatePostRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<string>(), It.IsAny<List<string>>()))
            .Callback<string, string, string, string, List<string>>((_, relativeUrl, _, value, _) =>
            {
                relativeUrl.Should().Be($"/{AdministrationId}/documents/general_documents.json");
                body = value;
            })
            .ReturnsAsync(json);

        var actual = await _endpoint.CreateAsync(AdministrationId, options, AccessToken);

        actual.Id.Should().Be(CreatedGeneralDocumentId);
        actual.Reference.Should().Be("foobar");
        actual.State.Should().Be(GeneralDocumentState.Saved);
        actual.EntryNumber.Should().Be(3);
        actual.ContactId.Should().Be(ContactId);
        actual.Contact.CompanyName.Should().Be("Foobar Holding B.V.");
        actual.Contact.AdministrationId.Should().Be(AdministrationId);
        actual.Contact.DeliveryMethod.Should().Be(DeliveryMethod.Email);
        actual.Contact.SepaSequenceType.Should().Be(SepaSequenceType.RCUR);
        actual.Contact.EmailUbl.Should().BeTrue();
        actual.Events.Single().Action.Should().Be("document_saved");
        body.Should().Be(JsonSerializer.Serialize(options, _config.SerializerOptions));
        using var document = JsonDocument.Parse(body);
        document.RootElement.GetProperty("general_document").GetProperty("reference").GetString().Should().Be("foobar");
        document.RootElement.GetProperty("general_document").GetProperty("contact_id").GetString().Should().Be(ContactId);
        document.RootElement.GetProperty("general_document").GetProperty("reminder").GetProperty("message").GetString().Should().Be("Follow up");
    }

    [Fact]
    public async Task UpdateByIdAsync_SerializesRequestAndDeserializesOfficialExample()
    {
        var options = new GeneralDocumentUpdateOptions
        {
            GeneralDocument = new GeneralDocumentUpdate
            {
                Reference = "updated reference"
            },
            RemoveContact = true
        };
        var json = await File.ReadAllTextAsync(PatchGeneralDocumentResponsePath);
        string body = null;
        _requester
            .Setup(requester => requester.CreatePatchRequestAsync(
                It.IsAny<string>(), It.IsAny<string>(), AccessToken, It.IsAny<string>(), It.IsAny<List<string>>()))
            .Callback<string, string, string, string, List<string>>((_, relativeUrl, _, value, _) =>
            {
                relativeUrl.Should().Be($"/{AdministrationId}/documents/general_documents/{GeneralDocumentId}.json");
                body = value;
            })
            .ReturnsAsync(json);

        var actual = await _endpoint.UpdateByIdAsync(AdministrationId, GeneralDocumentId, options, AccessToken);

        actual.Id.Should().Be(UpdatedGeneralDocumentId);
        actual.Reference.Should().Be("updated reference");
        actual.Events.Select(evt => evt.Action).Should().Equal("document_saved", "document_updated");
        body.Should().Be(JsonSerializer.Serialize(options, _config.SerializerOptions));
        using var document = JsonDocument.Parse(body);
        document.RootElement.GetProperty("general_document").GetProperty("reference").GetString().Should().Be("updated reference");
        document.RootElement.GetProperty("remove_contact").GetBoolean().Should().BeTrue();
    }

    [Fact]
    public async Task DeleteByIdAsync_ByAccessToken_Returns_True()
    {
        _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);

        var response = await _endpoint.DeleteByIdAsync(AdministrationId, GeneralDocumentId, AccessToken);
        Assert.True(response);
    }
}
