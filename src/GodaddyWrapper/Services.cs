using GodaddyWrapper.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace GodaddyWrapper
{
    /// <summary>
    /// Dependency-injection registration for <see cref="GoDaddyClient"/>. Available on both
    /// net462 and netstandard2.0.
    /// </summary>
    public static class ServicesExtension
    {
        private static readonly Uri BaseAddress = new Uri("https://api.godaddy.com/");

        /// <summary>
        /// Registers <see cref="IGoDaddyClient"/>/<see cref="GoDaddyClient"/> as a typed HttpClient
        /// authenticated with the supplied GoDaddy Personal Access Token.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="personalAccessToken">The GoDaddy Personal Access Token.</param>
        public static IServiceCollection AddGoDaddy(this IServiceCollection services, string personalAccessToken)
            => services.AddGoDaddy(options => options.PersonalAccessToken = personalAccessToken);

        /// <summary>
        /// Registers <see cref="IGoDaddyClient"/>/<see cref="GoDaddyClient"/> as a typed HttpClient,
        /// configuring options (including the Personal Access Token) via the supplied delegate.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configure">Delegate used to populate <see cref="GoDaddyClientOptions"/>.</param>
        public static IServiceCollection AddGoDaddy(this IServiceCollection services, Action<GoDaddyClientOptions> configure)
        {
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            services.Configure(configure);
            services.AddTransient<BearerTokenHandler>();

            services.AddHttpClient<IGoDaddyClient, GoDaddyClient>(client =>
            {
                client.BaseAddress = BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
            .AddHttpMessageHandler<BearerTokenHandler>();

            return services;
        }
    }
}
