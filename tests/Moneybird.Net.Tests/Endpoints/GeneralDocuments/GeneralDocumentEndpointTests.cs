using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.GeneralDocuments;
using Moneybird.Net.Entities.GeneralDocuments;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.GeneralDocuments
{
    public class GeneralDocumentEndpointTests : CommonTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly MoneybirdConfig _config;
        private readonly IGeneralDocumentEndpoint _generalDocumentEndpoint;

        private const string GetSynchronizationDocumentsResponsePath = "./Responses/Endpoints/GeneralDocuments/getSynchronizationDocuments.json";

        public GeneralDocumentEndpointTests()
        {  
            _requester = new Mock<IRequester>();
            _config = new MoneybirdConfig();
            _generalDocumentEndpoint = new GeneralDocumentEndpoint(_config, _requester.Object);
        }

        [Fact]
        public async void GetSynchronizationDocumentsAsync_ByAccessToken_Returns_ListOf_GeneralSynchronizationDocuments()
        {
            var expectedJson = await File.ReadAllTextAsync(GetSynchronizationDocumentsResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(expectedJson);
            
            var expectedResultList = JsonSerializer.Deserialize<List<GeneralSynchronizationDocument>>(expectedJson, _config.SerializerOptions);
            Assert.NotNull(expectedResultList);

            var actualResult = await _generalDocumentEndpoint.GetSynchronizationDocumentsAsync(AdministrationId, AccessToken);
            Assert.NotNull(actualResult);

            var actualResultList = actualResult.ToList();
            Assert.Equal(expectedResultList.Count, actualResultList.Count);
            foreach (var actualItem in actualResultList)
            {
                var expectedItem = expectedResultList.FirstOrDefault(a => a.Id == actualItem.Id);
                Assert.NotNull(expectedItem);
                
                actualItem.Should().BeEquivalentTo(expectedItem);
            }
        }
    }
}