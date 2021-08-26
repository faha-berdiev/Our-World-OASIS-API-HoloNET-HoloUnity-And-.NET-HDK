using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.Account
{
    public interface IAccountService
    {
        Task<Nethereum.Web3.Accounts.Account> CreateAccount(string password);
    }
}