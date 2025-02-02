﻿using System.Collections.Generic;
using System.Threading.Tasks;
using static NextGenSoftware.OASIS.API.Core.Events.Events;
using NextGenSoftware.OASIS.API.Core.Helpers;

namespace NextGenSoftware.OASIS.API.Core.Interfaces.STAR
{
    public interface ICelestialBodyCore : IZome
    {
        //IEnumerable<IHolon> Holons { get; }
        List<IZome> Zomes { get; set; }

        public event ZomeLoaded OnZomeLoaded;
        public event ZomeSaved OnZomeSaved;
        public event ZomeError OnZomeError;
        public event ZomesLoaded OnZomesLoaded;
        public event ZomesSaved OnZomesSaved;
        public event ZomesError OnZomesError;
        public event HolonLoaded OnHolonLoaded;
        public event HolonSaved OnHolonSaved;
        public event HolonError OnHolonError;
        public event HolonsLoaded OnHolonsLoaded;
        public event HolonsSaved OnHolonsSaved;
        public event HolonsError OnHolonsError;

        Task<OASISResult<ICelestialBody>> LoadCelestialBodyAsync(bool loadChildren = true, bool recursive = true, bool continueOnError = true);
        OASISResult<ICelestialBody> LoadCelestialBody(bool loadChildren = true, bool recursive = true, bool continueOnError = true);
        Task<OASISResult<IEnumerable<IZome>>> LoadZomesAsync(bool loadChildren = true, bool recursive = true, bool continueOnError = true);
        OASISResult<IEnumerable<IZome>> LoadZomes(bool loadChildren = true, bool recursive = true, bool continueOnError = true);
        Task<OASISResult<IHolon>> SaveCelestialBodyAsync(IHolon savingHolon, bool saveChildren = true, bool recursive = true, bool continueOnError = true);
        Task<OASISResult<T>> SaveCelestialBodyAsync<T>(IHolon savingHolon, bool saveChildren = true, bool recursive = true, bool continueOnError = true) where T : IHolon, new();
        OASISResult<IHolon> SaveCelestialBody(IHolon savingHolon, bool saveChildren = true, bool recursive = true, bool continueOnError = true);
        OASISResult<T> SaveCelestialBody<T>(IHolon savingHolon, bool saveChildren = true, bool recursive = true, bool continueOnError = true) where T : IHolon, new();
        Task<OASISResult<IEnumerable<IZome>>> SaveZomesAsync(bool saveChildren = true, bool recursive = true, bool continueOnError = true);
        OASISResult<IEnumerable<IZome>> SaveZomes(bool saveChildren = true, bool recursive = true, bool continueOnError = true);
        Task<OASISResult<IZome>> AddZomeAsync(IZome zome, bool saveChildren = true, bool recursive = true, bool continueOnError = true);
        OASISResult<IZome> AddZome(IZome zome, bool saveChildren = true, bool recursive = true, bool continueOnError = true);
        Task<OASISResult<IEnumerable<IZome>>> RemoveZomeAsync(IZome zome);
        OASISResult<IEnumerable<IZome>> RemoveZome(IZome zome);
    }
}