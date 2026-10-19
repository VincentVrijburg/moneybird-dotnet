using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.GeneralDocuments;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.GeneralDocuments;

namespace Moneybird.Net.Endpoints;

public class GeneralDocumentEndpoint : IGeneralDocumentEndpoint
{
    private const string GeneralDocumentsUri = "/{0}/documents/general_documents.json";
    private const string GeneralDocumentIdUri = "/{0}/documents/general_documents/{1}.json";

    private readonly MoneybirdConfig _config;
    private readonly IRequester _requester;

    public GeneralDocumentEndpoint(MoneybirdConfig config, IRequester requester)
    {
        _config = config;
        _requester = requester;
    }

    public async Task<IEnumerable<GeneralDocument>> GetAsync(
        string administrationId,
        string accessToken,
        int page = 1,
        int perPage = 50)
    {
        var parameters = new List<string> { $"page={page}", $"per_page={perPage}" };
        var response = await _requester
            .CreateGetRequestAsync(_config.ApiUri, string.Format(GeneralDocumentsUri, administrationId), accessToken, parameters)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<IEnumerable<GeneralDocument>>(response, _config.SerializerOptions);
    }

    public async Task<IEnumerable<GeneralDocument>> GetAsync(
        string administrationId,
        string accessToken,
        GeneralDocumentFilterOptions options,
        int page = 1,
        int perPage = 50)
    {
        var parameters = new List<string> { $"page={page}", $"per_page={perPage}" };

        var filterString = options.GetFilterString();
        if (!string.IsNullOrEmpty(filterString))
        {
            parameters.Add(filterString);
        }

        var response = await _requester
            .CreateGetRequestAsync(_config.ApiUri, string.Format(GeneralDocumentsUri, administrationId), accessToken, parameters)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<IEnumerable<GeneralDocument>>(response, _config.SerializerOptions);
    }

    public async Task<GeneralDocument> GetByIdAsync(string administrationId, string id, string accessToken)
    {
        var response = await _requester
            .CreateGetRequestAsync(_config.ApiUri, string.Format(GeneralDocumentIdUri, administrationId, id), accessToken)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<GeneralDocument>(response, _config.SerializerOptions);
    }

    public async Task<GeneralDocument> CreateAsync(
        string administrationId,
        GeneralDocumentCreateOptions options,
        string accessToken)
    {
        var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
        var response = await _requester
            .CreatePostRequestAsync(_config.ApiUri, string.Format(GeneralDocumentsUri, administrationId), accessToken, body)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<GeneralDocument>(response, _config.SerializerOptions);
    }

    public async Task<GeneralDocument> UpdateByIdAsync(
        string administrationId,
        string id,
        GeneralDocumentUpdateOptions options,
        string accessToken)
    {
        var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
        var response = await _requester
            .CreatePatchRequestAsync(_config.ApiUri, string.Format(GeneralDocumentIdUri, administrationId, id), accessToken, body)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<GeneralDocument>(response, _config.SerializerOptions);
    }

    public async Task<bool> DeleteByIdAsync(string administrationId, string id, string accessToken)
    {
        return await _requester
            .CreateDeleteRequestAsync(_config.ApiUri, string.Format(GeneralDocumentIdUri, administrationId, id), accessToken)
            .ConfigureAwait(false);
    }
}
