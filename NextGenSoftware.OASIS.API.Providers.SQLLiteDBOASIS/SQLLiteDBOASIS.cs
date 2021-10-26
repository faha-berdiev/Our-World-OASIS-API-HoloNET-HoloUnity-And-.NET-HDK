﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NextGenSoftware.OASIS.API.Core;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.Repositories;

namespace NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS
{
    public class SQLLiteDBOASIS : OASISStorageBase, IOASISStorage, IOASISNET
    {
        private string connectionString;
        private DataContext appDataContext;

        private AvatarRepository avatarRepository;
        private HolonRepository holonRepository;


        public SQLLiteDBOASIS(string connectionString)
        {
            //appDataContext = new DataContext(connectionString);
            appDataContext=new DataContext();

            avatarRepository = new AvatarRepository(appDataContext);
            holonRepository = new HolonRepository(appDataContext);

            this.connectionString=connectionString;

            this.ProviderName = "SQLLiteDBOASIS";
            this.ProviderDescription = "SQLLiteDB Provider";
            this.ProviderType = new EnumValue<ProviderType>(Core.Enums.ProviderType.SQLLiteDBOASIS);
            this.ProviderCategory = new EnumValue<ProviderCategory>(Core.Enums.ProviderCategory.StorageAndNetwork);
        }

        public IEnumerable<IHolon> GetHolonsNearMe(HolonType holonType)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<IPlayer> GetPlayersNearMe()
        {
            throw new NotImplementedException();
        }
        public Task<bool> AddKarmaToAvatarAsync(IAvatar Avatar, int karma)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<IAvatar>> LoadAllAvatarsAsync()
        {
            OASISResult<List<Avatar>> repoResult = await avatarRepository.GetAvatarsAsync();

            return(repoResult.Result);
        }

        public override IEnumerable<IAvatar> LoadAllAvatars()
        {
            OASISResult<List<Avatar>> repoResult = avatarRepository.GetAvatars();

            return repoResult.Result;
        }

        public override IAvatar LoadAvatarByEmail(string avatarEmail)
        {
            OASISResult<Avatar> repoResult = avatarRepository.GetAvatarByEmail(avatarEmail);
            
            return(repoResult.Result);
        }

        public override IAvatar LoadAvatarByUsername(string avatarUsername)
        {
            OASISResult<Avatar> repoResult = avatarRepository.GetAvatar(avatarUsername);
            
            return(repoResult.Result);
        }

        public override async Task<IAvatar> LoadAvatarAsync(string providerKey)
        {
            OASISResult<Avatar> repoResult = await avatarRepository.GetAvatarAsync(providerKey);
            
            return(repoResult.Result);
        }

        public override async Task<IAvatar> LoadAvatarAsync(Guid id)
        {
            OASISResult<Avatar> repoResult = await avatarRepository.GetAvatarAsync(id);
            
            return(repoResult.Result);
        }

        public override async Task<IAvatar> LoadAvatarByEmailAsync(string avatarEmail)
        {
            OASISResult<Avatar> repoResult = await avatarRepository.GetAvatarByEmailAsync(avatarEmail);
            
            return(repoResult.Result);
        }

        public override async Task<IAvatar> LoadAvatarByUsernameAsync(string avatarUsername)
        {
            OASISResult<Avatar> repoResult = await avatarRepository.GetAvatarAsync(avatarUsername);
            
            return(repoResult.Result);
        }

        public override IAvatar LoadAvatar(Guid id)
        {
            OASISResult<Avatar> repoResult = avatarRepository.GetAvatar(id);
            
            return(repoResult.Result);
        }

        public override async Task<IAvatar> LoadAvatarAsync(string username, string password)
        {
            OASISResult<Avatar> repoResult = await avatarRepository.GetAvatarAsync(username, password);
            
            return(repoResult.Result);
        }

        public override IAvatar LoadAvatar(string username, string password)
        {
            OASISResult<Avatar> repoResult = avatarRepository.GetAvatar(username, password);
            
            return(repoResult.Result);
        }

