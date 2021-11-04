using System.Collections.Generic;
using Newtonsoft.Json;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Models.Cargo;

namespace NextGenSoftware.OASIS.API.Providers.CargoOASIS.Core.Models.Response
{
    public class GetResaleItemsResponseModel
    {
        [JsonProperty("limit")]
        public string Limit { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("totalPages")] 
        public string TotalPages { get; set; }

        [JsonProperty("results")] 
        public IEnumerable<ResaleItemV3> Results { get; set; }
        
        //
        // public class GetResaleItemData
        // {
        //     [JsonProperty("limit")]
        //     public string Limit { get; set; }
        //
        //     [JsonProperty("page")]
        //     public string Page { get; set; }
        //
        //     [JsonProperty("totalPages")] 
        //     public string TotalPages { get; set; }
        //
        //     [JsonProperty("results")] 
        //     public IEnumerable<ResaleItemV3> Results { get; set; }
        // }
        //
        // [JsonProperty("err")]
        // public bool Error { get; set; }
        //
        // [JsonProperty("status")] 
        // public int Status { get; set; }
        //
        // [JsonProperty("data")]
        // public GetResaleItemData Data { get; set; }
    }
}