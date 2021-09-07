using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository
{
    public interface IEntityRepository<T>
    {
        Task<T> Get(Func<T, bool> predicate);
        Task<IEnumerable<T>> GetAll(Func<T, bool> predicate);
    }
}