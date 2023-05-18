using System.IO;
using System.Threading.Tasks;
using Moneybird.Net.Entities.ExternalSaleInvoices;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IExternalSaleInvoiceEndpoint
    {
        /// <summary>
        /// Create a new external sale invoice.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="options">The external sale invoice to create.</param>
        /// <param name="accessToken">The access token.</param>
        Task<ExternalSaleInvoice> CreateSaleInvoice(
            string administrationId,
            ExternalSaleInvoiceCreateOptions options,
            string accessToken);

        /// <summary>
        /// Add an attachment to an external sale invoice.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="id">The external sale invoice id.</param>
        /// <param name="body">The file to attach.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="fileName">The file name. Defaults to "invoice.pdf".</param>
        Task AddAttachment(string administrationId,
            string id,
            Stream body,
            string accessToken,
            string fileName = "invoice.pdf");
    }
}
