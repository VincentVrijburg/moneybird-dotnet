using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Contacts;
using Moneybird.Net.Endpoints.Contacts.Models;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Http;
using Moneybird.Net.Misc;
using Moq;
using Xunit;

namespace Moneybird.Net.Tests.Endpoints.Contacts
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
        public async void GetContactsAsync_ByAccessToken_Returns_ListOf_Contacts()
        {
            var contactListJson = await File.ReadAllTextAsync(GetContactsResponsePath);
            
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
        public async void GetContactsAsync_UsingFilterOptions_ByAccessToken_Returns_ListOf_Contacts()
        {
            var contactListJson = await File.ReadAllTextAsync(GetContactsResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactListJson);
            
            var contactList = JsonSerializer.Deserialize<List<Contact>>(contactListJson);
            Assert.NotNull(contactList);

            var contactFilterOptions = new ContactFilterOptions
            {
                FirstName = "John",
                LastName = "Doe"
            };
            
            var actualContacts = await _contactEndpoint.GetContactsAsync(AdministrationId, AccessToken, contactFilterOptions);
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
            var contactListByIdsJson = await File.ReadAllTextAsync(GetContactsResponsePath);
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
            var synchronizationContactListJson = await File.ReadAllTextAsync(GetSynchronizationContactsResponsePath);
            
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
        
        [Fact]
        public async void GetSynchronizationContactsAsync_UsingFilterOptions_ByAccessToken_Returns_ListOf_SynchronizationContacts()
        {
            var synchronizationContactListJson = await File.ReadAllTextAsync(GetSynchronizationContactsResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(synchronizationContactListJson);
            
            var synchronizationContactList = JsonSerializer.Deserialize<List<SynchronizationContact>>(synchronizationContactListJson);
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
        public async void GetContactByIdAsync_ByAccessToken_Returns_Single_Contact()
        {
            var contactJson = await File.ReadAllTextAsync(GetContactResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactJson);
            
            var contact = JsonSerializer.Deserialize<Contact>(contactJson);
            Assert.NotNull(contact);

            var actualContact = await _contactEndpoint.GetContactByIdAsync(AdministrationId, ContactId, AccessToken);
            Assert.NotNull(actualContact);

            contact.Should().BeEquivalentTo(actualContact);
        }
        
        [Fact]
        public async void GetContactByCustomerIdAsync_ByAccessToken_Returns_Single_Contact()
        {
            var contactJson = await File.ReadAllTextAsync(GetContactResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactJson);
            
            var contact = JsonSerializer.Deserialize<Contact>(contactJson);
            Assert.NotNull(contact);

            var actualContact = await _contactEndpoint.GetContactByCustomerIdAsync(AdministrationId, CustomerId, AccessToken);
            Assert.NotNull(actualContact);

            contact.Should().BeEquivalentTo(actualContact);
        }
        
        [Fact]
        public async void CreateContactAsync_ByAccessToken_Returns_NewContact()
        {
            var contactJson = await File.ReadAllTextAsync(NewContactResponsePath);
            var contactCreateOptions = new ContactCreateOptions
            {
                Contact = new ContactCreateItem
                {
                    CompanyName = "MoneyBird B.V.",
                    Firstname = "John",
                    Lastname = "Doe",
                    Address1 = "Moutlaan 35",
                    Address2 = "",
                    ZipCode = "7523MC",
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
                    CustomFieldsAttributes = null
                }
            };
            
            var serializedContactCreateOptions = JsonSerializer.Serialize(contactCreateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactCreateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactJson);
        
            var contact = JsonSerializer.Deserialize<Contact>(contactJson);
            Assert.NotNull(contact);

            var actualContact = await _contactEndpoint.CreateContactAsync(AdministrationId, contactCreateOptions, AccessToken);
            Assert.NotNull(actualContact);

            contact.Should().BeEquivalentTo(actualContact);
        }
        
        [Fact]
        public async void UpdateContactAsync_ByAccessToken_Returns_NewContact()
        {
            var contactJson = await File.ReadAllTextAsync(GetContactResponsePath);
            var contactUpdateOptions = new ContactUpdateOptions
            {
                Contact = new ContactUpdateItem
                {
                    CompanyName = "MoneyBird B.V.",
                    Firstname = "John",
                    Lastname = "Doe",
                    Address1 = "Moutlaan 35",
                    Address2 = "",
                    ZipCode = "7523MC",
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
                    CustomFieldsAttributes = null
                }
            };
            
            var serializedContactUpdateOptions = JsonSerializer.Serialize(contactUpdateOptions, _config.SerializerOptions);
        
            _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactUpdateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactJson);
        
            var contact = JsonSerializer.Deserialize<Contact>(contactJson);
            Assert.NotNull(contact);

            var actualContact = await _contactEndpoint.UpdateContactByIdAsync(AdministrationId, ContactId, contactUpdateOptions, AccessToken);
            Assert.NotNull(actualContact);

            contact.Should().BeEquivalentTo(actualContact);
        }

        [Fact]
        public async void DeleteContactByIdAsync_ByAccessToken_Returns_True()
        {
            _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
            var actualContact = await _contactEndpoint.DeleteContactByIdAsync(AdministrationId, ContactId, AccessToken);
            Assert.True(actualContact);
        }
        
        [Fact]
        public async void CreateContactNoteAsync_ByAccessToken_Returns_NewContactNote()
        {
            var contactNoteJson = await File.ReadAllTextAsync(NewContactNoteResponsePath);
            var contactNoteCreateOptions = new ContactNoteCreateOptions
            {
                Note = new ContactNoteCreateItem
                {
                    Note = "Text of the note",
                    Todo = true,
                    AssigneeId = "340087760888006110"
                }
            };
            
            var serializedContactNoteCreateOptions = JsonSerializer.Serialize(contactNoteCreateOptions);
        
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactNoteCreateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactNoteJson);
        
            var contactNote = JsonSerializer.Deserialize<ContactNote>(contactNoteJson);
            Assert.NotNull(contactNote);

            var actualContactNote = await _contactEndpoint.CreateContactNoteAsync(AdministrationId, ContactId, contactNoteCreateOptions, AccessToken);
            Assert.NotNull(actualContactNote);

            contactNote.Should().BeEquivalentTo(actualContactNote);
        }
        
        [Fact]
        public async void DeleteContactNoteByIdAsync_ByAccessToken_Returns_True()
        {
            _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
            var actualContact = await _contactEndpoint.DeleteContactNoteByIdAsync(AdministrationId, ContactId, NoteId, AccessToken);
            Assert.True(actualContact);
        }
        
        [Fact]
        public async void GetContactPersonByIdAsync_ByAccessToken_Returns_Single_ContactPerson()
        {
            var contactPersonJson = await File.ReadAllTextAsync(GetContactPersonResponsePath);
            
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(contactPersonJson);
            
            var contactPerson = JsonSerializer.Deserialize<ContactPerson>(contactPersonJson);
            Assert.NotNull(contactPerson);

            var actualContactPerson = await _contactEndpoint.GetContactPersonByIdAsync(AdministrationId, ContactId, ContactPersonId, AccessToken);
            Assert.NotNull(actualContactPerson);

            contactPerson.Should().BeEquivalentTo(actualContactPerson);
        }
        
        [Fact]
        public async void CreateContactPersonAsync_ByAccessToken_Returns_NewContactPerson()
        {
            var contactPersonJson = await File.ReadAllTextAsync(NewContactPersonResponsePath);
            var contactPersonCreateOptions = new ContactPersonCreateOptions()
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
            
            var serializedContactPersonCreateOptions = JsonSerializer.Serialize(contactPersonCreateOptions);
        
            _requester.Setup(moq => moq.CreatePostRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactPersonCreateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactPersonJson);
        
            var contactPerson = JsonSerializer.Deserialize<ContactPerson>(contactPersonJson);
            Assert.NotNull(contactPerson);

            var actualContactPerson = await _contactEndpoint.CreateContactPersonAsync(AdministrationId, ContactId, contactPersonCreateOptions, AccessToken);
            Assert.NotNull(actualContactPerson);

            contactPerson.Should().BeEquivalentTo(actualContactPerson);
        }
        
        [Fact]
        public async void UpdateContactPersonAsync_ByAccessToken_Returns_NewContactPerson()
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
            
            var serializedContactPersonUpdateOptions = JsonSerializer.Serialize(contactPersonUpdateOptions);
        
            _requester.Setup(moq => moq.CreatePatchRequestAsync(It.IsAny<string>(), It.IsAny<string>(), 
                    It.IsAny<string>(), It.Is<string>(s => s.Equals(serializedContactPersonUpdateOptions)), It.IsAny<List<string>>()))
                .ReturnsAsync(contactPersonJson);
        
            var contactPerson = JsonSerializer.Deserialize<ContactPerson>(contactPersonJson);
            Assert.NotNull(contactPerson);

            var actualContactPerson = await _contactEndpoint.UpdateContactPersonByIdAsync(AdministrationId, ContactId, ContactPersonId, contactPersonUpdateOptions, AccessToken);
            Assert.NotNull(actualContactPerson);

            contactPerson.Should().BeEquivalentTo(actualContactPerson);
        }
        
        [Fact]
        public async void DeleteContactPersonByIdAsync_ByAccessToken_Returns_True()
        {
            _requester.Setup(moq => moq.CreateDeleteRequestAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(true);
            
            var actualContact = await _contactEndpoint.DeleteContactPersonByIdAsync(AdministrationId, ContactId, NoteId, AccessToken);
            Assert.True(actualContact);
        }
    }
}