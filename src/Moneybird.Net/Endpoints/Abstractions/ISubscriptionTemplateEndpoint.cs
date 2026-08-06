using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.SubscriptionTemplates;
using Moneybird.Net.Models.SubscriptionTemplates;

namespace Moneybird.Net.Endpoints.Abstractions;

public interface ISubscriptionTemplateEndpoint : IReadEndpoint<SubscriptionTemplate>
{
    Task<SubscriptionTemplateSalesLink> CreateSalesLinkAsync(
        string administrationId,
        string id,
        string accessToken,
        SubscriptionTemplateSalesLinkOptions options = null);
}
