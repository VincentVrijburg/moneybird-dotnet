using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Entities.Identities;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Identities;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints
{
    public class IdentityEndpointTests : IdentityTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly MoneybirdConfig _config;
        private readonly IdentityEndpoint _identityEndpoint;

        private const string GetIdentitiesResponsePath = "./Responses/Endpoints/Identities/getIdentities.json";
        private const string GetIdentityResponsePath = "./Responses/Endpoints/Identities/getIdentity.json";
        private const string NewIdentityResponsePath = "./Responses/Endpoints/Identities/newIdentity.json";

        public IdentityEndpointTests()
        {  
            _requester = new Mock<IRequester>();
            _config = new MoneybirdConfig();
            _identityEndpoint = new IdentityEndpoint(_config, _requester.Object);
        }
        
        [Fact]
        public async Task GetIdentitiesAsync_ByAccessToken_Returns_ListOf_Identities()
        {
            var identityListJson = await File.ReadAllTextAsync(GetIdentitiesResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(identityListJson);
            
            var identityList = JsonSerializer.Deserialize<List<Identity>>(identityListJson, _config.SerializerOptions);
            Assert.NotNull(identityList);

            var actualIdentities = await _identityEndpoint.GetAsync(AdministrationId, AccessToken);
            Assert.NotNull(actualIdentities);

            var actualIdentityList = actualIdentities.ToList();
            Assert.Equal(identityList.Count, actualIdentityList.Count);
            foreach (var actualIdentity in actualIdentityList)
            {
                var identity = identityList.FirstOrDefault(a => a.Id == actualIdentity.Id);
                Assert.NotNull(identity);
                
                identity.Should().BeEquivalentTo(actualIdentity);
            }
        }
        
        [Fact]
        public async Task GetDefaultIdentityAsync_ByAccessToken_Returns_Single_Identity()
        {
            var identityJson = await File.ReadAllTextAsync(GetIdentityResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(identityJson);
            
            var identity = JsonSerializer.Deserialize<Identity>(identityJson, _config.SerializerOptions);
            Assert.NotNull(identity);

            var actualIdentity = await _identityEndpoint.GetDefaultAsync(AdministrationId, AccessToken);
            Assert.NotNull(actualIdentity);

            identity.Should().BeEquivalentTo(actualIdentity);
        }
        
        [Fact]
        public async Task GetIdentityByIdAsync_ByAccessToken_Returns_Single_Identity()
        {
            var identityJson = await File.ReadAllTextAsync(GetIdentityResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(identityJson);
            
            var identity = JsonSerializer.Deserialize<Identity>(identityJson, _config.SerializerOptions);
            Assert.NotNull(identity);

            var actualIdentity = await _identityEndpoint.GetByIdAsync(AdministrationId, IdentityId, AccessToken);
            Assert.NotNull(actualIdentity);

            identity.Should().BeEquivalentTo(actualIdentity);
        }
        
        [Fact]
        public async Task CreateIdentityAsync_ByAccessToken_Returns_NewIdentity()
        {
            var identityJson = await File.ReadAllTextAsync(NewIdentityResponsePath);
            var identityCreateOptions = new IdentityCreateOptions
            {
                Identity = new IdentityCreate
                {
                    CompanyName = "MoneyBird B.V.",
                    ZipCode = "7523MC",
                    Address1 = "Moutlaan 35",
                    Address2 = "",
                    City = "Enschede",
                    Country = "Netherlands",
                    Phone = "0612345678",
                    Email = "info@dev.null.moneybird.net",
                    TaxNumber = "NL817575546B01",
                    ChamberOfCommerce = "08155914",
                    BankAccountName = "Test account name",
                    BankAccountNumber = "NL13TEST0123456789",
                    BankAccountBic = "TESTNL2A",
                    CustomFieldsAttributes = new List<CustomFieldAttribute>
                    {
                        new ()
                        {
                            Id = "343816698630643114",
                            Value = "Custom identity field test value create"
                        }
                    }
                }
            };
            
            var serializedIdentityCreateOptions = JsonSerializer.Serialize(identityCreateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedIdentityCreateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(identityJson);
            
            var identity = JsonSerializer.Deserialize<Identity>(identityJson, _config.SerializerOptions);
            Assert.NotNull(identity);
            Assert.NotNull(identity.CustomFields.First().Name);

            var actualIdentity = await _identityEndpoint.CreateAsync(AdministrationId, identityCreateOptions, AccessToken);
            Assert.NotNull(actualIdentity);

            identity.Should().BeEquivalentTo(actualIdentity);
        }
        
        [Fact]
        public async Task UpdateIdentityAsync_ByAccessToken_Returns_UpdatedIdentity()
        {
            var identityJson = await File.ReadAllTextAsync(GetIdentityResponsePath);
            var identityUpdateOptions = new IdentityUpdateOptions
            {
                Identity = new IdentityUpdate
                {
                    CompanyName = "MoneyBird B.V.",
                    Address1 = "Moutlaan 35",
                    Address2 = "",
                    ZipCode = "7523MC",
                    City = "Enschede",
                    Country = "Netherlands",
                    Phone = "0612345678",
                    TaxNumber = "NL012345678B01",
                    ChamberOfCommerce = "58209344",
                    BankAccountName = "Test account name 2",
                    BankAccountNumber = "NL13TEST0123456789",
                    BankAccountBic = "TESTNL2A",
                    Email = "info@dev.null.moneybird.net",
                    CustomFieldsAttributes = new List<CustomFieldAttribute>
                    {
                        new ()
                        {
                            Id = "1",
                            Value = "Custom identity field test value update"
                        }
                    }
                }
            };
            
            var serializedIdentityUpdateOptions = JsonSerializer.Serialize(identityUpdateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedIdentityUpdateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(identityJson);
        
            var identity = JsonSerializer.Deserialize<Identity>(identityJson, _config.SerializerOptions);
            Assert.NotNull(identity);

            var actualIdentity = await _identityEndpoint.UpdateByIdAsync(AdministrationId, IdentityId, identityUpdateOptions, AccessToken);
            Assert.NotNull(actualIdentity);

            identity.Should().BeEquivalentTo(actualIdentity);
        }
        
        [Fact]
        public async Task UpdateDefaultIdentityAsync_ByAccessToken_Returns_UpdatedIdentity()
        {
            var identityJson = await File.ReadAllTextAsync(GetIdentityResponsePath);
            var identityUpdateOptions = new IdentityUpdateOptions
            {
                Identity = new IdentityUpdate
                {
                    CompanyName = "MoneyBird B.V.",
                    Address1 = "Moutlaan 35",
                    Address2 = "",
                    ZipCode = "7523MC",
                    City = "Enschede",
                    Country = "Netherlands",
                    Phone = "0612345678",
                    TaxNumber = "NL012345678B01",
                    ChamberOfCommerce = "58209344",
                    BankAccountName = "Test account name 2",
                    BankAccountNumber = "NL13TEST0123456789",
                    BankAccountBic = "TESTNL2A",
                    Email = "info@dev.null.moneybird.net",
                    CustomFieldsAttributes = new List<CustomFieldAttribute>
                    {
                        new ()
                        {
                            Id = "1",
                            Value = "Custom identity field test value update"
                        }
                    }
                }
            };
            
            var serializedIdentityUpdateOptions = JsonSerializer.Serialize(identityUpdateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedIdentityUpdateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(identityJson);
        
            var identity = JsonSerializer.Deserialize<Identity>(identityJson, _config.SerializerOptions);
            Assert.NotNull(identity);

            var actualIdentity = await _identityEndpoint.UpdateDefaultAsync(AdministrationId, identityUpdateOptions, AccessToken);
            Assert.NotNull(actualIdentity);

            identity.Should().BeEquivalentTo(actualIdentity);
        }

        [Fact]
        public async Task DeleteIdentityByIdAsync_ByAccessToken_Returns_True()
        {
            _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
            var actualIdentity = await _identityEndpoint.DeleteByIdAsync(AdministrationId, IdentityId, AccessToken);
            Assert.True(actualIdentity);
        }
    }
}
