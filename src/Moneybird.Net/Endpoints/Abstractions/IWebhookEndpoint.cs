using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Webhooks;
using Moneybird.Net.Models.Webhooks;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IWebhookEndpoint :
        IReadEndpoint<Webhook>,
        ICreateEndpoint<Webhook, WebhookCreateOptions>,
        IDeleteEndpoint
    {
    }
}
