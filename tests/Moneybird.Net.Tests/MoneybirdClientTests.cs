using System.Net.Http;
using Moneybird.Net.Abstractions;
using Moq;
using Moq.Protected;
using Xunit;

namespace Moneybird.Net.Tests
{
    public class MoneybirdClientTests
    {
        [Fact]
        public void GetInstance_ByConfig_Returns_Correct_Instance()
        {
            var moneybirdClient = (IMoneybirdClient) MoneybirdClient.GetInstance(new MoneybirdConfig());
            
            // TODO: Expand this test case as new endpoints get supported.
            Assert.NotNull(moneybirdClient.Administration);
            Assert.NotNull(moneybirdClient.Contact);
            Assert.NotNull(moneybirdClient.CustomField);
            Assert.NotNull(moneybirdClient.DocumentStyle);
            Assert.NotNull(moneybirdClient.Payment);
            Assert.NotNull(moneybirdClient.Product);
            Assert.NotNull(moneybirdClient.User);
            Assert.NotNull(moneybirdClient.Verification);
            Assert.NotNull(moneybirdClient.Workflow);
            Assert.NotNull(moneybirdClient.SalesInvoice);
            Assert.NotNull(moneybirdClient.TaxRate);
            Assert.NotNull(moneybirdClient.LedgerAccount);
            Assert.NotNull(moneybirdClient.ExternalSalesInvoice);
        }
        
        [Fact]
        public void GetInstance_BySameConfig_Returns_Same_Instance()
        {
            var config = new MoneybirdConfig();
            
            var firstMoneybirdClient = MoneybirdClient.GetInstance(config);
            Assert.NotNull(firstMoneybirdClient);
            
            var secondMoneybirdClient = MoneybirdClient.GetInstance(config);
            Assert.NotNull(secondMoneybirdClient);
            
            Assert.Same(firstMoneybirdClient, secondMoneybirdClient);
        }
        
        [Fact]
        public void GetInstance_ByDifferentConfig_Returns_Different_Instance()
        {
            var firstConfig = new MoneybirdConfig();
            var firstMoneybirdClient = MoneybirdClient.GetInstance(firstConfig);
            Assert.NotNull(firstMoneybirdClient);
            
            var secondConfig = new MoneybirdConfig();
            var secondMoneybirdClient = MoneybirdClient.GetInstance(secondConfig);
            Assert.NotNull(secondMoneybirdClient);

            Assert.NotSame(firstMoneybirdClient.Config, secondMoneybirdClient.Config);
            Assert.NotSame(firstMoneybirdClient, secondMoneybirdClient);
        }

        [Fact]
        public void Dispose_Disposes_HttpClient()
        {
            var config = new MoneybirdConfig();
            var mock = new Mock<HttpClient>();

            var moneybirdClient = new MoneybirdClient(config, mock.Object);
            moneybirdClient.Dispose();

            mock.Protected().Verify("Dispose", Times.Once(), args: true);
        }
    }
}
