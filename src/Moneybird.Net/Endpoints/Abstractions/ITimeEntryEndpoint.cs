using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.TimeEntries;
using Moneybird.Net.Models.Notes;
using Moneybird.Net.Models.TimeEntries;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ITimeEntryEndpoint :
        IReadEndpoint<TimeEntry>,
        IReadFilterEndpoint<TimeEntry, TimeEntryFilterOptions>,
        IGetEndpoint<TimeEntry>,
        ICreateEndpoint<TimeEntry, TimeEntryCreateOptions>,
        IUpdateEndpoint<TimeEntry, TimeEntryUpdateOptions>,
        IDeleteEndpoint
    {
        Task<Note> CreateTimeEntryNoteAsync(string administrationId, string timeEntryId, NoteCreateOptions options, string accessToken);
        Task<bool> DeleteTimeEntryNoteByIdAsync(string administrationId, string timeEntryId, string noteId, string accessToken);
    }
}