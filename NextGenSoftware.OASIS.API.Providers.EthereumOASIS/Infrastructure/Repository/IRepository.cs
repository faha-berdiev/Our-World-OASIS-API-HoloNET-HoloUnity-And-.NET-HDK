using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nethereum.ABI.FunctionEncoding;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task Update(T entity);
        
        Task<T> Get(Guid id);
        Task<T> Get(string providerKey);

        Task<IEnumerable<T>> GetAll();
        
        Task Delete(Guid id);
        Task Delete(string providerKey);
    }
}