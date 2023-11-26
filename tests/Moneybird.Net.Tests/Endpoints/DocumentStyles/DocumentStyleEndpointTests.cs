using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.DocumentStyles;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.DocumentStyles
{
    public class DocumentStyleEndpointTests : CommonTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly MoneybirdConfig _config;
        private readonly IDocumentStyleEndpoint _documentStyleEndpoint;

        private const string ResponsePath = "./Responses/Endpoints/DocumentStyles/getDocumentStyles.json";
        
        public DocumentStyleEndpointTests()
        {  
            _requester = new Mock<IRequester>();
            _config = new MoneybirdConfig();
            _documentStyleEndpoint = new DocumentStyleEndpoint(_config, _requester.Object);
        }
        
        [Fact]
        public async void GetDocumentStylesAsync_ByAccessToken_Returns_DocumentStyleList()
        {
            var documentStyleListJson = await File.ReadAllTextAsync(ResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(documentStyleListJson);
            
            var documentStyleList = JsonSerializer.Deserialize<List<DocumentStyle>>(documentStyleListJson, _config.SerializerOptions);
            Assert.NotNull(documentStyleList);

            var actualDocumentStyleList = await _documentStyleEndpoint.GetAsync(AdministrationId, AccessToken);
            Assert.NotNull(actualDocumentStyleList);

            var actualDocumentStyles = actualDocumentStyleList.ToList();
            Assert.Equal(documentStyleList.Count, actualDocumentStyles.Count);
            foreach (var actualDocumentStyle in actualDocumentStyles)
            {
                var documentStyle = documentStyleList.FirstOrDefault(a => a.Id == actualDocumentStyle.Id);
                Assert.NotNull(documentStyle);

                documentStyle.Should().BeEquivalentTo(actualDocumentStyle);
            }
        }
    }
}
