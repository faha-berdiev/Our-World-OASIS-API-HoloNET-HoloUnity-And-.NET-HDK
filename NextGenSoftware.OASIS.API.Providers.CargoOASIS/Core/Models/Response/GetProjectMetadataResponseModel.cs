using System.Collections.Generic;

namespace NextGenSoftware.OASIS.API.Providers.CargoOASIS.Core.Models.Response
{
    public class GetProjectMetadataResponseModel
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public bool SupportsMetadata { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public bool IsOwned { get; set; }
        public string Owner { get; set; }
        public string TotalSupply { get; set; }
        public string Id { get; set; }
        
        // [JsonProperty("err")]
        // public bool Error { get; set; }
        //
        // [JsonProperty("status")] 
        // public int Status { get; set; }
        //
        // [JsonProperty("data")]
        // public ContractMetadata Data { get; set; }
    }
}