using System;
using Moneybird.Net.Endpoints.Abstractions;

namespace Moneybird.Net.Abstractions
{
    public interface IMoneybirdClient : IDisposable
    {
        /// <summary>
        /// The Administration Endpoint.
        /// </summary>
        IAdministrationEndpoint Administration { get; }
        
        /// <summary>
        /// The Contact Endpoint.
        /// </summary>
        IContactEndpoint Contact { get; }
        
        /// <summary>
        /// The CustomField Endpoint.
        /// </summary>
        ICustomFieldEndpoint CustomField { get; }
        
        /// <summary>
        /// The DocumentStyle Endpoint.
        /// </summary>
        IDocumentStyleEndpoint DocumentStyle { get; }
        
        /// <summary>
        /// The ExternalSalesInvoice Endpoint.
        /// </summary>
        IExternalSalesInvoiceEndpoint ExternalSalesInvoice { get; }
        
        /// <summary>
        /// The FinancialAccount Endpoint.
        /// </summary>
        IFinancialAccountEndpoint FinancialAccount { get; }
        
        /// <summary>
        /// The FinancialAccount Endpoint.
        /// </summary>
        IFinancialStatementEndpoint FinancialStatement { get; }
        
        /// <summary>
        /// The LedgerAccount Endpoint.
        /// </summary>
        ILedgerAccountEndpoint LedgerAccount { get; }
        
        /// <summary>
        /// The Payment Endpoint.
        /// </summary>
        IPaymentEndpoint Payment { get; }
        
        /// <summary>
        /// The Product Endpoint.
        /// </summary>
        IProductEndpoint Product { get; }
        
        /// <summary>
        /// The Project Endpoint.
        /// </summary>
        IProjectEndpoint Project { get; }
        
        /// <summary>
        /// The SalesInvoice Endpoint.
        /// </summary>
        ISalesInvoiceEndpoint SalesInvoice { get; }
        
        /// <summary>
        /// The TaxRate Endpoint.
        /// </summary>
        ITaxRateEndpoint TaxRate { get; }
        
        /// <summary>
        /// The User Endpoint.
        /// </summary>
        IUserEndpoint User { get; }
        
        /// <summary>
        /// The Verification Endpoint.
        /// </summary>
        IVerificationEndpoint Verification { get; }
        
        /// <summary>
        /// The Webhook Endpoint.
        /// </summary>
        IWebhookEndpoint Webhook { get; }
        
        /// <summary>
        /// The Workflow Endpoint.
        /// </summary>
        IWorkflowEndpoint Workflow { get; }
    }
}
