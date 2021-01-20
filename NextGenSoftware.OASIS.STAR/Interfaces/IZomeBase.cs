﻿using NextGenSoftware.OASIS.API.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.STAR
{
    public interface IZomeBase : IHolon
    {
        List<Holon> Holons { get; set; }

        event ZomeBase.HolonLoaded OnHolonLoaded;
        event ZomeBase.HolonSaved OnHolonSaved;
        event ZomeBase.HolonsLoaded OnHolonsLoaded;
        event ZomeBase.Initialized OnInitialized;
        event ZomeBase.ZomeError OnZomeError;

        Task<IEnumerable<IHolon>> AddHolon(IHolon holon);
        Task<IHolon> LoadHolonAsync(Guid id, HolonType type = HolonType.Holon);
        Task<IHolon> LoadHolonAsync(string providerKey, HolonType type = HolonType.Holon);
        Task<IEnumerable<IHolon>> LoadHolonsAsync(Guid id, HolonType type = HolonType.Holon);
        Task<IEnumerable<IHolon>> LoadHolonsAsync(string providerKey, HolonType type = HolonType.Holon);
        Task<IEnumerable<IHolon>> RemoveHolon(IHolon holon);
        Task<IHolon> SaveHolonAsync(IHolon savingHolon);
        Task<IEnumerable<IHolon>> SaveHolonsAsync(IEnumerable<IHolon> savingHolons);
    }
}