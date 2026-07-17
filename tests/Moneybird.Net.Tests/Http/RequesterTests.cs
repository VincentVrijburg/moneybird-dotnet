using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moneybird.Net.Http;
using Moq;
using Moq.Protected;
using Xunit;

namespace Moneybird.Net.Tests.Http;

public class RequesterTests
{
    [Fact]
    public async Task CreatePostDownloadRequestAsync_FoundWithAbsoluteLocation_Returns_DownloadStream()
    {
        var requests = new List<HttpRequestMessage>();
        var callIndex = 0;
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns<HttpRequestMessage, CancellationToken>((request, _) =>
            {
                requests.Add(request);
                if (callIndex++ == 0)
                {
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Found)
                    {
                        Headers = { Location = new System.Uri("https://files.moneybird.com/exports/download.csv") }
                    });
                }

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("id,name\r\n1,Export", Encoding.UTF8)
                });
            });

        var requester = new Requester(new HttpClient(handlerMock.Object));

        using var stream = await requester.CreatePostDownloadRequestAsync(
            "https://moneybird.com/api/v2/",
            "/123/downloads/1/download.json",
            "access-token");

        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();

        Assert.Equal("id,name\r\n1,Export", content);
        Assert.Equal(2, requests.Count);
        Assert.Equal(HttpMethod.Post, requests[0].Method);
        Assert.Equal(HttpMethod.Get, requests[1].Method);
        Assert.Equal("https://files.moneybird.com/exports/download.csv", requests[1].RequestUri!.ToString());
    }

    [Fact]
    public async Task CreatePostDownloadRequestAsync_FoundWithRelativeLocation_Uses_HostForDownloadRequest()
    {
        var requests = new List<HttpRequestMessage>();
        var callIndex = 0;
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns<HttpRequestMessage, CancellationToken>((request, _) =>
            {
                requests.Add(request);
                if (callIndex++ == 0)
                {
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Found)
                    {
                        Headers = { Location = new System.Uri("/exports/relative.csv", System.UriKind.Relative) }
                    });
                }

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("relative-file", Encoding.UTF8)
                });
            });

        var requester = new Requester(new HttpClient(handlerMock.Object));
        const string host = "https://moneybird.com/api/v2/";

        using var stream = await requester.CreatePostDownloadRequestAsync(
            host,
            "/123/downloads/1/download.json",
            "access-token");

        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();

        Assert.Equal("relative-file", content);
        Assert.Equal("https://moneybird.com/exports/relative.csv", requests[1].RequestUri!.ToString());
    }

    [Fact]
    public async Task CreatePostDownloadRequestAsync_NonFoundSuccessResponse_Throws_MoneybirdException()
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"message\":\"unexpected\"}", Encoding.UTF8)
            });

        var requester = new Requester(new HttpClient(handlerMock.Object));

        var exception = await Assert.ThrowsAsync<MoneybirdException>(() =>
            requester.CreatePostDownloadRequestAsync(
                "https://moneybird.com/api/v2/",
                "/123/downloads/1/download.json",
                "access-token"));

        Assert.Equal(HttpStatusCode.OK, exception.HttpStatusCode);
        Assert.Equal("Expected a 302 redirect with a Location header when downloading a file.", exception.Message);
    }
}
