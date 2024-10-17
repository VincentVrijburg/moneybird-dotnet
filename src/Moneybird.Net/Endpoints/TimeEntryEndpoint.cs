using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.TimeEntries;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Notes;
using Moneybird.Net.Models.TimeEntries;

namespace Moneybird.Net.Endpoints
{
    public class TimeEntryEndpoint : ITimeEntryEndpoint
    {
        private const string TimeEntriesUri = "/{0}/time_entries.json";
        private const string TimeEntriesIdUri = "/{0}/time_entries/{1}.json";
        private const string TimeEntriesIdNotesUri = "/{0}/time_entries/{1}/notes.json";
        private const string TimeEntriesIdNotesIdUri = "/{0}/time_entries/{1}/notes/{2}.json";
        
        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;
        
        public TimeEntryEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }
        
        public async Task<IEnumerable<TimeEntry>> GetAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
            var relativeUrl = string.Format(TimeEntriesUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<TimeEntry>>(responseJson, _config.SerializerOptions);
        }

        public async Task<IEnumerable<TimeEntry>> GetAsync(
            string administrationId,
            string accessToken,
            TimeEntryFilterOptions options,
            int page = 1,
            int perPage = 50)
        {
            var paramValues = new List<string> { $"page={page}", $"per_page={perPage}" };
                        
            var filterString = options.GetFilterString();
            if (!string.IsNullOrEmpty(filterString))
            {
                paramValues.Add($"filter={filterString}");
            }
            
            var relativeUrl = string.Format(TimeEntriesUri, administrationId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken, paramValues)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<IEnumerable<TimeEntry>>(responseJson, _config.SerializerOptions);
        }
        
        public async Task<TimeEntry> GetByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(TimeEntriesIdUri, administrationId, id);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<TimeEntry>(responseJson, _config.SerializerOptions);
        }

        public async Task<TimeEntry> CreateAsync(string administrationId, TimeEntryCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(TimeEntriesUri, administrationId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<TimeEntry>(responseJson, _config.SerializerOptions);
        }

        public async Task<TimeEntry> UpdateByIdAsync(string administrationId, string id, TimeEntryUpdateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(TimeEntriesUri, administrationId, id);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePatchRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<TimeEntry>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteByIdAsync(string administrationId, string id, string accessToken)
        {
            var relativeUrl = string.Format(TimeEntriesUri, administrationId, id);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }

        public async Task<Note> CreateTimeEntryNoteAsync(string administrationId, string timeEntryId, NoteCreateOptions options, string accessToken)
        {
            var relativeUrl = string.Format(TimeEntriesIdNotesUri, administrationId, timeEntryId);
            var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
            var responseJson = await _requester
                .CreatePostRequestAsync(_config.ApiUri, relativeUrl, accessToken, body)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Note>(responseJson, _config.SerializerOptions);
        }

        public async Task<bool> DeleteTimeEntryNoteByIdAsync(string administrationId, string timeEntryId, string noteId, string accessToken)
        {
            var relativeUrl = string.Format(TimeEntriesIdNotesIdUri, administrationId, timeEntryId, noteId);
            var response = await _requester
                .CreateDeleteRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return response;
        }
    }
}