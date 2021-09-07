using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityManager;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository.AvatarRepository
{
    public class AvatarRepository : IAvatarRepository
    {
        private readonly IEntityManager<AvatarEntity> _entityManager;
        public AvatarRepository(IEntityManager<AvatarEntity> entityManager)
        {
            _entityManager = entityManager;
        }
        
        public async Task Create(AvatarEntity entity)
        {
            await _entityManager.Upload(entity);
        }

        public async Task Update(AvatarEntity entity)
        {
            await _entityManager.Upload(entity);
        }

        public async Task<AvatarEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AvatarEntity> Get(string providerKey)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AvatarEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string providerKey)
        {
            throw new NotImplementedException();
        }

        public async Task<AvatarEntity> Get(EntityReference reference)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(EntityReference reference)
        {
            throw new NotImplementedException();
        }
    }
}