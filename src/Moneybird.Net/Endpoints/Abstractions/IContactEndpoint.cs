using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Contacts;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Models.Contacts;
using Moneybird.Net.Models.Notes;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IContactEndpoint :
        IReadEndpoint<Contact>,
        IReadFilterEndpoint<Contact, ContactFilterOptions>,
        IGetEndpoint<Contact>,
        ICreateEndpoint<Contact, ContactCreateOptions>,
        IUpdateEndpoint<Contact, ContactUpdateOptions>,
        IDeleteEndpoint
    {
        Task<IEnumerable<SynchronizationContact>> GetSynchronizationContactsAsync(string administrationId, string accessToken);
        Task<IEnumerable<SynchronizationContact>> GetSynchronizationContactsAsync(string administrationId, string accessToken, ContactFilterOptions options);
        Task<IEnumerable<Contact>> GetContactsByIdsAsync(string administrationId, string accessToken, ContactListOptions options);
        Task<Contact> GetContactByCustomerIdAsync(string administrationId, string customerId, string accessToken);
        Task<Note> CreateContactNoteAsync(string administrationId, string contactId, NoteCreateOptions options, string accessToken);
        Task<bool> DeleteContactNoteByIdAsync(string administrationId, string contactId, string noteId, string accessToken);
        Task<ContactPerson> GetContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, string accessToken);
        Task<ContactPerson> CreateContactPersonAsync(string administrationId, string contactId, ContactPersonCreateOptions options, string accessToken);
        Task<ContactPerson> UpdateContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, ContactPersonUpdateOptions options, string accessToken);
        Task<bool> DeleteContactPersonByIdAsync(string administrationId, string contactId, string contactPersonId, string accessToken);
    }
}
