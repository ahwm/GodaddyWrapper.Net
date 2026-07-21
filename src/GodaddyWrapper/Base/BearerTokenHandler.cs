using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace GodaddyWrapper.Base
{
    /// <summary>
    /// Attaches the GoDaddy Personal Access Token as an <c>Authorization: Bearer &lt;token&gt;</c>
    /// header to every outgoing request. Registered on the typed <see cref="GoDaddyClient"/>
    /// so the shared <see cref="HttpClient"/>'s default headers are never mutated.
    /// </summary>
    internal sealed class BearerTokenHandler : DelegatingHandler
    {
        private readonly string _personalAccessToken;

        public BearerTokenHandler(IOptions<GoDaddyClientOptions> options)
        {
            _personalAccessToken = options?.Value?.PersonalAccessToken
                ?? throw new ArgumentException("A GoDaddy Personal Access Token is required.", nameof(options));
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _personalAccessToken);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
