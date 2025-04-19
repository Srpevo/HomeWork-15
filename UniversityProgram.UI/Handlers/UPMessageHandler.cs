
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;

namespace UniversityProgram.UI.Handlers
{
    public class UPMessageHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider _provider;

        public UPMessageHandler(IAccessTokenProvider provider)
        {
            _provider = provider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenResult = await _provider.RequestAccessToken();

            if (tokenResult.TryGetToken(out var token))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Value);
            }
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
