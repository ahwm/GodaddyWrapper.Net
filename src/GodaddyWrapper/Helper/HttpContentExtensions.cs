using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GodaddyWrapper.Helper
{
	/// <summary>
	/// To prevent using Microsoft.AspNet.WebApi.Client package so It can support the latest .NetCore
	/// </summary>
	internal static class HttpContentExtensions
    {
        public static Task<T> ReadAsAsync<T>(this HttpContent client)
        {
            return client.ReadAsStringAsync().ContinueWith(data =>
            {
                return JsonConvert.DeserializeObject<T>(data.Result);
            });
        }

    }
}


