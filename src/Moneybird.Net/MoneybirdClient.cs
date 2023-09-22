using System;
using System.Net.Http;
using Moneybird.Net.Abstractions;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Administrations;
using Moneybird.Net.Endpoints.Contacts;
using Moneybird.Net.Endpoints.CustomFields;
using Moneybird.Net.Endpoints.DocumentStyles;
using Moneybird.Net.Endpoints.ExternalSalesInvoices;
using Moneybird.Net.Endpoints.FinancialAccounts;
using Moneybird.Net.Endpoints.LegderAccounts;
using Moneybird.Net.Endpoints.Payments;
using Moneybird.Net.Endpoints.Products;
using Moneybird.Net.Endpoints.Projects;
using Moneybird.Net.Endpoints.SalesInvoices;
using Moneybird.Net.Endpoints.TaxRates;
using Moneybird.Net.Endpoints.Users;
using Moneybird.Net.Endpoints.Verifications;
using Moneybird.Net.Endpoints.Webhooks;
using Moneybird.Net.Endpoints.Workflows;
using Moneybird.Net.Http;

namespace Moneybird.Net
{
    public class MoneybirdClient : IMoneybirdClient
    {
        private static MoneybirdClient _instance;

        private readonly Requester _requester;

        internal MoneybirdConfig Config { get; }
        
        public IAdministrationEndpoint Administration { get; }
        public IContactEndpoint Contact { get; }
        public ICustomFieldEndpoint CustomField { get; }
        public IDocumentStyleEndpoint DocumentStyle { get; }
        public IExternalSalesInvoiceEndpoint ExternalSalesInvoice { get; }
        public IFinancialAccountEndpoint FinancialAccount { get; }
        public ILedgerAccountEndpoint LedgerAccount { get; }
        public IPaymentEndpoint Payment { get; }
        public IProductEndpoint Product { get; }
        public IProjectEndpoint Project { get; }
        public ISalesInvoiceEndpoint SalesInvoice { get; }
        public ITaxRateEndpoint TaxRate { get; }
        public IUserEndpoint User { get; }
        public IVerificationEndpoint Verification { get; }
        public IWebhookEndpoint Webhook { get; }
        public IWorkflowEndpoint Workflow { get; }
        
        /// <summary>
        /// Get the instance of MoneybirdClient.
        /// </summary>
        /// <param name="config">The Moneybird config.</param>
        /// <returns>
        /// The instance of MoneybirdClient.
        /// </returns>
        public static MoneybirdClient GetInstance(MoneybirdConfig config)
        {
            ArgumentGuard.NotNull(config, nameof(config));

            var instance = _instance;
            
            if (instance?.Config != config)
            {
                instance = new MoneybirdClient(config);
                _instance = instance;
            }
            
            return instance;
        }
        
        public MoneybirdClient(MoneybirdConfig config, HttpClient client = null)
        {
            Config = config;
            _requester = new Requester(client ?? new HttpClient());
            Administration = new AdministrationEndpoint(Config, _requester);
            Contact = new ContactEndpoint(Config, _requester);
            CustomField = new CustomFieldEndpoint(Config, _requester);
            DocumentStyle = new DocumentStyleEndpoint(Config, _requester);
            ExternalSalesInvoice = new ExternalSalesInvoiceEndpoint(Config, _requester);
            FinancialAccount = new FinancialAccountEndpoint(Config, _requester);
            LedgerAccount = new LedgerAccountEndpoint(Config, _requester);
            Payment = new PaymentEndpoint(Config, _requester);
            Product = new ProductEndpoint(Config, _requester);
            Project = new ProjectEndpoint(Config, _requester);
            SalesInvoice = new SalesInvoiceEndpoint(Config, _requester);
            TaxRate = new TaxRateEndpoint(Config, _requester);
            User = new UserEndpoint(Config, _requester);
            Verification = new VerificationEndpoint(Config, _requester);
            Webhook = new WebhookEndpoint(Config, _requester);
            Workflow = new WorkflowEndpoint(Config, _requester);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _requester.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
