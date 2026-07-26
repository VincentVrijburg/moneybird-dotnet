using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.Estimates;
using Moneybird.Net.Entities.Notes;
using Moneybird.Net.Entities.SalesInvoices;
using Moneybird.Net.Models.Estimates;
using Moneybird.Net.Models.Notes;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IEstimateEndpoint :
        IReadEndpoint<Estimate>,
        IReadFilterEndpoint<Estimate, EstimateFilterOptions>,
        IGetEndpoint<Estimate>,
        ICreateEndpoint<Estimate, EstimateCreateOptions>,
        IUpdateEndpoint<Estimate, EstimateUpdateOptions>,
        IDeleteEndpoint
    {
        /// <summary>
        /// Get a single estimate by its human-readable estimate number (for example <c>2026-0001</c>).
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The estimate number shown in Moneybird (not the internal entity id).</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns>The matching <see cref="Estimate"/>.</returns>
        Task<Estimate> GetByEstimateIdAsync(string administrationId, string estimateId, string accessToken);
        
        /// <summary>
        /// Get estimate synchronization records (id and version) for an administration.
        /// Use this to detect changed estimates before fetching full records.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimates.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <param name="page">The page number to retrieve. Defaults to 1.</param>
        /// <param name="perPage">The number of records per page. Defaults to 50.</param>
        /// <returns>A collection of <see cref="SynchronizationEstimate"/> items containing estimate ids and versions.</returns>
        Task<IEnumerable<SynchronizationEstimate>> GetSynchronizationEstimatesAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50);
        
        /// <summary>
        /// Get filtered estimate synchronization records (id and version).
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimates.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <param name="options">Filter options such as state, period, or contact id.</param>
        /// <param name="page">The page number to retrieve. Defaults to 1.</param>
        /// <param name="perPage">The number of records per page. Defaults to 50.</param>
        /// <returns>A filtered collection of <see cref="SynchronizationEstimate"/> items.</returns>
        Task<IEnumerable<SynchronizationEstimate>> GetSynchronizationEstimatesAsync(
            string administrationId,
            string accessToken,
            EstimateFilterOptions options,
            int page = 1,
            int perPage = 50);
        
        /// <summary>
        /// Fetch full estimate records by id list, typically after a synchronization call.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimates.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <param name="options">Options containing the estimate ids to fetch.</param>
        /// <returns>A collection of <see cref="Estimate"/> entities for the supplied ids.</returns>
        Task<IEnumerable<Estimate>> GetEstimatesByIdsAsync(string administrationId, string accessToken, EstimateListOptions options);
        
        /// <summary>
        /// Send an estimate to a customer.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="options">Delivery and message options for sending the estimate.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns>The updated <see cref="Estimate"/> after send processing.</returns>
        Task<Estimate> SendEstimate(string administrationId, string estimateId, EstimateSendOptions options, string accessToken);
        
        /// <summary>
        /// Change the state of an estimate (for example to accepted, rejected, or archived).
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="options">Options containing the target state value.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns>The updated <see cref="Estimate"/> with the new state.</returns>
        Task<Estimate> ChangeStateAsync(string administrationId, string estimateId, EstimateChangeStateOptions options, string accessToken);
        
        /// <summary>
        /// Bill an estimate and create a sales invoice based on it.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns>The created <see cref="SalesInvoice"/>.</returns>
        Task<SalesInvoice> BillEstimateAsync(string administrationId, string estimateId, string accessToken);
        
        /// <summary>
        /// Download the generated PDF for an estimate.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns>A readable stream containing the estimate PDF data.</returns>
        Task<Stream> DownloadPdfAsync(string administrationId, string estimateId, string accessToken);
        
        /// <summary>
        /// Add an attachment to an estimate.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="body">The file stream to attach.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <param name="fileName">The file name. Defaults to "estimate.pdf".</param>
        Task AddAttachmentAsync(string administrationId, string estimateId, Stream body, string accessToken, string fileName = "estimate.pdf");
        
        /// <summary>
        /// Download a specific estimate attachment by attachment id.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="attachmentId">The attachment id to download.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns>A readable stream containing the attachment file data.</returns>
        Task<Stream> DownloadAttachmentByIdAsync(string administrationId, string estimateId, string attachmentId, string accessToken);
        
        /// <summary>
        /// Delete a specific attachment from an estimate.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="attachmentId">The attachment id to delete.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns><c>true</c> when the attachment was deleted successfully.</returns>
        Task<bool> DeleteAttachmentByIdAsync(string administrationId, string estimateId, string attachmentId, string accessToken);
        
        /// <summary>
        /// Create a note on an estimate.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="options">Note creation payload (note text, todo flag, assignee).</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns>The created <see cref="Note"/>.</returns>
        Task<Note> CreateEstimateNoteAsync(string administrationId, string estimateId, NoteCreateOptions options, string accessToken);
        
        /// <summary>
        /// Delete a note from an estimate.
        /// </summary>
        /// <param name="administrationId">The administration id that owns the estimate.</param>
        /// <param name="estimateId">The internal estimate entity id.</param>
        /// <param name="noteId">The note id to delete.</param>
        /// <param name="accessToken">The OAuth access token with <c>estimates</c> scope.</param>
        /// <returns><c>true</c> when the note was deleted successfully.</returns>
        Task<bool> DeleteEstimateNoteByIdAsync(string administrationId, string estimateId, string noteId, string accessToken);
    }
}
