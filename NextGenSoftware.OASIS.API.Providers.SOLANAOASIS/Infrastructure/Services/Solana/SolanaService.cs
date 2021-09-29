﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Enums;
using NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Models.Common;
using NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Models.Requests;
using NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Models.Responses;
using NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Services.Base;
using Solnet.Extensions;
using Solnet.Extensions.TokenMint;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Serum;
using Solnet.Wallet;
using Solnet.Wallet.Bip39;
using ClientFactory = Solnet.Rpc.ClientFactory;

namespace NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Services.Solana
{
    public class SolanaService : IBaseService, ISolanaService
    {
        private Wallet _wallet;
        private IRpcClient _rpcClient;

        public SolanaService()
        {
            InitializeService();
        }

        public async Task<Response<ExchangeTokenResult>> ExchangeTokens(ExchangeTokenRequest exchangeTokenRequest)
        {
            var response = new Response<ExchangeTokenResult>();
            var blockHash = await _rpcClient.GetRecentBlockHashAsync();
            var mintAccount = _wallet.GetAccount(exchangeTokenRequest.MintAccountIndex);
            var fromAccount = _wallet.GetAccount(exchangeTokenRequest.FromAccountIndex);
            var toAccount = _wallet.GetAccount(exchangeTokenRequest.ToAccountIndex);

            var tx = new TransactionBuilder().
                SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                SetFeePayer(fromAccount).
                AddInstruction(TokenProgram.InitializeAccount(
                    toAccount.PublicKey,
                    mintAccount.PublicKey,
                    fromAccount.PublicKey)).
                AddInstruction(TokenProgram.Transfer(
                    fromAccount.PublicKey,
                    toAccount.PublicKey,
                    exchangeTokenRequest.Amount,
                    fromAccount)).
                AddInstruction(MemoProgram.NewMemo(fromAccount, exchangeTokenRequest.MemoText)).
                Build(new List<Account>{ fromAccount, toAccount });
            
            var sendTransactionResult = await _rpcClient.SendTransactionAsync(tx);
            if (!sendTransactionResult.WasSuccessful)
            {
                response.Code = (int)sendTransactionResult.HttpStatusCode;
                response.Message = sendTransactionResult.Reason;
            }
            response.Payload = new ExchangeTokenResult(sendTransactionResult.Result);
            return response;
        }
        
        public async Task<Response<MintNftResult>> MintNft(MintNftRequest mintNftRequest)
        {
            var response = new Response<MintNftResult>();
            
            var blockHash = await _rpcClient.GetRecentBlockHashAsync();
            var minBalanceForExemptionAcc = (await _rpcClient.GetMinimumBalanceForRentExemptionAsync(TokenProgram.TokenAccountDataSize)).Result;
            var minBalanceForExemptionMint =(await _rpcClient.GetMinimumBalanceForRentExemptionAsync(TokenProgram.MintAccountDataSize)).Result;

            var mintAccount = _wallet.GetAccount(mintNftRequest.MintAccountIndex);
            var ownerAccount = _wallet.GetAccount(mintNftRequest.FromAccountIndex);
            var initialAccount = _wallet.GetAccount(mintNftRequest.ToAccountIndex);

            var tx = new TransactionBuilder().
                SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                SetFeePayer(ownerAccount).
                AddInstruction(SystemProgram.CreateAccount(
                    ownerAccount,
                    mintAccount,
                    minBalanceForExemptionMint,
                    TokenProgram.MintAccountDataSize,
                    TokenProgram.ProgramIdKey)).
                AddInstruction(TokenProgram.InitializeMint(
                    mintAccount.PublicKey,
                    mintNftRequest.MintDecimals,
                    ownerAccount.PublicKey,
                    ownerAccount.PublicKey)).
                AddInstruction(SystemProgram.CreateAccount(
                    ownerAccount,
                    initialAccount,
                    minBalanceForExemptionAcc,
                    TokenProgram.TokenAccountDataSize,
                    TokenProgram.ProgramIdKey)).
                AddInstruction(TokenProgram.InitializeAccount(
                    initialAccount.PublicKey,
                    mintAccount.PublicKey,
                    ownerAccount.PublicKey)).
                AddInstruction(TokenProgram.MintTo(
                    mintAccount.PublicKey,
                    initialAccount.PublicKey,
                    mintNftRequest.Amount,
                    ownerAccount)).
                AddInstruction(MemoProgram.NewMemo(initialAccount, mintNftRequest.MemoText)).
                Build(new List<Account>{ ownerAccount, mintAccount, initialAccount });
            
            var sendTransactionResult = await _rpcClient.SendTransactionAsync(tx);
            if (!sendTransactionResult.WasSuccessful)
            {
                response.Code = (int)sendTransactionResult.HttpStatusCode;
                response.Message = sendTransactionResult.Reason;
            }
            response.Payload = new MintNftResult(sendTransactionResult.Result);
            return response;
        }

