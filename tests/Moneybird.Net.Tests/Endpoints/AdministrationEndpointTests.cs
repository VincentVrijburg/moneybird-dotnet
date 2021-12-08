using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Administrations;
using Moneybird.Net.Endpoints.Administrations.Models;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints
{
    public class AdministrationEndpointTests : CommonTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly IAdministrationEndpoint _administrationEndpoint;

        private const string ResponsePath = "./Responses/Endpoints/Administration/administrationList.json";

        public AdministrationEndpointTests()
        {
            _requester = new Mock<IRequester>();
            _administrationEndpoint = new AdministrationEndpoint(new MoneybirdConfig(), _requester.Object);
        }

        [Fact]
        public async void GetAdministrationListAsync_ByAccessToken_Returns_AdministrationList()
        {
            var administrationListJson = await File.ReadAllTextAsync(ResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                            It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(administrationListJson);
            
            var administrationList = JsonSerializer.Deserialize<List<Administration>>(administrationListJson);
            Assert.NotNull(administrationList);

            var actualAdministrationList = await _administrationEndpoint.GetAdministrationsAsync(accessToken: AccessToken);
            Assert.NotNull(actualAdministrationList);
            
            Assert.Equal(administrationList.Count, actualAdministrationList.Count);
            foreach (var actualAdministration in actualAdministrationList)
            {
                var administration = administrationList.FirstOrDefault(a => a.Id == actualAdministration.Id);
                Assert.NotNull(administration);
                
                Assert.Equal(administration.Name, actualAdministration.Name);
                Assert.Equal(administration.Language, actualAdministration.Language);
                Assert.Equal(administration.Currency, actualAdministration.Currency);
                Assert.Equal(administration.Country, actualAdministration.Country);
                Assert.Equal(administration.TimeZone, actualAdministration.TimeZone);
            }
        }
    }
}