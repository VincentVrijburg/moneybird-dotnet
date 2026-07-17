using System.Threading.Tasks;
using Moneybird.Net.Entities.CustomerContactPortals;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ICustomerContactPortalEndpoint
    {
        /// <summary>
        /// Get a temporary link to the customer contact portal.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="contactId">The contact id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A temporary link to the customer contact portal.</returns>
        Task<CustomerContactPortalLink> GetTemporaryPortalLinkAsync(string administrationId, string contactId, string accessToken);

        /// <summary>
        /// Get a temporary link to the invoices page in the customer contact portal.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="contactId">The contact id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A temporary link to the invoices page.</returns>
        Task<CustomerContactPortalLink> GetTemporaryInvoicesLinkAsync(string administrationId, string contactId, string accessToken);

        /// <summary>
        /// Get a temporary link to a subscription page in the customer contact portal.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="contactId">The contact id.</param>
        /// <param name="subscriptionId">The subscription id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A temporary link to the subscription page.</returns>
        Task<CustomerContactPortalLink> GetTemporarySubscriptionLinkAsync(string administrationId, string contactId, string subscriptionId, string accessToken);
    }
}
