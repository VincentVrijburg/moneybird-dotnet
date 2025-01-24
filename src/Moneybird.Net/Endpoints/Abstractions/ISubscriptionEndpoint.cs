using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Subscriptions;
using Moneybird.Net.Models.Subscriptions;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ISubscriptionEndpoint :
        IReadEndpoint<Subscription>,
        IGetEndpoint<Subscription>,
        ICreateEndpoint<Subscription, SubscriptionCreateOptions>,
        IUpdateEndpoint<Subscription, SubscriptionUpdateOptions>,
        IDeleteEndpoint
    {
        Task<SubscriptionAdditionalCharge> CreateAdditionalChargesAsync(string administrationId, SubscriptionAdditionalChargeCreateOptions options, string accessToken);
        Task<IEnumerable<SubscriptionAdditionalCharge>> GetAdditionalChargesAsync(string administrationId, string subscriptionId, string accessToken, bool includeBilled = false);
    }
}