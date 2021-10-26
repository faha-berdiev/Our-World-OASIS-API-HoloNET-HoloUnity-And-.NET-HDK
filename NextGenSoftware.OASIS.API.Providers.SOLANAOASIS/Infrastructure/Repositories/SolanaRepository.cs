﻿using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Types;
using Solnet.Wallet;
using Solnet.Wallet.Bip39;
using Solnet.Wallet.Utilities;

namespace NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Repositories
{
    public class SolanaRepository : ISolanaRepository
    {
        private readonly IRpcClient _rpcClient;
        private readonly Wallet _wallet;

        public SolanaRepository(string mnemonicWords)
        {
            _wallet = new Wallet(mnemonicWords);
            _rpcClient = ClientFactory.GetClient(Cluster.MainNet);
        }

        public async Task<string> CreateAsync<T>(T entity) where T : IHolonBase, new()
        {
            try
            {
                entity.Id = new Guid();
                entity.IsNewHolon = true;
                var account = _wallet.Account;
                var blockHash = await _rpcClient.GetRecentBlockHashAsync();

                var tx = new TransactionBuilder().
                    SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                    SetFeePayer(account).
                    AddInstruction(MemoProgram.NewMemo(account, JsonConvert.SerializeObject(entity))).
                    Build(account);

                var sendTransactionResult = await _rpcClient.SendTransactionAsync(tx);
                return !sendTransactionResult.WasSuccessful ? string.Empty : sendTransactionResult.Result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<string> UpdateAsync<T>(T entity)  where T : IHolonBase, new()
        {
            try
            {
                entity.PreviousVersionId = entity.Id;
                entity.Id = new Guid();
                entity.IsNewHolon = false;
                var account = _wallet.Account;
                var blockHash = await _rpcClient.GetRecentBlockHashAsync();

                var tx = new TransactionBuilder().
                    SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                    SetFeePayer(account).
                    AddInstruction(MemoProgram.NewMemo(account, JsonConvert.SerializeObject(entity))).
                    Build(account);

                var sendTransactionResult = await _rpcClient.SendTransactionAsync(tx);
                return !sendTransactionResult.WasSuccessful ? string.Empty : sendTransactionResult.Result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<string> DeleteAsync<T>(string hash)  where T : IHolonBase, new()
        {
            try
            {
                var transactionData = await _rpcClient.GetTransactionAsync(hash, Commitment.Confirmed);

                if (transactionData.Result == null)
                    return string.Empty;

                if (transactionData.Result.Transaction.Message.Instructions.Length == 0)
                    return string.Empty;
                
                var entityBytes = Encoders.Base58.DecodeData(transactionData.Result.Transaction.Message.Instructions[0].Data);
                var entity = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(entityBytes));
                if (entity == null)
                    return string.Empty;
                
                entity.IsActive = false;
                entity.PreviousVersionId = entity.Id;
                entity.Id = new Guid();
                entity.IsNewHolon = false;
                var account = _wallet.Account;
                var blockHash = await _rpcClient.GetRecentBlockHashAsync();

                var tx = new TransactionBuilder().
                    SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                    SetFeePayer(account).
                    AddInstruction(MemoProgram.NewMemo(account, JsonConvert.SerializeObject(entity))).
                    Build(account);

                var sendTransactionResult = await _rpcClient.SendTransactionAsync(tx);
                return !sendTransactionResult.WasSuccessful ? string.Empty : sendTransactionResult.Result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<T> GetAsync<T>(string hash) where T : IHolonBase, new()
        {
            try
            {
                var transactionData = await _rpcClient.GetTransactionAsync(hash, Commitment.Confirmed);

                if (transactionData.Result == null)
                    return new T();

                if (transactionData.Result.Transaction.Message.Instructions.Length == 0)
                    return new T();
                
                var entityBytes = Encoders.Base58.DecodeData(transactionData.Result.Transaction.Message.Instructions[0].Data);
                var entity = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(entityBytes));
                return entity ?? new T();
            }
            catch
            {
                return new T();
            }
        }

        public string Create<T>(T entity) where T : IHolonBase, new()
        {
            try
            {
                entity.Id = new Guid();
                entity.IsNewHolon = true;
                var account = _wallet.Account;
                var blockHash = _rpcClient.GetRecentBlockHash();

                var tx = new TransactionBuilder().
                    SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                    SetFeePayer(account).
                    AddInstruction(MemoProgram.NewMemo(account, JsonConvert.SerializeObject(entity))).
                    Build(account);

                var sendTransactionResult = _rpcClient.SendTransaction(tx);
                return !sendTransactionResult.WasSuccessful ? string.Empty : sendTransactionResult.Result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string Update<T>(T entity) where T : IHolonBase, new()
        {
            try
            {
                entity.PreviousVersionId = entity.Id;
                entity.Id = new Guid();
                entity.IsNewHolon = false;
                
                var account = _wallet.Account;
                var blockHash = _rpcClient.GetRecentBlockHash();

                var tx = new TransactionBuilder().
                    SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                    SetFeePayer(account).
                    AddInstruction(MemoProgram.NewMemo(account, JsonConvert.SerializeObject(entity))).
                    Build(account);

                var sendTransactionResult = _rpcClient.SendTransaction(tx);
                return !sendTransactionResult.WasSuccessful ? string.Empty : sendTransactionResult.Result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string Delete<T>(string hash) where T : IHolonBase, new()
        {
            try
            {
                var transactionData = _rpcClient.GetTransaction(hash, Commitment.Confirmed);

                if (transactionData.Result == null)
                    return string.Empty;

                if (transactionData.Result.Transaction.Message.Instructions.Length == 0)
                    return string.Empty;
                
                var entityBytes = Encoders.Base58.DecodeData(transactionData.Result.Transaction.Message.Instructions[0].Data);
                var entity = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(entityBytes));
                if (entity == null)
                    return string.Empty;
                entity.IsActive = false;
                entity.PreviousVersionId = entity.Id;
                entity.Id = new Guid();
                entity.IsNewHolon = false;
                var account = _wallet.Account;
                var blockHash = _rpcClient.GetRecentBlockHash();

                var tx = new TransactionBuilder().
                    SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                    SetFeePayer(account).
                    AddInstruction(MemoProgram.NewMemo(account, JsonConvert.SerializeObject(entity))).
                    Build(account);

                var sendTransactionResult = _rpcClient.SendTransaction(tx);
                return !sendTransactionResult.WasSuccessful ? string.Empty : sendTransactionResult.Result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public T Get<T>(string hash) where T : IHolonBase, new()
        {
            try
            {
                var transactionData = _rpcClient.GetTransaction(hash, Commitment.Confirmed);

                if (transactionData.Result == null)
                    return new T();

                if (transactionData.Result.Transaction.Message.Instructions.Length == 0)
                    return new T();
                
                var entityBytes = Encoders.Base58.DecodeData(transactionData.Result.Transaction.Message.Instructions[0].Data);
                var entity = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(entityBytes));
                return entity ?? new T();
            }
            catch
            {
                return new T();
            }
        }
    }
}