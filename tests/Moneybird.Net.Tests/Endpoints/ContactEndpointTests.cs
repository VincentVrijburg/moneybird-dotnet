using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Contacts;
using Moneybird.Net.Endpoints.Contacts.Models;
using Moneybird.Net.Http;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints
{
    public class ContactEndpointTests : CommonTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly IContactEndpoint _contactEndpoint;

        private const string ContactResponsePath = "./Responses/Endpoints/Contacts/contactList.json";
        private const string ContactByIdsResponsePath = "./Responses/Endpoints/Contacts/contactListByIds.json";
        private const string SynchronizationContactResponsePath = "./Responses/Endpoints/Contacts/synchronizationContactList.json";

        public ContactEndpointTests()
        {  
            _requester = new Mock<IRequester>();
            _contactEndpoint = new ContactEndpoint(new MoneybirdConfig(), _requester.Object);
        }
        
        [Fact]
        public async void GetContactsAsync_ByAccessToken_Returns_ListOf_Contacts()
        {
            var contactListJson = await File.ReadAllTextAsync(ContactResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactListJson);
            
            var contactList = JsonSerializer.Deserialize<List<Contact>>(contactListJson);
            Assert.NotNull(contactList);

            var actualContacts = await _contactEndpoint.GetContactsAsync(AdministrationId, AccessToken);
            Assert.NotNull(actualContacts);

            var actualContactList = actualContacts.ToList();
            Assert.Equal(contactList.Count, actualContactList.Count);
            foreach (var actualContact in actualContactList)
            {
                var contact = contactList.FirstOrDefault(a => a.Id == actualContact.Id);
                Assert.NotNull(contact);
                
                contact.Should().BeEquivalentTo(actualContact);
            }
        }
        
        [Fact]
        public async void GetContactsByIdsAsync_ByAccessToken_Returns_ListOf_Contacts()
        {
            var contactListByIdsJson = await File.ReadAllTextAsync(ContactByIdsResponsePath);
            var contactListOptions = new ContactListOptions
            {
                Ids = new List<string>()
                {
                    "726609752430752165",
                    "622071342065956775"
                }
            };
            var serializedContactListOptions = JsonSerializer.Serialize(contactListOptions);
            
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactListOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactListByIdsJson);
            
            var contactListByIds = JsonSerializer.Deserialize<List<Contact>>(contactListByIdsJson);
            Assert.NotNull(contactListByIds);

            var actualContactsByIds = await _contactEndpoint.GetContactsByIdsAsync(AdministrationId, AccessToken, contactListOptions);
            Assert.NotNull(actualContactsByIds);

            var actualContactList = actualContactsByIds.ToList();
            Assert.Equal(contactListByIds.Count, actualContactList.Count);
            foreach (var actualContact in actualContactList)
            {
                var contact = contactListByIds.FirstOrDefault(a => a.Id == actualContact.Id);
                Assert.NotNull(contact);
                
                contact.Should().BeEquivalentTo(actualContact);
            }
        }
        
        [Fact]
        public async void GetSynchronizationContactsAsync_ByAccessToken_Returns_ListOf_SynchronizationContacts()
        {
            var synchronizationContactListJson = await File.ReadAllTextAsync(SynchronizationContactResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationContactListJson);
            
            var synchronizationContactList = JsonSerializer.Deserialize<List<SynchronizationContact>>(synchronizationContactListJson);
            Assert.NotNull(synchronizationContactList);

            var actualSynchronizationContacts = await _contactEndpoint.GetSynchronizationContactsAsync(AdministrationId, AccessToken);
            Assert.NotNull(actualSynchronizationContacts);

            var actualSynchronizationContactList = actualSynchronizationContacts.ToList();
            Assert.Equal(synchronizationContactList.Count, actualSynchronizationContactList.Count);
            foreach (var actualSynchronizationContact in actualSynchronizationContactList)
            {
                var contact = synchronizationContactList.FirstOrDefault(a => a.Id == actualSynchronizationContact.Id);
                Assert.NotNull(contact);
                
                contact.Should().BeEquivalentTo(actualSynchronizationContact);
            }
        }
    }
}