        public async Task<Response<SendTransactionResult>> SendTransaction(SendTransactionRequest sendTransactionRequest)
        {
            var response = new Response<SendTransactionResult>();
            var fromAccount = _wallet.GetAccount(sendTransactionRequest.FromAccountIndex);
            var toAccount = _wallet.GetAccount(sendTransactionRequest.ToAccountIndex);
            var blockHash = await _rpcClient.GetRecentBlockHashAsync();

            var tx = new TransactionBuilder().
                SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                SetFeePayer(fromAccount).
                AddInstruction(MemoProgram.NewMemo(fromAccount, sendTransactionRequest.MemoText)).
                AddInstruction(SystemProgram.Transfer(fromAccount, toAccount.PublicKey, sendTransactionRequest.Lampposts)).
                Build(fromAccount);

            var sendTransactionResult = await _rpcClient.SendTransactionAsync(tx);
            if (!sendTransactionResult.WasSuccessful)
            {
                response.Code = (int)sendTransactionResult.HttpStatusCode;
                response.Message = sendTransactionResult.Reason;
            }
            response.Payload = new SendTransactionResult(sendTransactionResult.Result);
            return response;
        }

        public async Task<Response<GetNftMetadataResult>> GetNftMetadata(GetNftMetadataRequest getNftMetadataRequest)
        {
            var response = new Response<GetNftMetadataResult>();
            try
            {
                var ownerAccount = _wallet.GetAccount(getNftMetadataRequest.OwnerAccount);
                var tokens = new TokenMintResolver();
                
                tokens.Add(new TokenDef(getNftMetadataRequest.MintToken, getNftMetadataRequest.MintName, getNftMetadataRequest.MintSymbol, getNftMetadataRequest.MintDecimal));
                var tokenWallet = await TokenWallet.LoadAsync(_rpcClient, tokens, ownerAccount);
                var sublist = tokenWallet.TokenAccounts().WithSymbol(getNftMetadataRequest.MintSymbol).WithMint(getNftMetadataRequest.MintToken);
            
                response.Payload = new GetNftMetadataResult()
                {
                    Count = sublist.Count(),
                    Accounts = sublist
                };
            }
            catch (Exception e)
            {
                response.Code = (int) ResponseStatus.Successfully;
                response.Message = ResponseStatusConstants.Failed;
            }
            return response;
        }

        public async Task<Response<GetNftWalletResult>> GetNftWallet(GetNftWalletRequest getNftWalletRequest)
        {
            var response = new Response<GetNftWalletResult>();
            try
            {
                var ownerAccount = _wallet.GetAccount(getNftWalletRequest.OwnerAccount);

                var tokens = new TokenMintResolver();
                tokens.Add(new TokenDef(getNftWalletRequest.MintToken, getNftWalletRequest.MintName, getNftWalletRequest.MintSymbol, getNftWalletRequest.MintDecimal));

                var tokenWallet = await TokenWallet.LoadAsync(_rpcClient, tokens, ownerAccount);
                var balances = tokenWallet.Balances();
                var sublist = tokenWallet.TokenAccounts().WithSymbol(getNftWalletRequest.MintSymbol).WithMint(getNftWalletRequest.MintToken);
            
                response.Payload = new GetNftWalletResult()
                {
                    Accounts = sublist,
                    Balances = balances
                };
            }
            catch (Exception e)
            {
                response.Code = (int) ResponseStatus.Successfully;
                response.Message = ResponseStatusConstants.Failed;
            }
            return response;
        }

        public void InitializeService()
        {
            _wallet = new Wallet(new Mnemonic(WordList.English, WordCount.Twelve));
            _rpcClient = ClientFactory.GetClient(Cluster.MainNet);
        }
    }
}