using Moneybird.Net.Endpoints.Abstractions.Common;
using Moneybird.Net.Entities.FinancialStatements;
using Moneybird.Net.Models.FinancialStatements;

namespace Moneybird.Net.Endpoints.Abstractions
{
    public interface IFinancialStatementEndpoint :
        ICreateEndpoint<FinancialStatement, FinancialStatementCreateOptions>,
        IUpdateEndpoint<FinancialStatement, FinancialStatementUpdateOptions>,
        IDeleteEndpoint
    {
    }
}