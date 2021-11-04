﻿using Newtonsoft.Json;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Models.Cargo;

namespace NextGenSoftware.OASIS.API.Providers.CargoOASIS.Core.Models.Response
{
    public class GetShowcaseByIdResponseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("createAt")]
        public string CreateAt { get; set; }
        [JsonProperty("public")]
        public bool Public { get; set; }
        [JsonProperty("resellingEnabled")]
        public bool ResellingEnabled { get; set; }
        [JsonProperty("slugId")]
        public string SlugId { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("isOwner")]
        public bool IsOwner { get; set; }
        [JsonProperty("isVendor")]
        public bool IsVendor { get; set; }
        [JsonProperty("owner")]
        public Owner Owner { get; set; }
        
        // [JsonProperty("err")]
        // public bool Error { get; set; }
        //
        // [JsonProperty("status")] 
        // public int Status { get; set; }
        //
        // [JsonProperty("data")]
        // public GetShowcaseByIdResponse Data { get; set; }
    }
}