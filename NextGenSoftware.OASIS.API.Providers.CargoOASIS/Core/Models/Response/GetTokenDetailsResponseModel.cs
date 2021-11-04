using System.Collections.Generic;
using Newtonsoft.Json;
using NextGenSoftware.OASIS.API.Providers.CargoOASIS.Models.Cargo;

namespace NextGenSoftware.OASIS.API.Providers.CargoOASIS.Core.Models.Response
{
    public class GetTokenDetailsResponseModel
    {
        /// <summary>
        /// Username of owner
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }
        /// <summary>
        /// Address of owner
        /// </summary>
        [JsonProperty("ownerAddress")]
        public string OwnerAddress { get; set; }
        /// <summary>
        /// If this item is for sale, details about sale
        /// </summary>
        [JsonProperty("resaleItem")]
        public ResaleItemV3 ResaleItem { get; set; }
        /// <summary>
        /// Collectible ID
        /// </summary>
        [JsonProperty("tokenId")]
        public string TokenId { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public string TokenUrl { get; set; }
        /// <summary>
        /// Name of collection token belongs to
        /// </summary>
        [JsonProperty("contractName")]
        public string ContractName { get; set; }
        /// <summary>
        /// Symbol of collection token belongs to
        /// </summary>
        [JsonProperty("contractSymbol")]
        public string ContractSymbol { get; set; }
        public string ContractAddress { get; set; }
        
        // [JsonProperty("err")]
        // public bool Error { get; set; }
        //
        // [JsonProperty("status")] 
        // public int Status { get; set; }
        //
        // [JsonProperty("data")]
        // public TokenDetail Data { get; set; }
    }
}