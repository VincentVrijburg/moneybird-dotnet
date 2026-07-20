using System.Collections.Generic;
using System.Threading.Tasks;
using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.FinancialMutations;
using Moneybird.Net.Models.FinancialMutations;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IFinancialMutationEndpoint :
        IReadEndpoint<FinancialMutation>,
        IReadFilterEndpoint<FinancialMutation, FinancialMutationFilterOptions>,
        IGetEndpoint<FinancialMutation>
    {
        Task<IEnumerable<SynchronizationFinancialMutation>> GetSynchronizationFinancialMutationsAsync(
            string administrationId,
            string accessToken,
            int page = 1,
            int perPage = 50);

        Task<IEnumerable<SynchronizationFinancialMutation>> GetSynchronizationFinancialMutationsAsync(
            string administrationId,
            string accessToken,
            FinancialMutationFilterOptions options,
            int page = 1,
            int perPage = 50);

        Task<IEnumerable<FinancialMutation>> GetFinancialMutationsByIdsAsync(
            string administrationId,
            string accessToken,
            FinancialMutationListOptions options);

        Task<bool> LinkBookingAsync(
            string administrationId,
            string financialMutationId,
            FinancialMutationLinkBookingOptions options,
            string accessToken);

        Task<FinancialMutation> UnlinkBookingAsync(
            string administrationId,
            string financialMutationId,
            FinancialMutationUnlinkBookingOptions options,
            string accessToken);
    }
}