        public override async Task<IAvatar> SaveAvatarAsync(IAvatar avatar)
        {
            OASISResult<Avatar> repoResult = null;

            if(avatar.Id == Guid.Empty){
                repoResult = await avatarRepository.AddAsync((Avatar)avatar);
            }
            else{
                repoResult = await avatarRepository.UpdateAsync((Avatar)avatar);
            }
            return(repoResult.Result);
        }

        //TODO: Move this into Search Reposirary like Avatar is...
        public override async Task<ISearchResults> SearchAsync(ISearchParams searchTerm)
        {
            throw new NotImplementedException();
        }

        public override void ActivateProvider()
        {
            if (appDataContext == null){

                //appDataContext=new DataContext(connectionString);
                appDataContext=new DataContext();
                avatarRepository=new AvatarRepository(appDataContext);
                holonRepository=new HolonRepository(appDataContext);

            }
            base.ActivateProvider();
        }

        public override void DeActivateProvider()
        {
            appDataContext.Database.CloseConnection();
            appDataContext.Dispose();

            appDataContext = null;
            avatarRepository = null;
            holonRepository = null;

            base.DeActivateProvider();
        }

        public override IAvatar SaveAvatar(IAvatar avatar)
        {
            OASISResult<Avatar> repoResult = null;

            if(avatar.Id == Guid.Empty){
                repoResult = avatarRepository.Add((Avatar)avatar);
            }
            else{
                repoResult = avatarRepository.Update((Avatar)avatar);
            }
            return(repoResult.Result);
        }

        public override IAvatar LoadAvatar(string username)
        {
            OASISResult<Avatar> repoResult = avatarRepository.GetAvatar(username);
            
            return(repoResult.Result);
        }

        public override bool DeleteAvatar(Guid id, bool softDelete = true)
        {
            OASISResult<bool> repoResult = avatarRepository.Delete(id,softDelete);
            return(repoResult.Result);
        }

        public override bool DeleteAvatarByEmail(string avatarEmail, bool softDelete = true)
        {
            OASISResult<bool> repoResult = avatarRepository.DeleteByEmail(avatarEmail,softDelete);
            return(repoResult.Result);
        }

        public override bool DeleteAvatarByUsername(string avatarUsername, bool softDelete = true)
        {
            OASISResult<bool> repoResult = avatarRepository.Delete(avatarUsername,softDelete);
            return(repoResult.Result);
        }

        public override async Task<bool> DeleteAvatarAsync(Guid id, bool softDelete = true)
        {
            OASISResult<bool> repoResult = await avatarRepository.DeleteAsync(id, softDelete);
            return(repoResult.Result);
        }

        public override async Task<bool> DeleteAvatarByEmailAsync(string avatarEmail, bool softDelete = true)
        {
            OASISResult<bool> repoResult = await avatarRepository.DeleteAsync(avatarEmail, softDelete);
            return(repoResult.Result);
        }

        public override async Task<bool> DeleteAvatarByUsernameAsync(string avatarUsername, bool softDelete = true)
        {
            OASISResult<bool> repoResult = await avatarRepository.DeleteAsync(avatarUsername, softDelete);
            return(repoResult.Result);
        }


        public override async Task<IAvatar> LoadAvatarForProviderKeyAsync(string providerKey)
        {
            OASISResult<Avatar> repoResult = await avatarRepository.GetAvatarAsync(providerKey);
            
            return(repoResult.Result);
        }

        public override IAvatar LoadAvatarForProviderKey(string providerKey)
        {
            OASISResult<Avatar> repoResult = avatarRepository.GetAvatar(providerKey);
            return(repoResult.Result);
        }

        public override bool DeleteAvatar(string providerKey, bool softDelete = true)
        {
            OASISResult<bool> repoResult = avatarRepository.Delete(providerKey, softDelete);
            return(repoResult.Result);
        }

