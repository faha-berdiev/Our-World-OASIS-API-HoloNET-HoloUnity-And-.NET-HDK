﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.ONODE.BLL.Holons;

namespace NextGenSoftware.OASIS.API.ONODE.BLL.Interfaces
{
    public interface ISeedsManager : IOASISManager
    {
        OASISResult<IEnumerable<SeedTransaction>> LoadSeedTransactionsForAvatar(Guid avatarId);
        Task<OASISResult<IEnumerable<SeedTransaction>>> LoadSeedTransactionsForAvatarAsync(Guid avatarId);
        OASISResult<SeedTransaction> SaveSeedTransaction(Guid avatarId, string avatarUserName, int amount, string memo);
        Task<OASISResult<SeedTransaction>> SaveSeedTransactionAsync(Guid avatarId, string avatarUserName, int amount, string memo);
    }
}