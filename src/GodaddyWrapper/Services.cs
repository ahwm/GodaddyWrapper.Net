#if NETSTANDARD 
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GodaddyWrapper
{
    public static class ServicesExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="testing"></param>
        /// <returns></returns>
        public static IServiceCollection AddGoDaddy(this IServiceCollection services, string accessKey, string secretKey, bool testing = false)
        {
            services.AddHttpClient<GoDaddyClient>(client =>
            {
                client.BaseAddress = new Uri(testing ? "https://api.ote-godaddy.com/v1/" : "https://api.godaddy.com/v1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("sso-key", $"{accessKey}:{secretKey}");
            });

            return services;
        }
    }
}
#endif
