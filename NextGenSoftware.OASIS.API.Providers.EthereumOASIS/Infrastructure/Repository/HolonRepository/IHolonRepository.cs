using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository.HolonRepository
{
    public interface IHolonRepository : IRepository<HolonEntity>, IEntityRepository<HolonEntity>, ISwarmRepository<HolonEntity>
    {
        
    }
}