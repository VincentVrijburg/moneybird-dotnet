using Moneybird.Net.Abstractions;
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
            
            Assert.NotSame(firstMoneybirdClient, secondMoneybirdClient);
        }
    }
}