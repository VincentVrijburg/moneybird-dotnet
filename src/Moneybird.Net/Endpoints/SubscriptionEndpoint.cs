using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Entities.Subscriptions;
using Moneybird.Net.Http;
using Moneybird.Net.Models.Subscriptions;

namespace Moneybird.Net.Endpoints;

public class SubscriptionEndpoint : ISubscriptionEndpoint
{
    private const string SubscriptionsUri = "/{0}/subscriptions.json";
    private const string SubscriptionIdUri = "/{0}/subscriptions/{1}.json";
    private const string AdditionalChargesUri = "/{0}/subscriptions/{1}/additional_charges.json";
    private const string OneOffInvoiceUri = "/{0}/subscriptions/{1}/create_and_schedule_one_off_sales_invoice.json";

    private readonly MoneybirdConfig _config;
    private readonly IRequester _requester;

    public SubscriptionEndpoint(MoneybirdConfig config, IRequester requester)
    {
        _config = config;
        _requester = requester;
    }

    public async Task<IEnumerable<Subscription>> GetAsync(
        string administrationId,
        string accessToken,
        string contactId,
        int page = 1,
        int perPage = 50)
    {
        var parameters = new List<string> { $"contact_id={contactId}", $"page={page}", $"per_page={perPage}" };
        var response = await _requester
            .CreateGetRequestAsync(_config.ApiUri, string.Format(SubscriptionsUri, administrationId), accessToken, parameters)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<IEnumerable<Subscription>>(response, _config.SerializerOptions);
    }

    public async Task<Subscription> GetByIdAsync(string administrationId, string id, string accessToken)
    {
        var response = await _requester
            .CreateGetRequestAsync(_config.ApiUri, string.Format(SubscriptionIdUri, administrationId, id), accessToken)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<Subscription>(response, _config.SerializerOptions);
    }

    public async Task<Subscription> CreateAsync(string administrationId, SubscriptionCreateOptions options, string accessToken)
    {
        var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
        var response = await _requester
            .CreatePostRequestAsync(_config.ApiUri, string.Format(SubscriptionsUri, administrationId), accessToken, body)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<Subscription>(response, _config.SerializerOptions);
    }

    public async Task<Subscription> UpdateByIdAsync(
        string administrationId,
        string id,
        SubscriptionUpdateOptions options,
        string accessToken)
    {
        var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
        var response = await _requester
            .CreatePatchRequestAsync(_config.ApiUri, string.Format(SubscriptionIdUri, administrationId, id), accessToken, body)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<Subscription>(response, _config.SerializerOptions);
    }

    public async Task<Subscription> CancelAsync(
        string administrationId,
        string id,
        SubscriptionCancelOptions options,
        string accessToken)
    {
        var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
        var response = await _requester
            .CreateDeleteRequestAsync(_config.ApiUri, string.Format(SubscriptionIdUri, administrationId, id), accessToken, body)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<Subscription>(response, _config.SerializerOptions);
    }

    public async Task<SubscriptionAdditionalCharge> CreateAdditionalChargeAsync(
        string administrationId,
        string subscriptionId,
        SubscriptionAdditionalChargeCreate options,
        string accessToken)
    {
        var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
        var response = await _requester
            .CreatePostRequestAsync(_config.ApiUri, string.Format(AdditionalChargesUri, administrationId, subscriptionId), accessToken, body)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<SubscriptionAdditionalCharge>(response, _config.SerializerOptions);
    }

    public async Task<IEnumerable<SubscriptionAdditionalCharge>> GetAdditionalChargesAsync(
        string administrationId,
        string subscriptionId,
        string accessToken,
        bool includeBilled = false)
    {
        var parameters = new List<string> { $"include_billed={includeBilled.ToString().ToLowerInvariant()}" };
        var response = await _requester
            .CreateGetRequestAsync(_config.ApiUri, string.Format(AdditionalChargesUri, administrationId, subscriptionId), accessToken, parameters)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<IEnumerable<SubscriptionAdditionalCharge>>(response, _config.SerializerOptions);
    }

    public async Task<SalesInvoice> CreateAndScheduleOneOffSalesInvoiceAsync(
        string administrationId,
        string subscriptionId,
        SubscriptionOneOffSalesInvoiceCreateOptions options,
        string accessToken)
    {
        var body = JsonSerializer.Serialize(options, _config.SerializerOptions);
        var response = await _requester
            .CreatePostRequestAsync(_config.ApiUri, string.Format(OneOffInvoiceUri, administrationId, subscriptionId), accessToken, body)
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<SalesInvoice>(response, _config.SerializerOptions);
    }
}
