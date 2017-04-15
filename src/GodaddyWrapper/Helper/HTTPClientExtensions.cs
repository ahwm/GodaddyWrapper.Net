using Newtonsoft.Json;
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
        public static Task<HttpResponseMessage> PostAsync(this HttpClient client, string requestUri, Object content)
        {
            var jsonString = JsonConvert.SerializeObject(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return client.PostAsync(requestUri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public static Task<HttpResponseMessage> PutAsync(this HttpClient client, string requestUri, Object content)
        {
			var jsonString = JsonConvert.SerializeObject(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
			return client.PutAsync(requestUri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, Object content)
        {
            var jsonString = JsonConvert.SerializeObject(content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri){
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = new HttpResponseMessage();
            return client.SendAsync(request);
        }
    }
}


