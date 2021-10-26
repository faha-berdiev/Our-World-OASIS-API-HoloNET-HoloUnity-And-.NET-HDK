﻿using System;
using NextGenSoftware.OASIS.API.Core.Interfaces;

namespace NextGenSoftware.OASIS.API.Core.Objects
{
    public class OlandPurchase : IOlandPurchase
    {
        public Guid Id { get; set; }
        public Guid OlandId { get; set; }
        public Guid AvatarId { get; set; }
        public string AvatarUsername { get; set; }
        public string Tiles { get; set; }
        public string WalletAddress { get; set; }
        public string CargoSaleId { get; set; }
        public string TransactionHash { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSucceedPurchase { get; set; }
    }
}