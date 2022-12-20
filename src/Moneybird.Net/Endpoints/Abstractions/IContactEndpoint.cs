using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Contacts.Models;
using Moneybird.Net.Entities.Common;
using Moneybird.Net.Entities.Contacts;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IContactEndpoint
    {
        Task<IEnumerable<Contact>> GetContactsAsync(string administrationId, string accessToken);
        Task<IEnumerable<Contact>> GetContactsAsync(string administrationId, string accessToken, ContactFilterOptions options);
        Task<IEnumerable<SynchronizationContact>> GetSynchronizationContactsAsync(string administrationId, string accessToken);
        Task<IEnumerable<SynchronizationContact>> GetSynchronizationContactsAsync(string administrationId, string accessToken, ContactFilterOptions options);
        Task<IEnumerable<Contact>> GetContactsByIdsAsync(string administrationId, string accessToken, ContactListOptions options);
        Task<Contact> GetContactByIdAsync(string administrationId, string contactId, string accessToken);
        Task<Contact> GetContactByCustomerIdAsync(string administrationId, string customerId, string accessToken);
        Task<Contact> CreateContactAsync(string administrationId, ContactCreateOptions item, string accessToken);
        Task<Contact> UpdateContactByIdAsync(string administrationId, string contactId, ContactUpdateOptions options, string accessToken);
        Task<bool> DeleteContactByIdAsync(string administrationId, string contactId, string accessToken);
        Task<Note> CreateContactNoteAsync(string administrationId, string contactId, ContactNoteCreateOptions options, string accessToken);
        Task<bool> DeleteContactNoteByIdAsync(string administrationId, string contactId, string noteId, string accessToken);
        Task<ContactPerson> GetContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, string accessToken);
        Task<ContactPerson> CreateContactPersonAsync(string administrationId, string contactId, ContactPersonCreateOptions options, string accessToken);
        Task<ContactPerson> UpdateContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, ContactPersonUpdateOptions options, string accessToken);
        Task<bool> DeleteContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, string accessToken);
    }
}