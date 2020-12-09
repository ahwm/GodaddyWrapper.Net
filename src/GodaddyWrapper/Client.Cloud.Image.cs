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
        /// Create a new image
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudImageResponse> CreateImage(CloudImageCreate request)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/images", request);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudImageResponse>();
        }
        /// <summary>
        /// Destroy an image
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudImageActionResponse> DestroyImage(CloudImageDestroy request)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/images/{request.ImageId}/destroy", null);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudImageActionResponse>();
        }
        /// <summary>
        /// Publish this image
        /// </summary>
        /// <param name="request"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public async Task PublishImage(CloudImagePublicationCreate request, string imageId)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/images/{imageId}/publish", request);
            await CheckResponseMessageIsValid(response);
            return;
        }
        /// <summary>
        /// List of actions performed on images
        /// </summary>
        /// <param name="request"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public async Task<CloudImageActionListResponse> RetrieveImageActions(CloudImageActionRetrieve request, string imageId)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/images/{imageId}/actions{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudImageActionListResponse>();
        }
        /// <summary>
        /// Get ImageAction by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudImageActionResponse> RetrieveImageActionDetail(CloudImageActionDetailRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/images/{request.ImageId}/actions/{request.ImageActionId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudImageActionResponse>();
        }
        /// <summary>
        /// Find image by image imageId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudImageResponse> RetrieveImageDetail(CloudImageDetailRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/images/{request.ImageId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudImageResponse>();
        }
        /// <summary>
        /// Get a list of images. By default, only LIVE images are returned
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudImageListResponse> RetrieveImages(CloudImageRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/images{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudImageListResponse>();
        }
    }
}
