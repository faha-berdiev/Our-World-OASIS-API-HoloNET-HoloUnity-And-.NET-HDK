using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Models.Responses;
using NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Services.Base;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using Solnet.Wallet.Bip39;

namespace NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Repositories
{
    public interface ISolanaRepository<T> where T : class
    {
        Task<SendTransactionResult> Create(T entity);
        Task<SendTransactionResult> Update(T entity);
        Task<SendTransactionResult> Delete(T entity);
        
        Task<T> Get(string publicKey);
    }

    public class AvatarRepository : ISolanaRepository<IAvatar>, IBaseService
    {
        private Wallet _wallet;
        private IRpcClient _rpcClient;

        public AvatarRepository()
        {
            InitializeService();
        }
        
        public async Task<SendTransactionResult> Create(IAvatar entity)
        {
            var blockHash = await _rpcClient.GetRecentBlockHashAsync();

            var entityContent = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entity));
            
            var tx = new TransactionBuilder().
                SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                AddInstruction(new TransactionInstruction()
                {
                    Data = entityContent
                }).
                Build(new Account());

            var sendTransactionResult = await _rpcClient.SendTransactionAsync(tx);
            return new SendTransactionResult(sendTransactionResult.Result);
        }

        public async Task<SendTransactionResult> Update(IAvatar entity)
        {
            var blockHash = await _rpcClient.GetRecentBlockHashAsync();


            entity.PreviousVersionId = entity.Id;
            var entityContent = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entity));
            
            var tx = new TransactionBuilder().
                SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                AddInstruction(new TransactionInstruction()
                {
                    Data = entityContent
                }).
                Build(new Account());

            var sendTransactionResult = await _rpcClient.SendTransactionAsync(tx);
            return new SendTransactionResult(sendTransactionResult.Result);
        }

        public async Task<SendTransactionResult> Delete(IAvatar entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IAvatar> Get(string publicKey)
        {
            throw new System.NotImplementedException();
        }

        public void InitializeService()
        {
            _wallet = new Wallet(new Mnemonic(WordList.English, WordCount.Twelve));
            _rpcClient = ClientFactory.GetClient(Cluster.MainNet);
        }
    }
}