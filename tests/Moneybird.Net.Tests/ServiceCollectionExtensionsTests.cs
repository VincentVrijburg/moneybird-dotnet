using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moneybird.Net.Abstractions;
using Moneybird.Net.Authentication;
using Moneybird.Net.Authentication.Abstractions;
using Xunit;

namespace Moneybird.Net.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void AddMoneybird_RegistersIMoneybirdClient()
        {
            var services = new ServiceCollection();
            services.AddMoneybird(new MoneybirdConfig());

            var client = services.BuildServiceProvider().GetService<IMoneybirdClient>();

            client.Should().NotBeNull().And.BeOfType<MoneybirdClient>();
        }

        [Fact]
        public void AddMoneybird_RegistersMoneybirdConfigAsSingleton()
        {
            var config = new MoneybirdConfig();
            var provider = new ServiceCollection()
                .AddMoneybird(config)
                .BuildServiceProvider();

            provider.GetRequiredService<MoneybirdConfig>().Should().BeSameAs(config);
        }

        [Fact]
        public void AddMoneybird_CalledTwice_DoesNotThrow()
        {
            var config = new MoneybirdConfig();
            var services = new ServiceCollection();

            services.AddMoneybird(config);
            services.AddMoneybird(config);

            services.BuildServiceProvider()
                .GetService<IMoneybirdClient>()
                .Should().NotBeNull();
        }

        [Fact]
        public void AddMoneybirdAuthenticator_RegistersIMoneybirdAuthenticator()
        {
            var services = new ServiceCollection();
            services.AddMoneybirdAuthenticator(new MoneybirdConfig("clientId", "clientSecret"));

            var authenticator = services.BuildServiceProvider().GetService<IMoneybirdAuthenticator>();

            authenticator.Should().NotBeNull().And.BeOfType<MoneybirdAuthenticator>();
        }

        [Fact]
        public void AddMoneybirdAuthenticator_RegistersMoneybirdConfigAsSingleton()
        {
            var config = new MoneybirdConfig("clientId", "clientSecret");
            var provider = new ServiceCollection()
                .AddMoneybirdAuthenticator(config)
                .BuildServiceProvider();

            provider.GetRequiredService<MoneybirdConfig>().Should().BeSameAs(config);
        }

        [Fact]
        public void AddMoneybird_ThenAddMoneybirdAuthenticator_RegistersBothServices()
        {
            var config = new MoneybirdConfig("clientId", "clientSecret");
            var provider = new ServiceCollection()
                .AddMoneybird(config)
                .AddMoneybirdAuthenticator()
                .BuildServiceProvider();

            provider.GetService<IMoneybirdClient>().Should().NotBeNull();
            provider.GetService<IMoneybirdAuthenticator>().Should().NotBeNull();
        }

        [Fact]
        public void AddMoneybird_ThenAddMoneybirdAuthenticator_SharesSameMoneybirdConfig()
        {
            var config = new MoneybirdConfig("clientId", "clientSecret");
            var provider = new ServiceCollection()
                .AddMoneybird(config)
                .AddMoneybirdAuthenticator()
                .BuildServiceProvider();

            provider.GetRequiredService<MoneybirdConfig>().Should().BeSameAs(config);
        }
    }
}
