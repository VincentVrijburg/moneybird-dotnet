using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.GeneralDocuments;
using Moneybird.Net.Endpoints.GeneralDocuments.Models;
using Moneybird.Net.Entities.GeneralDocuments;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.GeneralDocuments
{
    public class GeneralDocumentEndpointTests : GeneralDocumentTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly MoneybirdConfig _config;
        private readonly IGeneralDocumentEndpoint _generalDocumentEndpoint;

        private const string GetDocumentsResponsePath = "./Responses/Endpoints/GeneralDocuments/getDocuments.json";
        private const string GetSynchronizationDocumentsResponsePath = "./Responses/Endpoints/GeneralDocuments/getSynchronizationDocuments.json";
        private const string GetDocumentsByIdsResponsePath = "./Responses/Endpoints/GeneralDocuments/getDocumentsByIds.json";
        private const string GetDocumentResponsePath = "./Responses/Endpoints/GeneralDocuments/getDocument.json";

        public GeneralDocumentEndpointTests()
        {  
            _requester = new Mock<IRequester>();
            _config = new MoneybirdConfig();
            _generalDocumentEndpoint = new GeneralDocumentEndpoint(_config, _requester.Object);
        }

        [Fact]
        public async void GetDocumentsAsync_ByAccessToken_Returns_ListOf_GeneralDocuments()
        {
            var expectedJson = await File.ReadAllTextAsync(GetDocumentsResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(expectedJson);
            
            var expectedResultList = JsonSerializer.Deserialize<List<GeneralDocument>>(expectedJson, _config.SerializerOptions);
            Assert.NotNull(expectedResultList);

            var actualResult = await _generalDocumentEndpoint.GetDocumentsAsync(AdministrationId, AccessToken);
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
        
        [Fact]
        public async void GetDocumentsByIdsAsync_ByAccessToken_Returns_ListOf_GeneralDocuments()
        {
            var expectedJson = await File.ReadAllTextAsync(GetDocumentsByIdsResponsePath);
            var options = new GeneralDocumentListOptions()
            {
                Ids = new List<string>()
                {
                    "346711547725219757"
                }
            };
            var serializedOptions = JsonSerializer.Serialize(options, _config.SerializerOptions);
            
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(expectedJson);
            
            var expectedResultList = JsonSerializer.Deserialize<List<GeneralDocument>>(expectedJson, _config.SerializerOptions);
            Assert.NotNull(expectedResultList);

            var actualResult = await _generalDocumentEndpoint.GetDocumentsByIdsAsync(AdministrationId, AccessToken, options);
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
        
        [Fact]
        public async void GetDocumentByIdAsync_ByAccessToken_Returns_Single_GeneralDocument()
        {
            var expectedJson = await File.ReadAllTextAsync(GetDocumentResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(expectedJson);
            
            var expectedResult = JsonSerializer.Deserialize<GeneralDocument>(expectedJson, _config.SerializerOptions);
            Assert.NotNull(expectedResult);

            var actualResult = await _generalDocumentEndpoint.GetDocumentByIdAsync(AdministrationId, GeneralDocumentId, AccessToken);
            Assert.NotNull(actualResult);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}