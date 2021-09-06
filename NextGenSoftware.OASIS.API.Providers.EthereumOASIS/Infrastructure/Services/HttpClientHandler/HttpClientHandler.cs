using System.Net.Http;
using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.HttpClientHandler
{
    public class HttpClientHandler : IHttpClientHandler
    {
        private readonly HttpClient _httpClient;

        public HttpClientHandler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            return await _httpClient.SendAsync(requestMessage);
        }
    }
}