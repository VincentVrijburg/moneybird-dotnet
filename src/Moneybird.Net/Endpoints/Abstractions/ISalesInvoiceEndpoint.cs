using System.Threading.Tasks;
using Moneybird.Net.Endpoints.SalesInvoices.Models;
using Moneybird.Net.Entities.SalesInvoices;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ISalesInvoiceEndpoint
    {
        /// <summary>
        /// Create a new sale invoice.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="options">The sale invoice to create.</param>
        /// <param name="accessToken">The access token.</param>
        Task<SalesInvoice> CreateSaleInvoiceAsync(
            string administrationId,
            SalesInvoiceCreateOptions options,
            string accessToken);
    }
}
