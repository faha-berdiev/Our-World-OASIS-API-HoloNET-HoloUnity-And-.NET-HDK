﻿using System;
using Microsoft.Azure.Documents;
using NextGenSoftware.OASIS.API.Providers.CosmosOASIS.Entites;
using NextGenSoftware.OASIS.API.Providers.CosmosOASIS.Interfaces;

namespace NextGenSoftware.OASIS.API.Providers.CosmosOASIS.Infrastructure
{
    public class AvatarRepository : CosmosDbRepository<Avatar> , IAvatarRepository
    {
        public AvatarRepository(ICosmosDbClientFactory factory) : base(factory) { }

        public override string CollectionName { get; } = "avatarItems";
        public override string GenerateId(Avatar entity) => $"{Guid.NewGuid()}";
        public override PartitionKey ResolvePartitionKey(string entityId) => new PartitionKey(entityId.Split(':')[0]);
    }
}
