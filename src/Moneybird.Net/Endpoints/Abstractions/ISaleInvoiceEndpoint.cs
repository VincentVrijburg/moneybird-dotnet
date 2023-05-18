using System.Threading.Tasks;
using Moneybird.Net.Entities.SaleInvoices;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ISaleInvoiceEndpoint
    {
        /// <summary>
        /// Create a new sale invoice.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="options">The sale invoice to create.</param>
        /// <param name="accessToken">The access token.</param>
        Task<SaleInvoice> CreateSaleInvoice(
            string administrationId,
            SaleInvoiceCreateOptions options,
            string accessToken);
    }
}
