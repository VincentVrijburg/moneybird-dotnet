using Moneybird.Net.Abstractions;
using Moneybird.Net.Endpoints.Abstractions;
using Moneybird.Net.Endpoints.Administrations;
using Moneybird.Net.Endpoints.Contacts;
using Moneybird.Net.Endpoints.CustomFields;
using Moneybird.Net.Endpoints.DocumentStyles;
using Moneybird.Net.Endpoints.Payments;
using Moneybird.Net.Endpoints.Users;
using Moneybird.Net.Endpoints.Verifications;
using Moneybird.Net.Endpoints.Workflows;
using Moneybird.Net.Http;

namespace Moneybird.Net
{
    public class MoneybirdClient : IMoneybirdClient
    {
        private static MoneybirdClient _instance;
        private static MoneybirdConfig _config;

        public IAdministrationEndpoint Administration { get; }
        public IContactEndpoint Contact { get; }
        public ICustomFieldEndpoint CustomField { get; }
        public IDocumentStyleEndpoint DocumentStyle { get; }
        public IPaymentEndpoint Payment { get; }
        public IUserEndpoint User { get; }
        public IVerificationEndpoint Verification { get; }
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
            
            if (_instance == null || !_config.Equals(config))
            {
                _config = config;
                _instance = new MoneybirdClient();
            }
            
            return _instance;
        }
        
        private MoneybirdClient()
        {
            var requester = new Requester();
            
            Administration = new AdministrationEndpoint(_config, requester);
            Contact = new ContactEndpoint(_config, requester);
            CustomField = new CustomFieldEndpoint(_config, requester);
            DocumentStyle = new DocumentStyleEndpoint(_config, requester);
            Payment = new PaymentEndpoint(_config, requester);
            User = new UserEndpoint(_config, requester);
            Verification = new VerificationEndpoint(_config, requester);
            Workflow = new WorkflowEndpoint(_config, requester);
        }
    }
}