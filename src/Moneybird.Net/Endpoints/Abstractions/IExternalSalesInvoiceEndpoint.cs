using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.ExternalSalesInvoices.Models;
using Moneybird.Net.Entities.ExternalSalesInvoices;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IExternalSalesInvoiceEndpoint
    {
        /// <summary>
        /// Get list of all the external sales invoices.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns></returns>
        Task<List<ExternalSalesInvoice>> GetSalesInvoicesAsync(string administrationId, string accessToken);
        
        /// <summary>
        /// Get list of all the external sales invoices with filter options.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="options">The filter options.</param>
        /// <returns></returns>
        Task<List<ExternalSalesInvoice>> GetSalesInvoicesAsync(string administrationId, string accessToken, ExternalSalesInvoiceFilterOptions options);
        
        /// <summary>
        /// Get an external sales invoice by id and access token.
        /// </summary>
        /// <param name="administrationId"></param>
        /// <param name="salesInvoiceId"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<ExternalSalesInvoice> GetSalesInvoiceByIdAsync(string administrationId, string salesInvoiceId, string accessToken);
        
        /// <summary>
        /// Create a new external sale invoice.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="options">The external sale invoice to create.</param>
        /// <param name="accessToken">The access token.</param>
        Task<ExternalSalesInvoice> CreateSalesInvoiceAsync(string administrationId, ExternalSalesInvoiceCreateOptions options, string accessToken);

        /// <summary>
        /// Add an attachment to an external sale invoice.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="id">The external sale invoice id.</param>
        /// <param name="body">The file to attach.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="fileName">The file name. Defaults to "invoice.pdf".</param>
        Task AddAttachmentAsync(string administrationId, string id, Stream body, string accessToken, string fileName = "invoice.pdf");
    }
}
