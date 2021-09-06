using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository.HolonRepository
{
    public class HolonRepository : IHolonRepository
    {
        public async Task Create(HolonEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(HolonEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<HolonEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<HolonEntity> Get(string providerKey)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HolonEntity>> GetAll()
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

        public async Task<HolonEntity> Get(EntityReference reference)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(EntityReference reference)
        {
            throw new NotImplementedException();
        }
    }
}