using System.Threading.Tasks;
using Nethereum.Web3;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly Web3 _web3;
        public AccountService()
        {
            _web3 = new Web3();
        }
        
        public async Task<Nethereum.Web3.Accounts.Account> CreateAccount(string password)
        {
            var accountContent = await _web3.Personal.NewAccount.SendRequestAsync(password);
            return new Nethereum.Web3.Accounts.Account(accountContent);
        }
    }
}