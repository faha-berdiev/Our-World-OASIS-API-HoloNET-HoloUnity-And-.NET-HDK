using System.Threading.Tasks;
using Nethereum.RPC.Eth;
using Nethereum.Web3;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Factory.ConfigurationProvider;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IConfigurationProvider _configurationProvider;
        private Web3 _web3;
        public AccountService(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public async Task<Nethereum.Web3.Accounts.Account> CreateAccount<T>(T entity)
        {
            await InitializeWeb3();
            
            var address = await _configurationProvider.GetKey("NethereumAddress");
            var nethereumAbi = await _configurationProvider.GetKey("NethereumABI");
            
            var oasisContract = _web3.Eth.GetContract(nethereumAbi, address);
            var newAccountFunction = oasisContract.GetFunction("createAccount");
            var accountContent = await newAccountFunction.CallAsync<string>(entity);
            return new Nethereum.Web3.Accounts.Account(accountContent);
        }

        public async Task<Nethereum.Web3.Accounts.Account> CreateAccount(string password)
        {
            await InitializeWeb3();
            var accountContent = await _web3.Personal.NewAccount.SendRequestAsync(password);
            return new Nethereum.Web3.Accounts.Account(accountContent);
        }

        public async Task LockAccount(string password)
        {
            await InitializeWeb3();
            await _web3.Personal.LockAccount.SendRequestAsync(password);
        }

        public async Task UnLockAccount(EthCoinBase coinBase, string password)
        {
            await InitializeWeb3();
            await _web3.Personal.UnlockAccount.SendRequestAsync(coinBase, password);
        }

        private async Task InitializeWeb3()
        {
            var privateKey = await _configurationProvider.GetKey("NethereumPrivateKey");
            var nethereumHostUri = await _configurationProvider.GetKey("NethereumHostUri");
            var account = new Nethereum.Web3.Accounts.Account(privateKey);
            
            _web3 = new Web3(account, nethereumHostUri);
        }
    }
}