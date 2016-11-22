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

namespace GodaddyWrapper
{
    public partial class Client
    {
        /// <summary>
        /// Get the email preferences for the user.
        /// </summary>
        /// <returns></returns>
        public async Task<EmailPreferenceResponse> RetrieveEmailPreference()
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/emailpreferences");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<EmailPreferenceResponse>();
        }
        /// <summary>
        /// Update the user's email preferences
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<EmailPreferenceResponse> UpdateEmailPreference(EmailPreferenceRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PatchAsync($"cloud/emailpreferences", request);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<EmailPreferenceResponse>();
        }
    }
}
