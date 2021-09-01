using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Common;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.EntityStreamer
{
    public interface IEntityStreamer
    {
        Task<Response<EntityContent>> Download(EntityReference reference);
        Task<Response<EntityReference>> Upload(EntityContent entityContent);
    }
}