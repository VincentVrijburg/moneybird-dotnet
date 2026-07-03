using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moneybird.Net.Abstractions;
using Moneybird.Net.Authentication;
using Moneybird.Net.Authentication.Abstractions;

namespace Moneybird.Net
{
    /// <summary>
    /// Extension methods for registering Moneybird services in an IServiceCollection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds <see cref="IMoneybirdClient"/> and its dependencies to the service collection.
        /// <para>
        /// The client is registered as a <em>typed HTTP client</em> backed by
        /// <see cref="System.Net.Http.IHttpClientFactory"/>, which pools the underlying
        /// <see cref="System.Net.Http.HttpMessageHandler"/> instances to prevent socket exhaustion.
        /// Each resolution of <see cref="IMoneybirdClient"/> from the container receives a
        /// fresh <see cref="System.Net.Http.HttpClient"/> wrapper (transient), but the handlers
        /// are reused and their lifetimes are managed by the factory.
        /// </para>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register into.</param>
        /// <param name="config">The Moneybird configuration.</param>
        /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
        public static IServiceCollection AddMoneybird(this IServiceCollection services, MoneybirdConfig config)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (config == null) throw new ArgumentNullException(nameof(config));

            services.TryAddSingleton(config);

            services.AddHttpClient<IMoneybirdClient, MoneybirdClient>();

            return services;
        }

        /// <summary>
        /// Adds <see cref="IMoneybirdAuthenticator"/> and its dependencies to the service collection.
        /// <para>
        /// Requires OAuth2 credentials (<c>ClientId</c>, <c>ClientSecret</c>, <c>RedirectUri</c>)
        /// to be present in <paramref name="config"/>. Use this overload when registering the
        /// authenticator standalone. When registering alongside <see cref="AddMoneybird"/>, use
        /// <see cref="AddMoneybirdAuthenticator(IServiceCollection)"/> to avoid passing the
        /// configuration twice.
        /// </para>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register into.</param>
        /// <param name="config">The Moneybird configuration, including OAuth2 credentials.</param>
        /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
        public static IServiceCollection AddMoneybirdAuthenticator(this IServiceCollection services, MoneybirdConfig config)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (config == null) throw new ArgumentNullException(nameof(config));

            services.TryAddSingleton(config);

            return services.AddMoneybirdAuthenticator();
        }

        /// <summary>
        /// Adds <see cref="IMoneybirdAuthenticator"/> and its dependencies to the service collection,
        /// reusing the <see cref="MoneybirdConfig"/> already registered by <see cref="AddMoneybird"/>.
        /// <para>
        /// Use this overload when <see cref="AddMoneybird"/> has already been called. Requires
        /// <see cref="MoneybirdConfig"/> to be present in the service collection, and OAuth2 credentials
        /// (<c>ClientId</c>, <c>ClientSecret</c>, <c>RedirectUri</c>) to be set on that configuration.
        /// </para>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register into.</param>
        /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
        public static IServiceCollection AddMoneybirdAuthenticator(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // BaseAddress is resolved from the container at runtime so that this overload
            // does not need a config parameter when used alongside AddMoneybird.
            services.AddHttpClient<IMoneybirdAuthenticator, MoneybirdAuthenticator>((sp, client) =>
            {
                var config = sp.GetRequiredService<MoneybirdConfig>();
                client.BaseAddress = new Uri(config.AuthUri);
            });

            return services;
        }
    }
}

