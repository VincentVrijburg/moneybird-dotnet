using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Moneybird.Net.Endpoints;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Entities.CustomFields;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moneybird.Net.Models.Contacts;
using Moneybird.Net.Models.Notes;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints
{
    public class ContactEndpointTests : ContactTestBase
    {
        private static Mock<IRequester> _requester;
        private readonly MoneybirdConfig _config;
        private readonly IContactEndpoint _contactEndpoint;

        private const string GetContactsResponsePath = "./Responses/Endpoints/Contacts/getContacts.json";
        private const string GetSynchronizationContactsResponsePath = "./Responses/Endpoints/Contacts/getSynchronizationContacts.json";
        private const string GetContactResponsePath = "./Responses/Endpoints/Contacts/getContact.json";
        private const string GetContactPersonResponsePath = "./Responses/Endpoints/Contacts/getContactPerson.json";
        private const string NewContactResponsePath = "./Responses/Endpoints/Contacts/newContact.json";
        private const string NewContactNoteResponsePath = "./Responses/Endpoints/Contacts/newContactNote.json";
        private const string NewContactPersonResponsePath = "./Responses/Endpoints/Contacts/newContactPerson.json";

        public ContactEndpointTests()
        {  
            _requester = new Mock<IRequester>();
            _config = new MoneybirdConfig();
            _contactEndpoint = new ContactEndpoint(_config, _requester.Object);
        }
        
        [Fact]
        public async Task GetContactsAsync_ByAccessToken_Returns_ListOf_Contacts()
        {
            var contactListJson = await File.ReadAllTextAsync(GetContactsResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactListJson);
            
            var contactList = JsonSerializer.Deserialize<List<Contact>>(contactListJson, _config.SerializerOptions);
            Assert.NotNull(contactList);

            var actualContacts = await _contactEndpoint.GetAsync(AdministrationId, AccessToken);
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
        public async Task GetContactsAsync_UsingFilterOptions_ByAccessToken_Returns_ListOf_Contacts()
        {
            var contactListJson = await File.ReadAllTextAsync(GetContactsResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactListJson);
            
            var contactList = JsonSerializer.Deserialize<List<Contact>>(contactListJson, _config.SerializerOptions);
            Assert.NotNull(contactList);

            var contactFilterOptions = new ContactFilterOptions
            {
                FirstName = "John",
                LastName = "Doe"
            };
            
            var actualContacts = await _contactEndpoint.GetAsync(AdministrationId, AccessToken, contactFilterOptions);
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
        public async Task GetContactsByIdsAsync_ByAccessToken_Returns_ListOf_Contacts()
        {
            var contactListByIdsJson = await File.ReadAllTextAsync(GetContactsResponsePath);
            var contactListOptions = new ContactListOptions
            {
                Ids = [
                    "726609752430752165",
                    "622071342065956775"
                ]
            };
            var serializedContactListOptions = JsonSerializer.Serialize(contactListOptions, _config.SerializerOptions);
            
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactListOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactListByIdsJson);
            
            var contactListByIds = JsonSerializer.Deserialize<List<Contact>>(contactListByIdsJson, _config.SerializerOptions);
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
        public async Task GetSynchronizationContactsAsync_ByAccessToken_Returns_ListOf_SynchronizationContacts()
        {
            var synchronizationContactListJson = await File.ReadAllTextAsync(GetSynchronizationContactsResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationContactListJson);
            
            var synchronizationContactList = JsonSerializer.Deserialize<List<SynchronizationContact>>(synchronizationContactListJson, _config.SerializerOptions);
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
        
        [Fact]
        public async Task GetSynchronizationContactsAsync_UsingFilterOptions_ByAccessToken_Returns_ListOf_SynchronizationContacts()
        {
            var synchronizationContactListJson = await File.ReadAllTextAsync(GetSynchronizationContactsResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationContactListJson);
            
            var synchronizationContactList = JsonSerializer.Deserialize<List<SynchronizationContact>>(synchronizationContactListJson, _config.SerializerOptions);
            Assert.NotNull(synchronizationContactList);

            var contactFilterOptions = new ContactFilterOptions
            {
                FirstName = "John",
                LastName = "Doe"
            };
            
            var actualSynchronizationContacts = 
                await _contactEndpoint.GetSynchronizationContactsAsync(AdministrationId, AccessToken, contactFilterOptions);
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
        
        [Fact]
        public async Task GetContactByIdAsync_ByAccessToken_Returns_Single_Contact()
        {
            var contactJson = await File.ReadAllTextAsync(GetContactResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactJson);
            
            var contact = JsonSerializer.Deserialize<Contact>(contactJson, _config.SerializerOptions);
            Assert.NotNull(contact);

            var actualContact = await _contactEndpoint.GetByIdAsync(AdministrationId, ContactId, AccessToken);
            Assert.NotNull(actualContact);

            contact.Should().BeEquivalentTo(actualContact);
        }
        
        [Fact]
        public async Task GetContactByCustomerIdAsync_ByAccessToken_Returns_Single_Contact()
        {
            var contactJson = await File.ReadAllTextAsync(GetContactResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactJson);
            
            var contact = JsonSerializer.Deserialize<Contact>(contactJson, _config.SerializerOptions);
            Assert.NotNull(contact);

            var actualContact = await _contactEndpoint.GetContactByCustomerIdAsync(AdministrationId, CustomerId, AccessToken);
            Assert.NotNull(actualContact);

            contact.Should().BeEquivalentTo(actualContact);
        }
        
        [Fact]
        public async Task CreateContactAsync_ByAccessToken_Returns_NewContact()
        {
            var contactJson = await File.ReadAllTextAsync(NewContactResponsePath);
            var contactCreateOptions = new ContactCreateOptions
            {
                Contact = new ContactCreateItem
                {
                    CompanyName = "Parkietje B.V.",
                    Firstname = "John",
                    Lastname = "Doe",
                    Address1 = "Moutlaan 35",
                    Address2 = "",
                    Zipcode = "7523MC",
                    City = "Enschede",
                    CountryCode = "NL",
                    Phone = "0612345678",
                    DeliveryMethod = DeliveryMethod.Email,
                    CustomerId = "1",
                    TaxNumber = "NL012345678B01",
                    ChamberOfCommerce = "58209344",
                    BankAccount = "Bank account",
                    EmailUbl = true,
                    SendInvoicesToAttention = "John Doe",
                    SendInvoicesToEmail = "johndoe@moneybird.nl",
                    SendEstimatesToAttention = "John Doe",
                    SendEstimatesToEmail = "johndoe@moneybird.nl",
                    SepaActive = false,
                    SepaIban = "NL13TEST0123456789",
                    SepaIbanAccountName = "Test account name",
                    SepaBic = "TESTNL2A",
                    SepaMandateId = "0123456789",
                    SepaMandateDate = "2021-12-27T15:10:44.770Z",
                    SepaSequenceType = SepaSequenceType.RCUR,
                    InvoiceWorkflowId = "292669868098208840",
                    EstimateWorkflowId = "292669868131763278",
                    SiIdentifier = "",
                    SiIdentifierTypeType = null,
                    CreateEvent = true,
                    DirectDebit = false,
                    CustomFieldsAttributes = new List<CustomFieldAttribute>
                    {
                        new ()
                        {
                            Id = "343816698630643114",
                            Value = "Custom field test value"
                        }
                    }
                }
            };
            
            var serializedContactCreateOptions = JsonSerializer.Serialize(contactCreateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactCreateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactJson);
        
            var contact = JsonSerializer.Deserialize<Contact>(contactJson, _config.SerializerOptions);
            Assert.NotNull(contact);
            Assert.NotNull(contact.CustomFields.First().Name);

            var actualContact = await _contactEndpoint.CreateAsync(AdministrationId, contactCreateOptions, AccessToken);
            Assert.NotNull(actualContact);

            contact.Should().BeEquivalentTo(actualContact);
        }
        
        [Fact]
        public async Task UpdateContactAsync_ByAccessToken_Returns_UpdatedContact()
        {
            var contactJson = await File.ReadAllTextAsync(GetContactResponsePath);
            var contactUpdateOptions = new ContactUpdateOptions
            {
                Contact = new ContactUpdateItem
                {
                    CompanyName = "Parkietje B.V.",
                    Firstname = "John",
                    Lastname = "Doe",
                    Address1 = "Moutlaan 35",
                    Address2 = "",
                    Zipcode = "7523MC",
                    City = "Enschede",
                    CountryCode = "NL",
                    Phone = "0612345678",
                    DeliveryMethod = DeliveryMethod.Email,
                    CustomerId = "1",
                    TaxNumber = "NL012345678B01",
                    ChamberOfCommerce = "58209344",
                    BankAccount = "Bank account",
                    EmailUbl = true,
                    SendInvoicesToAttention = "John Doe",
                    SendInvoicesToEmail = "johndoe@moneybird.nl",
                    SendEstimatesToAttention = "John Doe",
                    SendEstimatesToEmail = "johndoe@moneybird.nl",
                    SepaActive = false,
                    SepaIban = "NL13TEST0123456789",
                    SepaIbanAccountName = "Test accountname",
                    SepaBic = "TESTNL2A",
                    SepaMandateId = "0123456789",
                    SepaMandateDate = "2021-12-27T15:10:44.770Z",
                    SepaSequenceType = SepaSequenceType.RCUR,
                    InvoiceWorkflowId = "292669868098208840",
                    EstimateWorkflowId = "292669868131763278",
                    SiIdentifier = "",
                    SiIdentifierTypeType = null,
                    DirectDebit = false,
                    CustomFieldsAttributes = new List<CustomFieldAttribute>
                    {
                        new ()
                        {
                            Id = "1",
                            Value = "Custom contact field"
                        }
                    }
                }
            };
            
            var serializedContactUpdateOptions = JsonSerializer.Serialize(contactUpdateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactUpdateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactJson);
        
            var contact = JsonSerializer.Deserialize<Contact>(contactJson, _config.SerializerOptions);
            Assert.NotNull(contact);

            var actualContact = await _contactEndpoint.UpdateByIdAsync(AdministrationId, ContactId, contactUpdateOptions, AccessToken);
            Assert.NotNull(actualContact);

            contact.Should().BeEquivalentTo(actualContact);
        }

        [Fact]
        public async Task DeleteContactByIdAsync_ByAccessToken_Returns_True()
        {
            _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
            var actualContact = await _contactEndpoint.DeleteByIdAsync(AdministrationId, ContactId, AccessToken);
            Assert.True(actualContact);
        }
        
        [Fact]
        public async Task CreateContactNoteAsync_ByAccessToken_Returns_NewContactNote()
        {
            var contactNoteJson = await File.ReadAllTextAsync(NewContactNoteResponsePath);
            var contactNoteCreateOptions = new NoteCreateOptions
            {
                Note = new NoteCreateItem
                {
                    Note = "Text of the note",
                    Todo = true,
                    AssigneeId = "340087760888006110"
                }
            };
            
            var serializedContactNoteCreateOptions = JsonSerializer.Serialize(contactNoteCreateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactNoteCreateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactNoteJson);
        
            var contactNote = JsonSerializer.Deserialize<Note>(contactNoteJson, _config.SerializerOptions);
            Assert.NotNull(contactNote);

            var actualContactNote = await _contactEndpoint.CreateContactNoteAsync(AdministrationId, ContactId, contactNoteCreateOptions, AccessToken);
            Assert.NotNull(actualContactNote);

            contactNote.Should().BeEquivalentTo(actualContactNote);
        }
        
        [Fact]
        public async Task DeleteContactNoteByIdAsync_ByAccessToken_Returns_True()
        {
            _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
            var actualContact = await _contactEndpoint.DeleteContactNoteByIdAsync(AdministrationId, ContactId, NoteId, AccessToken);
            Assert.True(actualContact);
        }
        
        [Fact]
        public async Task GetContactPersonByIdAsync_ByAccessToken_Returns_Single_ContactPerson()
        {
            var contactPersonJson = await File.ReadAllTextAsync(GetContactPersonResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactPersonJson);
            
            var contactPerson = JsonSerializer.Deserialize<ContactPerson>(contactPersonJson, _config.SerializerOptions);
            Assert.NotNull(contactPerson);

            var actualContactPerson = await _contactEndpoint.GetContactPersonByIdAsync(AdministrationId, ContactId, ContactPersonId, AccessToken);
            Assert.NotNull(actualContactPerson);

            contactPerson.Should().BeEquivalentTo(actualContactPerson);
        }
        
        [Fact]
        public async Task CreateContactPersonAsync_ByAccessToken_Returns_NewContactPerson()
        {
            var contactPersonJson = await File.ReadAllTextAsync(NewContactPersonResponsePath);
            var contactPersonCreateOptions = new ContactPersonCreateOptions
            {
                ContactPerson = new ContactPersonCreateItem
                {
                    Firstname = "John",
                    Lastname = "Doe",
                    Phone = "06123455678",
                    Email = "example@moneybird.nl",
                    Department = "Administratie",
                    ContactId = ContactId
                }
            };
            
            var serializedContactPersonCreateOptions = JsonSerializer.Serialize(contactPersonCreateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactPersonCreateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactPersonJson);
        
            var contactPerson = JsonSerializer.Deserialize<ContactPerson>(contactPersonJson, _config.SerializerOptions);
            Assert.NotNull(contactPerson);

            var actualContactPerson = await _contactEndpoint.CreateContactPersonAsync(AdministrationId, ContactId, contactPersonCreateOptions, AccessToken);
            Assert.NotNull(actualContactPerson);

            contactPerson.Should().BeEquivalentTo(actualContactPerson);
        }
        
        [Fact]
        public async Task UpdateContactPersonAsync_ByAccessToken_Returns_NewContactPerson()
        {
            var contactPersonJson = await File.ReadAllTextAsync(NewContactPersonResponsePath);
            var contactPersonUpdateOptions = new ContactPersonUpdateOptions
            {
                ContactPerson = new ContactPersonUpdateItem
                {
                    Firstname = "John",
                    Lastname = "Doe",
                    Phone = "06123455678",
                    Email = "example@moneybird.nl",
                    Department = "Administratie",
                    ContactId = ContactId
                }
            };
            
            var serializedContactPersonUpdateOptions = JsonSerializer.Serialize(contactPersonUpdateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactPersonUpdateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactPersonJson);
        
            var contactPerson = JsonSerializer.Deserialize<ContactPerson>(contactPersonJson, _config.SerializerOptions);
            Assert.NotNull(contactPerson);

            var actualContactPerson = await _contactEndpoint.UpdateContactPersonByIdAsync(AdministrationId, ContactId, ContactPersonId, contactPersonUpdateOptions, AccessToken);
            Assert.NotNull(actualContactPerson);

            contactPerson.Should().BeEquivalentTo(actualContactPerson);
        }
        
        [Fact]
        public async Task DeleteContactPersonByIdAsync_ByAccessToken_Returns_True()
        {
            _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
            var actualContact = await _contactEndpoint.DeleteContactPersonByIdAsync(AdministrationId, ContactId, NoteId, AccessToken);
            Assert.True(actualContact);
        }
    }
}
