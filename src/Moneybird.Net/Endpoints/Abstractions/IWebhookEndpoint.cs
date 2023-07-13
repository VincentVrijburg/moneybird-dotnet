using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Endpoints.Webhooks.Models;
using Moneybird.Net.Entities.Webhooks;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IWebhookEndpoint :
        IReadEndpoint<Webhook>,
        ICreateEndpoint<Webhook, WebhookCreateOptions>,
        IDeleteEndpoint
    {
    }
}
