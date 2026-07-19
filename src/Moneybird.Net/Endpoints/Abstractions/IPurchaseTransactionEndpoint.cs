using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.PurchaseTransactions;
using Moneybird.Net.Models.PurchaseTransactions;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IPurchaseTransactionEndpoint :
        IReadEndpoint<PurchaseTransaction>,
        IReadFilterEndpoint<PurchaseTransaction, PurchaseTransactionFilterOptions>,
        IGetEndpoint<PurchaseTransaction>,
        IDeleteEndpoint
    {
        /// <summary>
        /// Upload a SEPA credit transfer file and create purchase transaction batches.
        /// </summary>
        /// <param name="administrationId">The administration id.</param>
        /// <param name="body">The SEPA credit transfer file body.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="options">Optional upload options.</param>
        /// <returns>The created purchase transaction batches.</returns>
        Task<IEnumerable<PurchaseTransactionBatch>> UploadSepaCreditTransferAsync(
            string administrationId,
            Stream body,
            string accessToken,
            PurchaseTransactionSepaCreditTransferOptions options = null);
    }
}
