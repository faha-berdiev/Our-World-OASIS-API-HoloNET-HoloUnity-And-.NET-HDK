﻿using MongoDB.Driver;
using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Providers.MongoDBOASIS.Entities;
using Avatar = NextGenSoftware.OASIS.API.Providers.MongoDBOASIS.Entities.Avatar;
using Holon = NextGenSoftware.OASIS.API.Providers.MongoDBOASIS.Entities.Holon;

namespace NextGenSoftware.OASIS.API.Providers.MongoDBOASIS.Repositories
{
    public class MongoDbContext
    {
        public MongoClient MongoClient { get; set; }
        public IMongoDatabase MongoDB { get; set; }

        public MongoDbContext(string connectionString, string dbName)
        {
            MongoClient = new MongoClient(connectionString);
            MongoDB = MongoClient.GetDatabase(dbName);
        }

        public IMongoCollection<AvatarDetail> AvatarDetail => MongoDB.GetCollection<AvatarDetail>("AvatarDetail");
        public IMongoCollection<AvatarThumbnail> AvatarThumbnail => MongoDB.GetCollection<AvatarThumbnail>("AvatarThumbnail");
        public IMongoCollection<Avatar> Avatar => MongoDB.GetCollection<Avatar>("Avatar");
        public IMongoCollection<Holon> Holon => MongoDB.GetCollection<Holon>("Holon");
        public IMongoCollection<SearchData> SearchData => MongoDB.GetCollection<SearchData>("SearchData");
    }
}