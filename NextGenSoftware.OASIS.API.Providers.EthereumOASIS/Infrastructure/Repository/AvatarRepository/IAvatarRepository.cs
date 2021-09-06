using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository.AvatarRepository
{
    public interface IAvatarRepository : IRepository<AvatarEntity>, ISwarmRepository<AvatarEntity>
    {
        
    }
}