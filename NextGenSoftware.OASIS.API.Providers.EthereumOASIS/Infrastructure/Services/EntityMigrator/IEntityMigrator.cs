using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Common;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.EntityMigrator;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityMigrator
{
    public interface IEntityMigrator<T> where T : new()
    {
        Task<Response<T>> GetEntity(string entityContent);
        Task<Response<EntityContent>> GetEntityContent(T entity);
    }
}