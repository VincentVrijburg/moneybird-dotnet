using System.Text.Json;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Entities.CustomerContactPortals;
using Moneybird.Net.Http;

namespace Moneybird.Net.Endpoints
{
    public class CustomerContactPortalEndpoint : ICustomerContactPortalEndpoint
    {
        private const string CustomerContactPortalUri = "/{0}/customer_contact_portal/{1}.json";
        private const string CustomerContactPortalInvoicesUri = "/{0}/customer_contact_portal/{1}/invoices.json";
        private const string CustomerContactPortalSubscriptionsUri = "/{0}/customer_contact_portal/{1}/subscriptions/{2}.json";

        private readonly MoneybirdConfig _config;
        private readonly IRequester _requester;

        public CustomerContactPortalEndpoint(MoneybirdConfig config, IRequester requester)
        {
            _requester = requester;
            _config = config;
        }

        public async Task<CustomerContactPortalLink> GetTemporaryPortalLinkAsync(string administrationId, string contactId, string accessToken)
        {
            var relativeUrl = string.Format(CustomerContactPortalUri, administrationId, contactId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return DeserializeCustomerContactPortalLink(responseJson);
        }

        public async Task<CustomerContactPortalLink> GetTemporaryInvoicesLinkAsync(string administrationId, string contactId, string accessToken)
        {
            var relativeUrl = string.Format(CustomerContactPortalInvoicesUri, administrationId, contactId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return DeserializeCustomerContactPortalLink(responseJson);
        }

        public async Task<CustomerContactPortalLink> GetTemporarySubscriptionLinkAsync(string administrationId, string contactId, string subscriptionId, string accessToken)
        {
            var relativeUrl = string.Format(CustomerContactPortalSubscriptionsUri, administrationId, contactId, subscriptionId);
            var responseJson = await _requester
                .CreateGetRequestAsync(_config.ApiUri, relativeUrl, accessToken)
                .ConfigureAwait(false);

            return DeserializeCustomerContactPortalLink(responseJson);
        }

        private CustomerContactPortalLink DeserializeCustomerContactPortalLink(string responseJson)
        {
            var temporaryLink = JsonSerializer.Deserialize<string>(responseJson, _config.SerializerOptions);

            return new CustomerContactPortalLink
            {
                Url = temporaryLink
            };
        }
    }
}