        public override async Task<bool> DeleteAvatarAsync(string providerKey, bool softDelete = true)
        {
            OASISResult<bool> repoResult = await avatarRepository.DeleteAsync(providerKey, softDelete);
            return(repoResult.Result);
        }

        public override bool DeleteHolon(Guid id, bool softDelete = true)
        {
            OASISResult<bool> repoResult = holonRepository.Delete(id, softDelete);
            return(repoResult.Result);
        }

        public override async Task<bool> DeleteHolonAsync(Guid id, bool softDelete = true)
        {
            OASISResult<bool> repoResult = await holonRepository.DeleteAsync(id, softDelete);
            return(repoResult.Result);
        }

        public override bool DeleteHolon(string providerKey, bool softDelete = true)
        {
            OASISResult<bool> repoResult = holonRepository.Delete(providerKey, softDelete);
            return(repoResult.Result);
        }

        public override async Task<bool> DeleteHolonAsync(string providerKey, bool softDelete = true)
        {
            OASISResult<bool> repoResult = await holonRepository.DeleteAsync(providerKey, softDelete);
            return(repoResult.Result);
        }

        public override IHolon LoadHolon(Guid id)
        {
            OASISResult<Holon> repoResult = holonRepository.GetHolon(id);
            return(repoResult.Result);
        }

        public override async Task<IHolon> LoadHolonAsync(Guid id)
        {
            OASISResult<Holon> repoResult = await holonRepository.GetHolonAsync(id);
            return(repoResult.Result);
        }

        public override IHolon LoadHolon(string providerKey)
        {
            OASISResult<Holon> repoResult = holonRepository.GetHolon(providerKey);
            return(repoResult.Result);
        }

        public override async Task<IHolon> LoadHolonAsync(string providerKey)
        {
            OASISResult<Holon> repoResult = await holonRepository.GetHolonAsync(providerKey);
            return(repoResult.Result);
        }

        public override IEnumerable<IHolon> LoadHolonsForParent(Guid id, HolonType type = HolonType.All)
        {
            OASISResult<IEnumerable<Holon>> repoResult=holonRepository.GetAllHolonsForParent(id, type);
            return(repoResult.Result);
        }

        public override async Task<IEnumerable<IHolon>> LoadHolonsForParentAsync(Guid id, HolonType type = HolonType.All)
        {
            OASISResult<IEnumerable<Holon>> repoResult = await holonRepository.GetAllHolonsForParentAsync(id, type);
            return(repoResult.Result);
        }

        public override IEnumerable<IHolon> LoadHolonsForParent(string providerKey, HolonType type = HolonType.All)
        {
            OASISResult<IEnumerable<Holon>> repoResult=holonRepository.GetAllHolonsForParent(providerKey, type);
            return(repoResult.Result);
        }

        public override async Task<OASISResult<IEnumerable<IHolon>>> LoadHolonsForParentAsync(string providerKey, HolonType type = HolonType.All)
        {
            OASISResult<IEnumerable<IHolon>> result = new OASISResult<IEnumerable<IHolon>>();
            OASISResult<IEnumerable<Holon>> repoResult = await holonRepository.GetAllHolonsForParentAsync(providerKey, type);

            if (repoResult.IsError)
            {
                result.IsError = true;
                result.Message = repoResult.Message;
            }
            else
                result.Result = repoResult.Result;

            return result;
        }

        public override IEnumerable<IHolon> LoadAllHolons(HolonType type = HolonType.All)
        {
            OASISResult<IEnumerable<Holon>> repoResult = holonRepository.GetAllHolons(type);
            return(repoResult.Result);
        }

        public override async Task<IEnumerable<IHolon>> LoadAllHolonsAsync(HolonType type = HolonType.All)
        {
            OASISResult<IEnumerable<Holon>> repoResult = await holonRepository.GetAllHolonsAsync(type);
            return(repoResult.Result);
        }

