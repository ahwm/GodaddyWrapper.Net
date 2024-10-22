using GodaddyWrapper.Responses;
using GodaddyWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using GodaddyWrapper.Helper;
using GodaddyWrapper.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
#if NETSTANDARD
using Microsoft.Extensions.Options;
#endif

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        private string ProductionEndpoint { get; } = "https://api.godaddy.com/v1/";
        private string TestingEndpoint { get; } = "https://api.ote-godaddy.com/v1/";

        private readonly HttpClient httpClient;

        readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            },
            NullValueHandling = NullValueHandling.Ignore
        };

#if !NETSTANDARD
        /// <summary>
        /// Client for calling API
        /// </summary>
        /// <param name="options"></param>
        public GoDaddyClient(GoDaddyClientOptions options)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(options.IsTesting ? TestingEndpoint : ProductionEndpoint)
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("sso-key", $"{options.AccessKey}:{options.SecretKey}");            
        }
#else
        public GoDaddyClient(HttpClient _client, IOptions<GoDaddyClientOptions> options)
        {
            var opts = options.Value;
            httpClient = _client;
            httpClient.BaseAddress = new Uri(opts.IsTesting ? TestingEndpoint : ProductionEndpoint);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("sso-key", $"{opts.AccessKey}:{opts.SecretKey}");
        }
#endif

        private static async Task CheckResponseMessageIsValid(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;
            throw new GodaddyException(response.StatusCode, await response.Content.ReadAsAsync<ErrorResponse>(), "");
        }

        private static void CheckRequestValid(object Model)
        {
            var results = new List<ValidationResult>();
            if (!ModelValidator.IsValid(Model, out results))
                throw new Exception(string.Join("\n", results.Select(c => c.ErrorMessage)));
        }
    }

    public sealed class GoDaddyClientOptions
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public bool IsTesting { get; set; }
    }
}