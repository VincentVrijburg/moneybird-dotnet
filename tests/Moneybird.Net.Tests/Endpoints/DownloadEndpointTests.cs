using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.Downloads;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Downloads;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints;

public class DownloadEndpointTests : DownloadsTestBase
{
    private static Mock<IRequester> _requester;
    private readonly MoneybirdConfig _config;
    private readonly DownloadEndpoint _downloadEndpoint;

    private const string GetDownloadsResponsePath = "./Responses/Endpoints/Downloads/getDownloads.json";

    public DownloadEndpointTests()
    {
        _requester = new Mock<IRequester>();
        _config = new MoneybirdConfig();
        _downloadEndpoint = new DownloadEndpoint(_config, _requester.Object);
    }

    [Fact]
    public async Task GetDownloadsAsync_ByAccessToken_Returns_Downloads()
    {
        var downloadsListJson = await File.ReadAllTextAsync(GetDownloadsResponsePath);

        _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(downloadsListJson);

        var downloads = JsonSerializer.Deserialize<List<Download>>(downloadsListJson, _config.SerializerOptions);
        Assert.NotNull(downloads);

        var actualDownloads = await _downloadEndpoint.GetAsync(AdministrationId, AccessToken);
        Assert.NotNull(actualDownloads);

        var actualDownloadsList = actualDownloads.ToList();
        Assert.Equal(downloads.Count, actualDownloadsList.Count);

        foreach (var actualDownload in actualDownloadsList)
        {
            var download = downloads.FirstOrDefault(w => w.Id == actualDownload.Id);
            Assert.NotNull(download);

            download.Should().BeEquivalentTo(actualDownload);
        }
    }

    [Fact]
    public async Task GetDownloadsAsync_UsingFilterOptions_ByAccessToken_Returns_Downloads()
    {
        var downloadsListJson = await File.ReadAllTextAsync(GetDownloadsResponsePath);
        var filterOptions = new DownloadFilterOptions
        {
            DownloadType = DownloadType.ExportContacts,
            Downloaded = false,
            Failed = false
        };

        _requester.Setup(moq => moq.CreateGetRequestAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.Is<List<string>>(parameters =>
                    parameters.Contains("page=1") &&
                    parameters.Contains("per_page=50") &&
                    parameters.Contains("download_type=export_contacts") &&
                    parameters.Contains("downloaded=false") &&
                    parameters.Contains("failed=false"))))
            .ReturnsAsync(downloadsListJson);

        var downloads = JsonSerializer.Deserialize<List<Download>>(downloadsListJson, _config.SerializerOptions);
        Assert.NotNull(downloads);

        var actualDownloads = await _downloadEndpoint.GetAsync(AdministrationId, AccessToken, filterOptions);
        Assert.NotNull(actualDownloads);

        var actualDownloadsList = actualDownloads.ToList();
        Assert.Equal(downloads.Count, actualDownloadsList.Count);

        foreach (var actualDownload in actualDownloadsList)
        {
            var download = downloads.FirstOrDefault(w => w.Id == actualDownload.Id);
            Assert.NotNull(download);

            download.Should().BeEquivalentTo(actualDownload);
        }
    }

    [Fact]
    public async Task DownloadByIdAsync_ByAccessToken_Returns_DownloadStream()
    {
        var expectedContent = "id,name\r\n1,Export";
        _requester.Setup(moq => moq.CreatePostDownloadRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>()))
            .ReturnsAsync(new MemoryStream(Encoding.UTF8.GetBytes(expectedContent)));

        using var actualDownload = await _downloadEndpoint.DownloadByIdAsync(AdministrationId, DownloadId, AccessToken);
        using var reader = new StreamReader(actualDownload);
        var actualContent = await reader.ReadToEndAsync();

        Assert.Equal(expectedContent, actualContent);
    }
}
