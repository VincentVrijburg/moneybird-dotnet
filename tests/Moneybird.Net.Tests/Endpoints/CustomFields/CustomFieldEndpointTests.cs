using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.CustomFields;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.CustomFields
{
    public class CustomFieldEndpointTest : CommonTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly MoneybirdConfig _config;
        private readonly ICustomFieldEndpoint _customFieldEndpoint;

        private const string ResponsePath = "./Responses/Endpoints/CustomFields/getCustomFields.json";

        public CustomFieldEndpointTest()
        {  
            _requester = new Mock<IRequester>();
            _config = new MoneybirdConfig();
            _customFieldEndpoint = new CustomFieldEndpoint(_config, _requester.Object);
        }
        
        [Fact]
        public async void GetCustomFieldsAsync_ByAccessToken_Returns_CustomFieldList()
        {
            var customFieldListJson = await File.ReadAllTextAsync(ResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(customFieldListJson);
            
            var customFieldList = JsonSerializer.Deserialize<List<CustomField>>(customFieldListJson, _config.SerializerOptions);
            Assert.NotNull(customFieldList);

            var actualCustomFieldList = await _customFieldEndpoint.GetAsync(AdministrationId, AccessToken);
            Assert.NotNull(actualCustomFieldList);

            var actualCustomFields = actualCustomFieldList.ToList();
            Assert.Equal(customFieldList.Count, actualCustomFields.Count);
            foreach (var actualCustomField in actualCustomFields)
            {
                var customField = customFieldList.FirstOrDefault(a => a.Id == actualCustomField.Id);
                Assert.NotNull(customField);

                customField.Should().BeEquivalentTo(actualCustomField);
            }
        }
    }
}
