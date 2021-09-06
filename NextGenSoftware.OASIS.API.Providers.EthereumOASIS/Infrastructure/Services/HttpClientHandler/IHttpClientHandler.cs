using System.Net.Http;
using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.HttpClientHandler
{
    public interface IHttpClientHandler
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage);
    }
}