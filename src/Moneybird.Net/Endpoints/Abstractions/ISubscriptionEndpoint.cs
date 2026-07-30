using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Entities.Subscriptions;
using Moneybird.Net.Models.Subscriptions;

namespace Moneybird.Net.Endpoints.Abstractions;

public interface ISubscriptionEndpoint :
    IGetEndpoint<Subscription>,
    ICreateEndpoint<Subscription, SubscriptionCreateOptions>,
    IUpdateEndpoint<Subscription, SubscriptionUpdateOptions>
{
    Task<IEnumerable<Subscription>> GetAsync(
        string administrationId,
        string accessToken,
        string contactId,
        int page = 1,
        int perPage = 50);

    Task<Subscription> CancelAsync(
        string administrationId,
        string id,
        SubscriptionCancelOptions options,
        string accessToken);

    Task<SubscriptionAdditionalCharge> CreateAdditionalChargeAsync(
        string administrationId,
        string subscriptionId,
        SubscriptionAdditionalChargeCreate options,
        string accessToken);

    Task<IEnumerable<SubscriptionAdditionalCharge>> GetAdditionalChargesAsync(
        string administrationId,
        string subscriptionId,
        string accessToken,
        bool includeBilled = false);

    Task<SalesInvoice> CreateAndScheduleOneOffSalesInvoiceAsync(
        string administrationId,
        string subscriptionId,
        SubscriptionOneOffSalesInvoiceCreateOptions options,
        string accessToken);
}
