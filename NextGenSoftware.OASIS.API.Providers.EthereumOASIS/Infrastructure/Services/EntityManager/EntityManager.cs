using System;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Enums;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityMigrator;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityStreamer;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityManager
{
    public class EntityManager<T> : IEntityManager<T> where T : new()
    {
        private readonly IEntityStreamer _entityStreamer;
        private readonly IEntityMigrator<T> _entityMigrator;

        public EntityManager(IEntityStreamer entityStreamer, IEntityMigrator<T> entityMigrator)
        {
            _entityStreamer = entityStreamer;
            _entityMigrator = entityMigrator;
        }
        
        public async Task<T> Get(EntityReference reference)
        {
            if (reference == null)
                throw new ArgumentNullException();

            var response = await _entityStreamer.Download(reference);
            if (response.Status == ResponseStatus.Failed)
                return new T();
            var entityResponse = await _entityMigrator.GetEntity(response.Payload.Content);
            return entityResponse.Status == ResponseStatus.Failed ? new T() : entityResponse.Payload;
        }

        public async Task<EntityReference> Upload(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException();

            var requestContent = await _entityMigrator.GetEntityContent(entity);
            if (requestContent.Status == ResponseStatus.Failed)
                return null;
            var uploadResponse = await _entityStreamer.Upload(requestContent.Payload);
            return uploadResponse.Status == ResponseStatus.Failed ? null : uploadResponse.Payload;
        }
    }
}