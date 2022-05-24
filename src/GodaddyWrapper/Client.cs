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

namespace GodaddyWrapper
{
public partial class Client
{
        private string AccessKey { get; }
        private string SecretKey { get; }
        private string RootPath { get; } = "https://api.ote-godaddy.com/v1/";

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

        /// <summary>
        /// Client for calling API
        /// </summary>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="rootPath"></param>
        public Client(string accessKey, string secretKey, string rootPath = null)
        {
            AccessKey = accessKey;
            SecretKey = secretKey;
            RootPath = rootPath ?? RootPath;
        }

        private HttpClient GetBaseHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RootPath);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = GetAuthenticationHeader();
            return client;
        }

        private AuthenticationHeaderValue GetAuthenticationHeader()
        {
            return new AuthenticationHeaderValue("sso-key", $"{AccessKey}:{SecretKey}");
        }

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
}