        public override OASISResult<IHolon> SaveHolon(IHolon holon, bool saveChildrenRecursive = true)
        {
            OASISResult<IHolon> result = holon.IsNewHolon ? holonRepository.Add(holon)
                : holonRepository.Update(holon);

            if (!result.IsError && result.Result != null && saveChildrenRecursive && result.Result.Children != null && result.Result.Children.Count() > 0)
            {
                OASISResult<IEnumerable<IHolon>> saveChildrenResult = SaveHolons(result.Result.Children);

                if (!saveChildrenResult.IsError && saveChildrenResult.Result != null)
                    result.Result.Children = saveChildrenResult.Result;
                else
                {
                    result.IsError = true;
                    result.Message = $"Holon with id {holon.Id} and name {holon.Name} saved but it's children failed to save. Reason: {saveChildrenResult.Message}";
                }
            }

            return result;
        }

        public override async Task<OASISResult<IHolon>> SaveHolonAsync(IHolon holon, bool saveChildrenRecursive = true)
        {
            OASISResult<IHolon> result = holon.IsNewHolon ? holonRepository.Add(holon)
                : holonRepository.Update(holon);

            if (!result.IsError && result.Result != null && saveChildrenRecursive && result.Result.Children != null && result.Result.Children.Count() > 0)
            {
                OASISResult<IEnumerable<IHolon>> saveChildrenResult = await SaveHolonsAsync(result.Result.Children);

                if (!saveChildrenResult.IsError && saveChildrenResult.Result != null)
                    result.Result.Children = saveChildrenResult.Result;
                else
                {
                    result.IsError = true;
                    result.Message = $"Holon with id {holon.Id} and name {holon.Name} saved but it's children failed to save. Reason: {saveChildrenResult.Message}";
                }
            }

            return result;
        }

        public override OASISResult<IEnumerable<IHolon>> SaveHolons(IEnumerable<IHolon> holons, bool saveChildrenRecursive = true)
        {
            OASISResult<IEnumerable<IHolon>> result = new OASISResult<IEnumerable<IHolon>>();
            List<IHolon> savedHolons = new List<IHolon>();

            if (holons.Count() == 0)
            {
                result.Message = "No holons found to save.";
                result.IsWarning = true;
                result.IsSaved = false;
                return result;
            }

            // Recursively save all child holons.
            foreach (IHolon holon in holons)
            {
                OASISResult<IHolon> holonResult = SaveHolon(holon);

                if (!holonResult.IsError && holonResult.Result != null)
                {
                    if (saveChildrenRecursive)
                    {
                        OASISResult<IEnumerable<IHolon>> saveChildrenResult = SaveHolons(holonResult.Result.Children);

                        if (!saveChildrenResult.IsError && saveChildrenResult.Result != null)
                            holonResult.Result.Children = saveChildrenResult.Result;
                        else
                        {
                            result.IsError = true;
                            result.InnerMessages.Add($"Holon with id {holon.Id} and name {holon.Name} saved but it's children failed to save. Reason: {saveChildrenResult.Message}");
                        }
                    }

                    savedHolons.Add(holonResult.Result);
                }
                else
                {
                    result.IsError = true;
                    result.InnerMessages.Add($"Holon with id {holon.Id} and name {holon.Name} faild to save. Reason: {holonResult.Message}");
                }
            }

            if (result.IsError)
                result.Message = "One or more errors occured saving the holons in the SQLLiteOASIS Provider. Please check the InnerMessages property for more infomration.";

            return result;
        }

