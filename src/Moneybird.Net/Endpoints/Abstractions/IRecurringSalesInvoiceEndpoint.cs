using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.RecurringSalesInvoices;
using Moneybird.Net.Models.Notes;
using Moneybird.Net.Models.RecurringSalesInvoices;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IRecurringSalesInvoiceEndpoint :
        IReadEndpoint<RecurringSalesInvoice>,
        IReadFilterEndpoint<RecurringSalesInvoice, RecurringSalesInvoiceFilterOptions>,
        IGetEndpoint<RecurringSalesInvoice>,
        ICreateEndpoint<RecurringSalesInvoice, RecurringSalesInvoiceCreateOptions>,
        IUpdateEndpoint<RecurringSalesInvoice, RecurringSalesInvoiceUpdateOptions>,
        IDeleteEndpoint
    {
        Task<IEnumerable<SynchronizationRecurringSalesInvoice>> GetSynchronizationRecurringSalesInvoicesAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50);

        Task<IEnumerable<SynchronizationRecurringSalesInvoice>> GetSynchronizationRecurringSalesInvoicesAsync(
            string administrationId,
            string accessToken,
            RecurringSalesInvoiceFilterOptions options,
            int page = 1,
            int perPage = 50);

        Task<IEnumerable<RecurringSalesInvoice>> GetRecurringSalesInvoicesByIdsAsync(
            string administrationId,
            string accessToken,
            RecurringSalesInvoiceListOptions options);
        
        Task<Note> CreateRecurringSalesInvoiceNoteAsync(
            string administrationId,
            string recurringSalesInvoiceId,
            NoteCreateOptions options,
            string accessToken);
        
        Task<bool> DeleteRecurringSalesInvoiceNoteByIdAsync(
            string administrationId,
            string recurringSalesInvoiceId,
            string noteId,
            string accessToken);
    }
}
