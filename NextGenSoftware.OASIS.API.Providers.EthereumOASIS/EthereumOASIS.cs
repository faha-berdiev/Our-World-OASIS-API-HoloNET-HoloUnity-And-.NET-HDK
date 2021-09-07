using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NextGenSoftware.OASIS.API.Core;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository.AvatarRepository;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastructure.Repository.HolonRepository;
using NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS
{
    public class EthereumOasis : OASISStorageBase, IOASISNET, IOASISStorage
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly IHolonRepository _holonRepository;
        private readonly IMapper _mapper;
        
        public EthereumOasis(IMapper mapper, IAvatarRepository avatarRepository, IHolonRepository holonRepository)
        {
            _mapper = mapper;
            _avatarRepository = avatarRepository;
            _holonRepository = holonRepository;
        }
        
        public override async Task<IEnumerable<IAvatar>> LoadAllAvatarsAsync()
        {
            return await _avatarRepository.GetAll();
        }

        public override IAvatar SaveAvatar(IAvatar avatar)
        {
            var avatarEntity = _mapper.Map<AvatarEntity>(avatar);
            Task.Run(async () =>
            {
                await _avatarRepository.Create(avatarEntity);
            });
            return avatar;
        }

        public override async Task<IAvatar> SaveAvatarAsync(IAvatar avatar)
        {
            var avatarEntity = _mapper.Map<AvatarEntity>(avatar);
            await _avatarRepository.Create(avatarEntity);
            return avatar;
        }

        public override bool DeleteAvatar(Guid id, bool softDelete = true)
        {
            Task.Run(async () =>
            {
                await _avatarRepository.Delete(id);
            });
            return true;
        }

        public override async Task<bool> DeleteAvatarAsync(Guid id, bool softDelete = true)
        {
            await _avatarRepository.Delete(id);
            return true;
        }

        public override bool DeleteAvatar(string providerKey, bool softDelete = true)
        {
            Task.Run(async () =>
            {
                await _avatarRepository.Delete(new EntityReference(providerKey));
            });
            return true;
        }

        public override async Task<bool> DeleteAvatarAsync(string providerKey, bool softDelete = true)
        {
            await _avatarRepository.Delete(new EntityReference(providerKey));
            return true;        
        }

        public override async Task<bool> DeleteHolonAsync(string providerKey, bool softDelete = true)
        {
            await _holonRepository.Delete(new EntityReference(providerKey));
            return true;
        }

        public override async Task<ISearchResults> SearchAsync(ISearchParams searchParams)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<IHolon>> SaveHolonsAsync(IEnumerable<IHolon> holons)
        {
            foreach (var holon in holons)
            {
                var holonEntity = _mapper.Map<HolonEntity>(holon);
                await _holonRepository.Create(holonEntity);
            }
            return holons;
        }

        public override bool DeleteHolon(Guid id, bool softDelete = true)
        {
            Task.Run(async () =>
            {
                await _holonRepository.Delete(id);
            });
            return true;
        }

        public override async Task<bool> DeleteHolonAsync(Guid id, bool softDelete = true)
        {
            await _holonRepository.Delete(id);
            return true;
        }

        public override bool DeleteHolon(string providerKey, bool softDelete = true)
        {
            Task.Run(async () =>
            {
                await _holonRepository.Delete(new EntityReference(providerKey));
            });
            return true;
        }

        public override IHolon LoadHolon(Guid id)
        {
            IHolon entity = null;
            Task.Run(async () =>
            {
                entity = await _holonRepository.Get(id);
            });
            return entity;
        }

        public override async Task<IHolon> LoadHolonAsync(Guid id)
        {
            return await _holonRepository.Get(id);;
        }

        public override IHolon LoadHolon(string providerKey)
        {
            IHolon entity = null;
            Task.Run(async () =>
            {
                entity = await _holonRepository.Get(new EntityReference(providerKey));
            });
            return entity;
        }

        public override async Task<IHolon> LoadHolonAsync(string providerKey)
        {
            return await _holonRepository.Get(new EntityReference(providerKey));
        }

        public override IEnumerable<IHolon> LoadHolonsForParent(Guid id, HolonType type = HolonType.All)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<IHolon>> LoadHolonsForParentAsync(Guid id, HolonType type = HolonType.All)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IHolon> LoadHolonsForParent(string providerKey, HolonType type = HolonType.All)
        {
            throw new NotImplementedException();
        }

        public override async Task<OASISResult<IEnumerable<IHolon>>> LoadHolonsForParentAsync(string providerKey, HolonType type = HolonType.All)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IHolon> LoadAllHolons(HolonType type = HolonType.All)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<IHolon>> LoadAllHolonsAsync(HolonType type = HolonType.All)
        {
            throw new NotImplementedException();
        }

        public override IHolon SaveHolon(IHolon holon)
        {
            Task.Run(async () =>
            {
                var holonEntity = _mapper.Map<HolonEntity>(holon);
                await _holonRepository.Update(holonEntity);
            });
            return holon;
        }

        public override async Task<IHolon> SaveHolonAsync(IHolon holon)
        {
            var holonEntity = _mapper.Map<HolonEntity>(holon);
            await _holonRepository.Update(holonEntity);
            return holon;
        }

        public override IEnumerable<IHolon> SaveHolons(IEnumerable<IHolon> holons)
        {
            Task.Run(async () =>
            {
                foreach (var holon in holons)
                {
                    var holonEntity = _mapper.Map<HolonEntity>(holon);
                    await _holonRepository.Update(holonEntity);   
                }
            });
            return holons;
        }

        public override async Task<IAvatar> LoadAvatarAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override async Task<IAvatar> LoadAvatarAsync(string username)
        {
            throw new NotImplementedException();
        }

        public override async Task<IAvatar> LoadAvatarForProviderKeyAsync(string providerKey)
        {
            return await _avatarRepository.Get(new EntityReference(providerKey));
        }

        public override IAvatar LoadAvatarForProviderKey(string providerKey)
        {
            IAvatar avatar = null;
            Task.Run(async () =>
            {
                avatar = await _avatarRepository.Get(new EntityReference(providerKey));
            });
            return avatar;
        }

        public override IAvatar LoadAvatar(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override IAvatar LoadAvatar(string username)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IAvatar> LoadAllAvatars()
        {
            throw new NotImplementedException();
        }

        public override async Task<IAvatar> LoadAvatarAsync(Guid id)
        {
            return await _avatarRepository.Get(id);
        }

        public override IAvatar LoadAvatar(Guid id)
        {
            IAvatar avatar = null;
            Task.Run(async () =>
            {
                avatar = await _avatarRepository.Get(id);
            });
            return avatar;
        }

        public IEnumerable<IPlayer> GetPlayersNearMe()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHolon> GetHolonsNearMe(HolonType type)
        {
            throw new NotImplementedException();
        }
    }   
}