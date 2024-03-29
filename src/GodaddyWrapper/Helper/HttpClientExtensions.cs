﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GodaddyWrapper.Helper
{
    internal static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsync(this HttpClient client, string requestUri, string jsonString)
        {
            return client.PostAsync(requestUri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public static Task<HttpResponseMessage> PutAsync(this HttpClient client, string requestUri, string jsonString)
        {
			return client.PutAsync(requestUri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, string jsonString)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri){
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
            return client.SendAsync(request);
        }
    }
}


