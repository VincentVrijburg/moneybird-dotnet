using System.IO;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Endpoints.ExternalSalesInvoices.Models;
using Moneybird.Net.Entities.ExternalSalesInvoices;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IExternalSalesInvoiceEndpoint :
        IReadEndpoint<ExternalSalesInvoice>,
        IReadFilterEndpoint<ExternalSalesInvoice, ExternalSalesInvoiceFilterOptions>,
        IGetEndpoint<ExternalSalesInvoice>,
        ICreateEndpoint<ExternalSalesInvoice, ExternalSalesInvoiceCreateOptions>
    {
        /// <summary>
        /// Add an attachment to an external sales invoice.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="externalSalesInvoiceId">The external sales invoice id.</param>
        /// <param name="body">The file to attach.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="fileName">The file name. Defaults to "invoice.pdf".</param>
        Task AddAttachmentAsync(string administrationId, string externalSalesInvoiceId, Stream body, string accessToken, string fileName = "invoice.pdf");
    }
}
