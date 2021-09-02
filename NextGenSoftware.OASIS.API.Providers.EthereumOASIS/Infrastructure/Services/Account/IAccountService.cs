using System.Threading.Tasks;
using Nethereum.RPC.Eth;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.Account
{
    public interface IAccountService
    {
        Task<Nethereum.Web3.Accounts.Account> CreateAccount<T>(T entity);
        Task<Nethereum.Web3.Accounts.Account> CreateAccount(string password);
        Task LockAccount(string password);
        Task UnLockAccount(EthCoinBase coinBase, string password);
    }
}