        public override async Task<OASISResult<IEnumerable<IHolon>>> SaveHolonsAsync(IEnumerable<IHolon> holons, bool saveChildrenRecursive = true)
        {
            OASISResult<IEnumerable<IHolon>> result = new OASISResult<IEnumerable<IHolon>>();
            List<IHolon> savedHolons = new List<IHolon>();

            if (holons.Count() == 0)
            {
                result.Message = "No holons found to save.";
                result.IsWarning = true;
                result.IsSaved = false;
                return result;
            }

            // Recursively save all child holons.
            foreach (IHolon holon in holons)
            {
                OASISResult<IHolon> holonResult = await SaveHolonAsync(holon);

                if (!holonResult.IsError && holonResult.Result != null)
                {
                    if (saveChildrenRecursive)
                    {
                        OASISResult<IEnumerable<IHolon>> saveChildrenResult = await SaveHolonsAsync(holonResult.Result.Children);

                        if (!saveChildrenResult.IsError && saveChildrenResult.Result != null)
                            holonResult.Result.Children = saveChildrenResult.Result;
                        else
                        {
                            result.IsError = true;
                            result.InnerMessages.Add($"Holon with id {holon.Id} and name {holon.Name} saved but it's children failed to save. Reason: {saveChildrenResult.Message}");
                        }
                    }

                    savedHolons.Add(holonResult.Result);
                }
                else
                {
                    result.IsError = true;
                    result.InnerMessages.Add($"Holon with id {holon.Id} and name {holon.Name} faild to save. Reason: {holonResult.Message}");
                }
            }

            if (result.IsError)
                result.Message = "One or more errors occured saving the holons in the SQLLiteOASIS Provider. Please check the InnerMessages property for more infomration.";

            return result;
        }

        public override IAvatarDetail LoadAvatarDetail(Guid id)
        {
            OASISResult<AvatarDetail> repoResult = avatarRepository.GetAvatarDetail(id);
            return(repoResult.Result);
        }

        public override IAvatarDetail LoadAvatarDetailByEmail(string avatarEmail)
        {
            OASISResult<AvatarDetail> repoResult = avatarRepository.GetAvatarDetailByEmail(avatarEmail);
            return(repoResult.Result);
        }

        public override IAvatarDetail LoadAvatarDetailByUsername(string avatarUsername)
        {
            OASISResult<AvatarDetail> repoResult = avatarRepository.GetAvatarDetail(avatarUsername);
            return(repoResult.Result);
        }

        public override async Task<IAvatarDetail> LoadAvatarDetailAsync(Guid id)
        {
            OASISResult<AvatarDetail> repoResult = await avatarRepository.GetAvatarDetailAsync(id);
            return(repoResult.Result);
        }

        public override async Task<IAvatarDetail> LoadAvatarDetailByUsernameAsync(string avatarUsername)
        {
            OASISResult<AvatarDetail> repoResult = await avatarRepository.GetAvatarDetailAsync(avatarUsername);
            return(repoResult.Result);
        }

        public override async Task<IAvatarDetail> LoadAvatarDetailByEmailAsync(string avatarEmail)
        {
            OASISResult<AvatarDetail> repoResult = await avatarRepository.GetAvatarDetailByEmailAsync(avatarEmail);
            return(repoResult.Result);
        }

        public override IEnumerable<IAvatarDetail> LoadAllAvatarDetails()
        {
            OASISResult<IEnumerable<AvatarDetail>> repoResult = avatarRepository.GetAvatarDetails();
            return(repoResult.Result);
        }

        public override async Task<IEnumerable<IAvatarDetail>> LoadAllAvatarDetailsAsync()
        {
            OASISResult<IEnumerable<AvatarDetail>> repoResult = await avatarRepository.GetAvatarDetailsAsync();
            return(repoResult.Result);
        }

        public override IAvatarDetail SaveAvatarDetail(IAvatarDetail avatar)
        {
            OASISResult<AvatarDetail> repoResult = null;
            if(avatar.Id == Guid.Empty){
                repoResult = avatarRepository.Add((AvatarDetail)avatar);
            }
            else{
                repoResult = avatarRepository.Update((AvatarDetail)avatar);
            }
            return(repoResult.Result);
        }

        public override async Task<IAvatarDetail> SaveAvatarDetailAsync(IAvatarDetail avatar)
        {
            OASISResult<AvatarDetail> repoResult = null;
            if(avatar.Id == Guid.Empty){
                repoResult = await avatarRepository.AddAsync((AvatarDetail)avatar);
            }
            else{
                repoResult = await avatarRepository.UpdateAsync((AvatarDetail)avatar);
            }
            return(repoResult.Result);
        }
    }
}
