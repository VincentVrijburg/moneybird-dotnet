using Moneybird.Net.Extensions;
using Xunit;

namespace Moneybird.Net.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToSnakeCase_FromPascalCase_Returns_CorrectString()
        {
            const string testValue = "PascalCase";
            const string expectedValue = "pascal_case";
            var actualValue = testValue.ToSnakeCase();
            
            Assert.Equal(expectedValue, actualValue);
        }
        
        [Fact]
        public void ToSnakeCase_FromCamelCase_Returns_CorrectString()
        {
            const string testValue = "camelCase";
            const string expectedValue = "camel_case";
            var actualValue = testValue.ToSnakeCase();
            
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
