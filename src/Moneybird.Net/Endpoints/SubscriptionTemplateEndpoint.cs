using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.SubscriptionTemplates;
using Moneybird.Net.Extensions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.SubscriptionTemplates;

namespace Moneybird.Net.Endpoints;

public class SubscriptionTemplateEndpoint : ISubscriptionTemplateEndpoint
{
    private const string SubscriptionTemplatesUri = "/{0}/subscription_templates.json";
    private const string SalesLinkUri = "/{0}/subscription_templates/{1}/sales_link.json";

    private readonly MoneybirdConfig _config;
    private readonly IRequester _requester;

    public SubscriptionTemplateEndpoint(MoneybirdConfig config, IRequester requester)
    {
        _config = config;
        _requester = requester;
    }

    public async Task<IEnumerable<SubscriptionTemplate>> GetAsync(
        string administrationId,
        string accessToken,
        int page = 1,
        int perPage = 50)
    {
        var parameters = new List<string> { $"page={page}", $"per_page={perPage}" };
        var response = await _requester
            .CreateGetRequestAsync(_config.ApiUri, string.Format(SubscriptionTemplatesUri, administrationId), accessToken, parameters)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<IEnumerable<SubscriptionTemplate>>(response, _config.SerializerOptions);
    }

    public async Task<SubscriptionTemplateSalesLink> CreateSalesLinkAsync(
        string administrationId,
        string id,
        string accessToken,
        SubscriptionTemplateSalesLinkOptions options = null)
    {
        var response = await _requester
            .CreatePostRequestAsync(_config.ApiUri, string.Format(SalesLinkUri, administrationId, id), accessToken, string.Empty, options.GetQueryParameters())
            .ConfigureAwait(false);

        return new SubscriptionTemplateSalesLink
        {
            Url = JsonSerializer.Deserialize<string>(response, _config.SerializerOptions)
        };
    }
}
