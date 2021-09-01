using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Enums;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Factory.ConfigurationProvider;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Common;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityStreamer
{
    public sealed class EntityStreamer : IEntityStreamer
    {
        private readonly HttpClient _httpClient;
        private readonly IConfigurationProvider _configuration;
        
        public EntityStreamer()
        {
            _httpClient = new HttpClient();
            _configuration = ConfigurationFactory.GetLocalStorageConfigurationProvider();
        }
        
        public async Task<Response<EntityContent>> Download(EntityReference reference)
        {
            var response = new Response<EntityContent>();
            try
            {
                var baseAddress = await _configuration.GetKey("SwarmHostAddress");
                _httpClient.BaseAddress = new Uri(baseAddress);

                var url = $"{_httpClient.BaseAddress}bzz/{reference.Reference}";
                
                var httpRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url)
                };
                var httpResponse = await _httpClient.SendAsync(httpRequest);
                response.Payload = new EntityContent()
                {
                    EntityName = reference.Reference,
                    Content = await httpResponse.Content.ReadAsStringAsync()
                };
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = ResponseStatus.Failed;
                return response;
            }
        }

        public async Task<Response<EntityReference>> Upload(EntityContent entityContent)
        {
            var response = new Response<EntityReference>();
            try
            {
                var baseAddress = await _configuration.GetKey("SwarmHostAddress");
                var swarmBatchId = await _configuration.GetKey("SwarmPostageBatchId");
                var byteArray = Encoding.ASCII.GetBytes(entityContent.Content);
                
                using var content =
                    new MultipartFormDataContent()
                    {
                        {
                            new StreamContent(new MemoryStream(byteArray)), 
                            "file", 
                            entityContent.EntityName
                        }
                    };
                
                _httpClient.BaseAddress = new Uri(baseAddress);
                var httpRequest = new HttpRequestMessage()
                {
                    Content = new MultipartContent(),
                    Headers = { {"Swarm-Postage-Batch-Id", swarmBatchId} },
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(_httpClient.BaseAddress + "bzz")
                };
                var httpResponse = await _httpClient.SendAsync(httpRequest);
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                response.Payload =
                    JsonConvert.DeserializeObject<EntityReference>(responseContent);
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Status = ResponseStatus.Failed;
                return response;
            }
        }
    }
}