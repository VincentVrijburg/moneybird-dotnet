using System.Threading.Tasks;
using Moneybird.Net.Entities.Payments;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IPaymentEndpoint
    {
        /// <summary>
        /// Retrieve a payment by id within an administration.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="paymentId">The payment id.</param>
        /// <returns>Information about a single payment by id.</returns>
        Task<Payment> GetPaymentByIdAsync(string administrationId, string paymentId, string accessToken);
    }
}