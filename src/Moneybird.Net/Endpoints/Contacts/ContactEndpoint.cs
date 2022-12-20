using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Contacts.Models;
using Moneybird.Net.Entities.Common;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints.Contacts
{
    public class ContactEndpoint : IContactEndpoint
    {
        private const string ContactsUri = "/{0}/contacts.json";
        private const string ContactsFilterUri = "/{0}/contacts/filter.json";
        private const string ContactsSynchronizationUri = "/{0}/contacts/synchronization.json";
        private const string ContactsIdUri = "/{0}/contacts/{1}.json";
        private const string ContactsCustomerIdUri = "/{0}/contacts/customer_id/{1}.json";
        private const string ContactsIdNotesUri = "/{0}/contacts/{1}/notes.json";
        private const string ContactsIdNotesIdUri = "/{0}/contacts/{1}/notes/{2}.json";
        private const string ContactsIdPeopleUri = "/{0}/contacts/{1}/contact_people.json";
        private const string ContactsIdPeopleIdUri = "/{0}/contacts/{1}/contact_people/{2}.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public ContactEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<Contact>> GetContactsAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(ContactsUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Contact>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(string administrationId, string accessToken, ContactFilterOptions options)
        {
            List<string> paramValues = null;
            
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues = new List<string> { $"filter={filterString}" };
            }
            
            var relativeUrl = string.Format(ContactsFilterUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Contact>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<SynchronizationContact>> GetSynchronizationContactsAsync(string administrationId, string accessToken)
        {
            var relativeUrl = string.Format(ContactsSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SynchronizationContact>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<SynchronizationContact>> GetSynchronizationContactsAsync(string administrationId, string accessToken, ContactFilterOptions options)
        {
            List<string> paramValues = null;
            
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues = new List<string> { $"filter={filterString}" };
            }
            
            var relativeUrl = string.Format(ContactsSynchronizationUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<SynchronizationContact>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<Contact>> GetContactsByIdsAsync(string administrationId, string accessToken, ContactListOptions options)
        {
            var relativeUrl = string.Format(ContactsSynchronizationUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<Contact>>(responseJson, _config.SerializerOptions);
        }

        public async Task<Contact> GetContactByIdAsync(string administrationId, string contactId, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdUri, administrationId, contactId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Contact>(responseJson, _config.SerializerOptions);
        }

        public async Task<Contact> GetContactByCustomerIdAsync(string administrationId, string customerId, string accessToken)
        {
            var relativeUrl = string.Format(ContactsCustomerIdUri, administrationId, customerId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Contact>(responseJson, _config.SerializerOptions);
        }

        public async Task<Contact> CreateContactAsync(string administrationId, ContactCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ContactsUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Contact>(responseJson, _config.SerializerOptions);
        }

        public async Task<Contact> UpdateContactByIdAsync(string administrationId, string contactId, ContactUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdUri, administrationId, contactId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Contact>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteContactByIdAsync(string administrationId, string contactId, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdUri, administrationId, contactId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<Note> CreateContactNoteAsync(string administrationId, string contactId, ContactNoteCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdNotesUri, administrationId, contactId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Note>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteContactNoteByIdAsync(string administrationId, string contactId, string noteId, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdNotesIdUri, administrationId, contactId, noteId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<ContactPerson> GetContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdPeopleIdUri, administrationId, contactId, contactPersonId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<ContactPerson>(responseJson, _config.SerializerOptions);
        }

        public async Task<ContactPerson> CreateContactPersonAsync(string administrationId, string contactId, ContactPersonCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdPeopleUri, administrationId, contactId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<ContactPerson>(responseJson, _config.SerializerOptions);
        }

        public async Task<ContactPerson> UpdateContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, ContactPersonUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdPeopleIdUri, administrationId, contactId, contactPersonId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<ContactPerson>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, string accessToken)
        {
            var relativeUrl = string.Format(ContactsIdPeopleIdUri, administrationId, contactId, contactPersonId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}