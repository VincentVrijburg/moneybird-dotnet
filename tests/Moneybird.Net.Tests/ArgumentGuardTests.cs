using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Moneybird.Net.Tests
{
    public class ArgumentGuardTests
    {
        [Fact]
        public void ObjectNull_Throws_ArgumentNullException()
        {
            StringBuilder obj = null;
            Assert.Throws<ArgumentNullException>(() => ArgumentGuard.NotNull(obj, nameof(obj)));
        }
        
        [Fact]
        public void CollectionNull_Throws_ArgumentNullException()
        {
            IEnumerable<string> obj = null;
            Assert.Throws<ArgumentNullException>(() => ArgumentGuard.NotNullNorEmpty(obj, nameof(obj)));
        }
        
        [Fact]
        public void CollectionEmpty_Throws_ArgumentException()
        {
            IEnumerable<string> obj = Array.Empty<string>();
            Assert.Throws<ArgumentException>(() => ArgumentGuard.NotNullNorEmpty(obj, nameof(obj)));
        }
        
        [Fact]
        public void StringNull_Throws_ArgumentNullException()
        {
            string obj = null;
            Assert.Throws<ArgumentNullException>(() => ArgumentGuard.NotNullNorEmpty(obj, nameof(obj)));
        }
        
        [Fact]
        public void StringEmpty_Throws_ArgumentException()
        {
            var obj = string.Empty;
            Assert.Throws<ArgumentException>(() => ArgumentGuard.NotNullNorEmpty(obj, nameof(obj)));
        }
    }
}