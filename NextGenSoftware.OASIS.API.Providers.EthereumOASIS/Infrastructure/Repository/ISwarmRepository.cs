using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository
{
    public interface ISwarmRepository<T>
    {
        Task<T> Get(EntityReference reference);
        Task Delete(EntityReference reference);
    }
}