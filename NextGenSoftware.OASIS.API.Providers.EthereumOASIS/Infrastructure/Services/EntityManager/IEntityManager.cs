using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityManager
{
    public interface IEntityManager<T> where T : new ()
    {
        Task<T> Get(EntityReference reference);
        Task<EntityReference> Upload(T entity);
    }
}