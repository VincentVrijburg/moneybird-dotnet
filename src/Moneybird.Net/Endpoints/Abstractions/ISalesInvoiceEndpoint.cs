using System.IO;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Models.SalesInvoices;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface ISalesInvoiceEndpoint : 
        IReadEndpoint<SalesInvoice>,
        IReadFilterEndpoint<SalesInvoice, SalesInvoiceFilterOptions>,
        IGetEndpoint<SalesInvoice>,
        ICreateEndpoint<SalesInvoice, SalesInvoiceCreateOptions>,
        IUpdateEndpoint<SalesInvoice, SalesInvoiceUpdateOptions>,
        IDeleteEndpoint
    {
        /// <summary>
        /// Send an invoice to a customer.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="salesInvoiceId">The sales invoice id.</param>
        /// <param name="options">The options to send the invoice with.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns></returns>
        Task<SalesInvoice> SendInvoice(string administrationId, string salesInvoiceId, SalesInvoiceSendOptions options, string accessToken);

        /// <summary>
        /// Add an attachment to a sales invoice.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="salesInvoiceId">The sales invoice id.</param>
        /// <param name="body">The file to attach.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="fileName">The file name. Defaults to "invoice.pdf".</param>
        Task AddAttachmentAsync(string administrationId, string salesInvoiceId, Stream body, string accessToken, string fileName = "invoice.pdf");
    }
}
