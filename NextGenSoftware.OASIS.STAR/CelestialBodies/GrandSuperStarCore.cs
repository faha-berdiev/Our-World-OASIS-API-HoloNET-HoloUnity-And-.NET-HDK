﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;
using NextGenSoftware.OASIS.STAR.CelestialBodies;
using NextGenSoftware.OASIS.STAR.CelestialSpace;

namespace NextGenSoftware.OASIS.STAR
{
    // At the centre of each Multiverse (creates dimensions, universes, GalaxyClusters, SolarSystems (outside of a Galaxy), Stars (outside of a Galaxy) & Planets (outside of a Galaxy)). Prime Creator
    public class GrandSuperStarCore : CelestialBodyCore, IGrandSuperStarCore
    {
        public IGrandSuperStar GrandSuperStar { get; set; }

        public GrandSuperStarCore(IGrandSuperStar grandSuperStar) : base()
        {
            GrandSuperStar = grandSuperStar;
        }

        public GrandSuperStarCore(IGrandSuperStar grandSuperStar, Dictionary<ProviderType, string> providerKey) : base(providerKey)
        {
            GrandSuperStar = grandSuperStar;
        }

        public GrandSuperStarCore(IGrandSuperStar grandSuperStar, Guid id) : base(id)
        {
            GrandSuperStar = grandSuperStar;
        }

        //public async Task<OASISResult<IUniverse>> AddUniverseToDimensionAsync(IDimension dimension, IUniverse universe)
        //{
        //    return OASISResultHolonToHolonHelper<IHolon, IUniverse>.CopyResult(
        //        await AddHolonToCollectionAsync(GrandSuperStar, universe, (List<IHolon>)Mapper<IUniverse, Holon>.MapBaseHolonProperties(
        //            dimension.Un)), new OASISResult<IUniverse>());
        //}

        //public OASISResult<IUniverse> AddUniverseToDimension(IUniverse universe)
        //{
        //    return AddUniverseAsync(universe).Result;
        //}



        public async Task<OASISResult<IUniverse>> AddParallelUniverseToThirdDimensionAsync(IUniverse universe)
        {
            return OASISResultHolonToHolonHelper<IHolon, IUniverse>.CopyResult(
                await AddHolonToCollectionAsync(GrandSuperStar, universe, (List<IHolon>)Mapper<IUniverse, Holon>.MapBaseHolonProperties(
                    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParallelUniverses)), new OASISResult<IUniverse>());
        }

        public OASISResult<IUniverse> AddParallelUniverseToThirdDimension(IUniverse universe)
        {
            return AddParallelUniverseToThirdDimensionAsync(universe).Result;
        }


        public async Task<OASISResult<IDimension>> AddDimensionToMultiverseAsync(IDimension dimension)
        {
            return OASISResultHolonToHolonHelper<IHolon, IDimension>.CopyResult(
                await AddHolonToCollectionAsync(GrandSuperStar, dimension, (List<IHolon>)Mapper<IDimension, Holon>.MapBaseHolonProperties(
                    GrandSuperStar.ParentMultiverse.Dimensions.CustomDimensions)), new OASISResult<IDimension>());
        }

        public OASISResult<IDimension> AddDimensionToMultiverse(IDimension dimension)
        {
            return AddDimensionToMultiverseAsync(dimension).Result;
        }

        /// <summary>
        /// Create's the ThirdDimension within this Multiverse along with a child MagicVerse and UniversePrime.
        /// </summary>
        /// <returns></returns>
        public async Task<OASISResult<IThirdDimension>> AddThirdDimensionToMultiverseAsync()
        {
            OASISResult<IThirdDimension> result = new OASISResult<IThirdDimension>();

            if (GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.Id != Guid.Empty)
            {
                result.IsError = true;
                result.Message = "The Third Dimension has already been created. It cannot be created again.";
                return result;
            }

            if (GrandSuperStar.ParentMultiverse == null || (GrandSuperStar.ParentMultiverse != null && GrandSuperStar.ParentMultiverse.Id == Guid.Empty))
            {
                result.IsError = true;
                result.Message = "The Multiverse has not been created yet. Please create it first.";
                return result;
            }

            Mapper<IGrandSuperStar, ThirdDimension>.MapParentCelestialBodyProperties(GrandSuperStar, (ThirdDimension)GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension);
            GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParentGrandSuperStar = GrandSuperStar;
            GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParentGrandSuperStarId = GrandSuperStar.Id;

            // Now we need to save the ThirdDimension as a seperate Holon to get a Id.
            OASISResult<IHolon> thirdDimensionResult = await SaveHolonAsync(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension);

            if (!thirdDimensionResult.IsError && thirdDimensionResult.Result != null)
            {
                Mapper<IHolon, ThirdDimension>.MapBaseHolonProperties(thirdDimensionResult.Result, (ThirdDimension)GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension);
                result.Result = GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension;

                Mapper<IGrandSuperStar, Universe>.MapParentCelestialBodyProperties(GrandSuperStar, (Universe)GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.MagicVerse);
                GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.MagicVerse.ParentDimension = GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension;
                GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.MagicVerse.ParentDimensionId = GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.Id;
                GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.MagicVerse.ParentGrandSuperStar = GrandSuperStar;
                GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.MagicVerse.ParentGrandSuperStarId = GrandSuperStar.Id;

                // Now we need to save the MagicVerse as a seperate Holon to get a Id.
                OASISResult<IHolon> magicVerseResult = await SaveHolonAsync(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.MagicVerse);

                if (!magicVerseResult.IsError && magicVerseResult.Result != null)
                {
                    Mapper<IHolon, Universe>.MapBaseHolonProperties(magicVerseResult.Result, (Universe)GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.MagicVerse);

                    Mapper<IGrandSuperStar, Universe>.MapParentCelestialBodyProperties(GrandSuperStar, (Universe)GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.UniversePrime);
                    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.UniversePrime.ParentDimension = GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension;
                    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.UniversePrime.ParentDimensionId = GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.Id;
                    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.UniversePrime.ParentGrandSuperStar = GrandSuperStar;
                    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.UniversePrime.ParentGrandSuperStarId = GrandSuperStar.Id;

                    // Now we need to save the UniversePrime as a seperate Holon to get a Id.
                    OASISResult<IHolon> universePrimeResult = await SaveHolonAsync(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.UniversePrime);

                    if (!universePrimeResult.IsError && universePrimeResult.Result != null)
                    {
                        Mapper<IHolon, Universe>.MapBaseHolonProperties(universePrimeResult.Result, (Universe)GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.UniversePrime);

                        //TODO: Do we need to re-save the new GrandSuperStar so its child holon ids are also saved within the GrandSuperStar holon object in storage?
                        OASISResult<IHolon> grandSuperStarHolonResult = await SaveHolonAsync(GrandSuperStar);

                        if (!grandSuperStarHolonResult.IsError && grandSuperStarHolonResult.Result != null)
                        {
                            Mapper<IHolon, GrandSuperStar>.MapBaseHolonProperties(grandSuperStarHolonResult.Result, (GrandSuperStar)GrandSuperStar);

                            //TODO: Do we need to re-save the multiverse so its child holon ids are also saved within the multiverse holon object in storage?
                            OASISResult<IHolon> multiverseHolonResult = await SaveHolonAsync(GrandSuperStar.ParentMultiverse);
                            
                            if (!multiverseHolonResult.IsError && multiverseHolonResult.Result != null)
                            {
                                Mapper<IHolon, Multiverse>.MapBaseHolonProperties(multiverseHolonResult.Result, (Multiverse)GrandSuperStar.ParentMultiverse);

                                //TODO: Do we need to re-save the new ThirdDimension so its child holon ids are also saved within the ThirdDimension holon object in storage?
                                OASISResult<IHolon> thirdDimensionHolonResult = await SaveHolonAsync(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension);

                                if (!thirdDimensionHolonResult.IsError && thirdDimensionHolonResult.Result != null)
                                    Mapper<IHolon, ThirdDimension>.MapBaseHolonProperties(thirdDimensionHolonResult.Result, (ThirdDimension)GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension);
                                else
                                    OASISResultHolonToHolonHelper<IHolon, IThirdDimension>.CopyResult(thirdDimensionHolonResult, result);
                            }
                            else
                                OASISResultHolonToHolonHelper<IHolon, IThirdDimension>.CopyResult(multiverseHolonResult, result);
                        }
                        else
                            OASISResultHolonToHolonHelper<IHolon, IThirdDimension>.CopyResult(grandSuperStarHolonResult, result);
                    }
                    else
                        OASISResultHolonToHolonHelper<IHolon, IThirdDimension>.CopyResult(universePrimeResult, result);
                }
                else
                    OASISResultHolonToHolonHelper<IHolon, IThirdDimension>.CopyResult(magicVerseResult, result);
            }
            else
                OASISResultHolonToHolonHelper<IHolon, IThirdDimension>.CopyResult(thirdDimensionResult, result);

            return result;
        }

        public OASISResult<IThirdDimension> AddThirdDimensionToMultiverse()
        {
            return AddThirdDimensionToMultiverseAsync().Result;
        }

        //public async Task<OASISResult<IThirdDimension>> AddMagicVerseToThirdDimensionAsync()
        //{
        //    OASISResult<IThirdDimension> result = new OASISResult<IThirdDimension>();

        //    if (GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.Id != Guid.Empty)
        //    {
        //        result.IsError = true;
        //        result.Message = "The Third Dimension has already been created. It cannot be created again.";
        //        return result;
        //    }

        //    if (GrandSuperStar.ParentMultiverse == null || (GrandSuperStar.ParentMultiverse != null && GrandSuperStar.ParentMultiverse.Id == Guid.Empty))
        //    {
        //        result.IsError = true;
        //        result.Message = "The Multiverse Has Not Been Created Yet. Please Create It First.";
        //        return result;
        //    }

        //    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParentOmiverse = GrandSuperStar.ParentMultiverse.ParentOmiverse;
        //    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParentOmiverseId = GrandSuperStar.ParentMultiverse.ParentOmiverseId;
        //    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParentMultiverse = GrandSuperStar.ParentMultiverse;
        //    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParentMultiverseId = GrandSuperStar.ParentMultiverse.Id;
        //    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParentGrandSuperStar = GrandSuperStar;
        //    GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParentGrandSuperStarId = GrandSuperStar.Id;

        //    // Now we need to save the ThirdDimension as a seperate Holon to get a Id.
        //    OASISResult<IHolon> thirdDimensionResult = await SaveHolonAsync(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension);

        //    if (!thirdDimensionResult.IsError && thirdDimensionResult.Result != null)
        //    {
        //        Mapper<IHolon, ThirdDimension>.MapBaseHolonProperties(thirdDimensionResult.Result, (ThirdDimension)GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension);
        //        result.Result = GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension;
        //    }
        //    else
        //    {
        //        result.IsError = true;
        //        result.Message = thirdDimensionResult.Message;
        //    }

        //    return result;
        //}

        //public async Task<OASISResult<IUniverse>> AddUniverseToDimensionAsync(IDimension dimension, IUniverse universe)
        //{
        //    return OASISResultHolonToHolonHelper<IHolon, IUniverse>.CopyResult(
        //        await AddHolonToCollectionAsync(dimension, universe, (List<IHolon>)Mapper<IUniverse, Holon>.MapBaseHolonProperties(
        //            dimension.Universe)), new OASISResult<IUniverse>());
        //}

        //public OASISResult<IUniverse> AddUniverseToDimension(IDimension dimension, IUniverse universe)
        //{
        //    return AddUniverseToDimensionAsync(dimension, universe).Result;
        //}

        /*
        public async Task<OASISResult<IDimension>> AddDimensionToUniverseAsync(IUniverse universe, IDimension dimension)
        {
            return OASISResultHolonToHolonHelper<IHolon, IDimension>.CopyResult(
                await AddHolonToCollectionAsync(universe, dimension, (List<IHolon>)Mapper<IDimension, Holon>.MapBaseHolonProperties(
                    universe.Dimensions)), new OASISResult<IDimension>());
        }

        public OASISResult<IDimension> AddDimensionToUniverse(IUniverse universe, IDimension dimension)
        {
            return AddDimensionToUniverseAsync(universe, dimension).Result;
        }

        public async Task<OASISResult<IGalaxyCluster>> AddGalaxyClusterToDimensionAsync(IDimension dimension, IGalaxyCluster galaxyCluster)
        {
            return OASISResultHolonToHolonHelper<IHolon, IGalaxyCluster>.CopyResult(
               await AddHolonToCollectionAsync(dimension, galaxyCluster, (List<IHolon>)Mapper<IGalaxyCluster, Holon>.MapBaseHolonProperties(
                   dimension.GalaxyClusters)), new OASISResult<IGalaxyCluster>());
        }

        public OASISResult<IGalaxyCluster> AddGalaxyClusterToDimension(IDimension dimension, IGalaxyCluster galaxyCluster)
        {
            return AddGalaxyClusterToDimensionAsync(dimension, galaxyCluster).Result;
        }

        public async Task<OASISResult<ISolarSystem>> AddSolarSystemToDimensionAsync(IDimension dimension, ISolarSystem solarSystem)
        {
            return OASISResultHolonToHolonHelper<IHolon, ISolarSystem>.CopyResult(
                await AddHolonToCollectionAsync(dimension, solarSystem, (List<IHolon>)Mapper<ISolarSystem, Holon>.MapBaseHolonProperties(
                    dimension.SoloarSystems)), new OASISResult<ISolarSystem>());
        }

        public OASISResult<ISolarSystem> AddSolarSystemToDimension(IDimension dimension, ISolarSystem solarSystem)
        {
            return AddSolarSystemToDimensionAsync(dimension, solarSystem).Result;
        }

        public async Task<OASISResult<IStar>> AddStarToDimensionAsync(IDimension dimension, IStar star)
        {
            return OASISResultHolonToHolonHelper<IHolon, IStar>.CopyResult(
                await AddHolonToCollectionAsync(dimension, star, (List<IHolon>)Mapper<IStar, Holon>.MapBaseHolonProperties(
                    dimension.Stars)), new OASISResult<IStar>());
        }

        public OASISResult<IStar> AddStarToDimension(IDimension dimension, IStar star)
        {
            return AddStarToDimensionAsync(dimension, star).Result;
        }

        public async Task<OASISResult<IPlanet>> AddPlanetToDimensionAsync(IDimension dimension, IPlanet planet)
        {
            return OASISResultHolonToHolonHelper<IHolon, IPlanet>.CopyResult(
                await AddHolonToCollectionAsync(dimension, planet, (List<IHolon>)Mapper<IPlanet, Holon>.MapBaseHolonProperties(
                    dimension.Planets)), new OASISResult<IPlanet>());
        }

        public OASISResult<IPlanet> AddPlanetToDimension(IDimension dimension, IPlanet planet)
        {
            return AddPlanetToDimensionAsync(dimension, planet).Result;
        }
        */

        public async Task<OASISResult<IGalaxyCluster>> AddGalaxyClusterToUniverseAsync(IUniverse universe, IGalaxyCluster galaxyCluster)
        {
            return OASISResultHolonToHolonHelper<IHolon, IGalaxyCluster>.CopyResult(
               await AddHolonToCollectionAsync(universe, galaxyCluster, (List<IHolon>)Mapper<IGalaxyCluster, Holon>.MapBaseHolonProperties(
                   universe.GalaxyClusters)), new OASISResult<IGalaxyCluster>());
        }

        public OASISResult<IGalaxyCluster> AddGalaxyClusterToUniverse(IUniverse universe, IGalaxyCluster galaxyCluster)
        {
            return AddGalaxyClusterToUniverseAsync(universe, galaxyCluster).Result;
        }

        public async Task<OASISResult<IGalaxy>> AddGalaxyToGalaxyClusterAsync(IGalaxyCluster galaxyCluster, IGalaxy galaxy)
        {
            OASISResult<IGalaxy> result = new OASISResult<IGalaxy>();

            //return OASISResultHolonToHolonHelper<IHolon, IGalaxy>.CopyResult(
            //    await AddHolonToCollectionAsync(galaxyCluster, galaxy, (List<IHolon>)Mapper<IGalaxy, Holon>.MapBaseHolonProperties(
            //        galaxyCluster.Galaxies)), new OASISResult<IGalaxy>());

            if (galaxyCluster == null)
            {
                result.IsError = true;
                result.Message = "GalaxyCluster cannot be null.";
                return result;
            }

            if (galaxy == null)
            {
                result.IsError = true;
                result.Message = "Galaxy cannot be null.";
                return result;
            }

            galaxy.Id = Guid.NewGuid();
            galaxy.IsNewHolon = true;

            if (galaxy.SuperStar == null)
            {
                galaxy.SuperStar = new SuperStar();
                galaxy.SuperStar.Id = Guid.NewGuid();
                galaxy.SuperStar.IsNewHolon = true;

                Mapper<IHolon, SuperStar>.MapParentCelestialBodyProperties(galaxyCluster, (SuperStar)galaxy.SuperStar);
                //galaxy.SuperStar.ParentOmiverse = galaxyCluster.ParentOmiverse;
                //galaxy.SuperStar.ParentOmiverseId = galaxyCluster.ParentOmiverseId;
                //galaxy.SuperStar.ParentGreatGrandSuperStar = galaxyCluster.ParentGreatGrandSuperStar;
                //galaxy.SuperStar.ParentGreatGrandSuperStarId = galaxyCluster.ParentGreatGrandSuperStarId;
                //galaxy.SuperStar.ParentGrandSuperStar = multiverse.ParentGrandSuperStar;
                //galaxy.SuperStar.ParentGrandSuperStarId = multiverse.ParentGrandSuperStarId;
                //galaxy.SuperStar.ParentMultiverse.ParentMultiverse = galaxyCluster.ParentMultiverse;
                //galaxy.SuperStar.ParentMultiverseId = galaxyCluster.ParentMultiverseId;
                //galaxy.SuperStar.ParentDimension = galaxyCluster.ParentDimension;
                //galaxy.SuperStar.ParentDimensionId = galaxyCluster.ParentDimensionId;
                //galaxy.SuperStar.ParentUniverse = galaxyCluster.ParentUniverse;
                //galaxy.SuperStar.ParentUniverseId = galaxyCluster.ParentUniverseId;

                galaxy.SuperStar.ParentGalaxyCluster = galaxyCluster;
                galaxy.SuperStar.ParentGalaxyClusterId = galaxyCluster.Id;
                galaxy.SuperStar.ParentGalaxy = galaxy;
                galaxy.SuperStar.ParentGalaxyId = galaxy.Id;
            }    

            result = OASISResultHolonToHolonHelper<IHolon, IGalaxy>.CopyResult(
                await AddHolonToCollectionAsync(galaxyCluster, galaxy, (List<IHolon>)Mapper<IGalaxy, Holon>.MapBaseHolonProperties(
                    galaxyCluster.Galaxies)), new OASISResult<IGalaxy>());

            if (!result.IsError && result.Result != null)
            {
                Mapper<IHolon, Galaxy>.MapBaseHolonProperties(result.Result, (Galaxy)galaxy);

                // Now we need to save the SuperStar as a seperate Holon.
                OASISResult<IHolon> superStarResult = await SaveHolonAsync(galaxy.SuperStar);

                if (!superStarResult.IsError && superStarResult.Result != null)
                {
                    Mapper<IHolon, SuperStar>.MapBaseHolonProperties(superStarResult.Result, (SuperStar)galaxy.SuperStar);
                    result.Result = galaxy;
                }
                else
                {
                    result.IsError = true;
                    result.Message = superStarResult.Message;
                }
            }

            return result;
        }

        public OASISResult<IGalaxy> AddGalaxyToGalaxyCluster(IGalaxyCluster galaxyCluster, IGalaxy galaxy)
        {
            return AddGalaxyToGalaxyClusterAsync(galaxyCluster, galaxy).Result;
        }

        public async Task<OASISResult<ISolarSystem>> AddSolarSystemToUniverseAsync(IUniverse universe, ISolarSystem solarSystem)
        {
            return OASISResultHolonToHolonHelper<IHolon, ISolarSystem>.CopyResult(
                await AddHolonToCollectionAsync(universe, solarSystem, (List<IHolon>)Mapper<ISolarSystem, Holon>.MapBaseHolonProperties(
                    universe.SolarSystems)), new OASISResult<ISolarSystem>());
        }

        public OASISResult<ISolarSystem> AddSolarSystemToUniverse(IUniverse universe, ISolarSystem solarSystem)
        {
            return AddSolarSystemToUniverseAsync(universe, solarSystem).Result;
        }

        public async Task<OASISResult<IStar>> AddStarToUniverseAsync(IUniverse universe, IStar star)
        {
            return OASISResultHolonToHolonHelper<IHolon, IStar>.CopyResult(
                await AddHolonToCollectionAsync(universe, star, (List<IHolon>)Mapper<IStar, Holon>.MapBaseHolonProperties(
                    universe.Stars)), new OASISResult<IStar>());
        }

        public OASISResult<IStar> AddStarToUniverse(IUniverse universe, IStar star)
        {
            return AddStarToUniverseAsync(universe, star).Result;
        }

        public async Task<OASISResult<IPlanet>> AddPlanetToUniverseAsync(IUniverse universe, IPlanet planet)
        {
            return OASISResultHolonToHolonHelper<IHolon, IPlanet>.CopyResult(
                await AddHolonToCollectionAsync(universe, planet, (List<IHolon>)Mapper<IPlanet, Holon>.MapBaseHolonProperties(
                    universe.Planets)), new OASISResult<IPlanet>());
        }

        public OASISResult<IPlanet> AddPlanetToUniverse(IUniverse universe, IPlanet planet)
        {
            return AddPlanetToUniverseAsync(universe, planet).Result;
        }

        /*
        public async Task<OASISResult<IEnumerable<IUniverse>>> GetAllUniversesForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IUniverse>> result = new OASISResult<IEnumerable<IUniverse>>();
            
            OASISResult<IEnumerable<IHolon>> holonResult = await GetHolonsAsync(GrandSuperStar.ParentMultiverse.Universes, HolonType.Universe, refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IHolon>, IEnumerable<IUniverse>>.CopyResult(holonResult, ref result);
            result.Result = Mapper<IHolon, Universe>.MapBaseHolonProperties(holonResult.Result);

            return result;
        }

        public OASISResult<IEnumerable<IUniverse>> GetAllUniversesForMultiverse(bool refresh = true)
        {
            return GetAllUniversesForMultiverseAsync(refresh).Result;
        }*/

        public async Task<OASISResult<IEnumerable<IUniverse>>> GetAllUniversesForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IUniverse>> result = new OASISResult<IEnumerable<IUniverse>>();
            List<IUniverse> universes = new List<IUniverse>();

            universes.Add(GrandSuperStar.ParentMultiverse.Dimensions.FirstDimension.Universe);
            universes.Add(GrandSuperStar.ParentMultiverse.Dimensions.SecondDimension.Universe);
            universes.Add(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.UniversePrime);
            universes.Add(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.MagicVerse);
            universes.AddRange(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension.ParallelUniverses);
            universes.Add(GrandSuperStar.ParentMultiverse.Dimensions.FourthDimension.Universe);
            universes.Add(GrandSuperStar.ParentMultiverse.Dimensions.FifthDimension.Universe);
            universes.Add(GrandSuperStar.ParentMultiverse.Dimensions.SixthDimension.Universe);
            universes.Add(GrandSuperStar.ParentMultiverse.Dimensions.SeventhDimension.Universe);

            //TODO: Come back to this...
            //foreach (IDimension dimension in GrandSuperStar.ParentMultiverse.Dimensions.CustomDimensions)
            //    universes.Add(dimension.Universe);

            result.Result = universes;
            return result;
        }

        public OASISResult<IEnumerable<IUniverse>> GetAllUniversesForMultiverse(bool refresh = true)
        {
            return GetAllUniversesForMultiverseAsync(refresh).Result;
        }

        //public async Task<OASISResult<IEnumerable<IDimension>>> GetAllDimensionsForMultiverseAsync(bool refresh = true)
        //{
        //    OASISResult<IEnumerable<IDimension>> result = new OASISResult<IEnumerable<IDimension>>();
        //    OASISResult<IEnumerable<IUniverse>> universesResult = await GetAllUniversesForMultiverseAsync(refresh);
        //    OASISResultCollectionToCollectionHelper<IEnumerable<IUniverse>, IEnumerable<IDimension>>.CopyResult(universesResult, ref result);

        //    if (!universesResult.IsError)
        //    {
        //        List<IDimension> dimensions = new List<IDimension>();

        //        foreach (IUniverse universe in universesResult.Result)
        //            dimensions.AddRange(universe.Dimensions);

        //        result.Result = dimensions;
        //    }

        //    return result;
        //}

        public async Task<OASISResult<IEnumerable<IDimension>>> GetAllDimensionsForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IDimension>> result = new OASISResult<IEnumerable<IDimension>>();
            List<IDimension> dimensions = new List<IDimension>();

            dimensions.Add(GrandSuperStar.ParentMultiverse.Dimensions.FirstDimension);
            dimensions.Add(GrandSuperStar.ParentMultiverse.Dimensions.SecondDimension);
            dimensions.Add(GrandSuperStar.ParentMultiverse.Dimensions.ThirdDimension);
            dimensions.Add(GrandSuperStar.ParentMultiverse.Dimensions.FourthDimension);
            dimensions.Add(GrandSuperStar.ParentMultiverse.Dimensions.FifthDimension);
            dimensions.Add(GrandSuperStar.ParentMultiverse.Dimensions.SixthDimension);
            dimensions.Add(GrandSuperStar.ParentMultiverse.Dimensions.SeventhDimension);
            dimensions.AddRange(GrandSuperStar.ParentMultiverse.Dimensions.CustomDimensions);

            result.Result = dimensions;
            return result;
        }

        public OASISResult<IEnumerable<IDimension>> GetAllDimensionsForMultiverse(bool refresh = true)
        {
            return GetAllDimensionsForMultiverseAsync(refresh).Result;
        }


        //public async Task<OASISResult<IEnumerable<IGalaxyCluster>>> GetAllGalaxyClustersForMultiverseAsync(bool refresh = true)
        //{
        //    OASISResult<IEnumerable<IGalaxyCluster>> result = new OASISResult<IEnumerable<IGalaxyCluster>>();
        //    OASISResult<IEnumerable<IDimension>> dimensionsResult = await GetAllDimensionsForMultiverseAsync(refresh);
        //    OASISResultCollectionToCollectionHelper<IEnumerable<IDimension>, IEnumerable<IGalaxyCluster>>.CopyResult(dimensionsResult, ref result);

        //    if (!dimensionsResult.IsError)
        //    {
        //        List<IGalaxyCluster> clusters = new List<IGalaxyCluster>();

        //        foreach (IDimension dimension in dimensionsResult.Result)
        //            clusters.AddRange(dimension.GalaxyClusters);

        //        result.Result = clusters;
        //    }

        //    return result;
        //}

        public async Task<OASISResult<IEnumerable<IGalaxyCluster>>> GetAllGalaxyClustersForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IGalaxyCluster>> result = new OASISResult<IEnumerable<IGalaxyCluster>>();
            OASISResult<IEnumerable<IUniverse>> universesResult = await GetAllUniversesForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IUniverse>, IEnumerable<IGalaxyCluster>>.CopyResult(universesResult, ref result);

            if (!universesResult.IsError)
            {
                List<IGalaxyCluster> clusters = new List<IGalaxyCluster>();

                foreach (IUniverse universe in universesResult.Result)
                    clusters.AddRange(universe.GalaxyClusters);

                result.Result = clusters;
            }

            return result;
        }

        public OASISResult<IEnumerable<IGalaxyCluster>> GetAllGalaxyClustersForMultiverse(bool refresh = true)
        {
            return GetAllGalaxyClustersForMultiverseAsync(refresh).Result;
        }

        public async Task<OASISResult<IEnumerable<IGalaxy>>> GetAllGalaxiesForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IGalaxy>> result = new OASISResult<IEnumerable<IGalaxy>>();
            OASISResult<IEnumerable<IGalaxyCluster>> galaxyClustersResult = await GetAllGalaxyClustersForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IGalaxyCluster>, IEnumerable<IGalaxy>>.CopyResult(galaxyClustersResult, ref result);

            if (!galaxyClustersResult.IsError)
            {
                List<IGalaxy> galaxies = new List<IGalaxy>();

                foreach (IGalaxyCluster cluster in galaxyClustersResult.Result)
                    galaxies.AddRange(cluster.Galaxies);

                result.Result = galaxies;
            }

            return result;
        }

        public OASISResult<IEnumerable<IGalaxy>> GetAllGalaxiesForMultiverse(bool refresh = true)
        {
            return GetAllGalaxiesForMultiverseAsync(refresh).Result;
        }

        public async Task<OASISResult<IEnumerable<ISuperStar>>> GetAllSuperStarsForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<ISuperStar>> result = new OASISResult<IEnumerable<ISuperStar>>();
            OASISResult<IEnumerable<IGalaxy>> galaxiesResult = await GetAllGalaxiesForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IGalaxy>, IEnumerable<ISuperStar>>.CopyResult(galaxiesResult, ref result);

            if (!galaxiesResult.IsError)
            {
                List<ISuperStar> superstars = new List<ISuperStar>();

                foreach (IGalaxy galaxy in galaxiesResult.Result)
                    superstars.Add(galaxy.SuperStar);

                result.Result = superstars;
            }

            return result;
        }

        public OASISResult<IEnumerable<ISuperStar>> GetAllSuperStarsForMultiverse(bool refresh = true)
        {
            return GetAllSuperStarsForMultiverseAsync(refresh).Result;
        }

        public async Task<OASISResult<IEnumerable<ISolarSystem>>> GetAllSolarSystemsOutSideOfGalaxiesForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<ISolarSystem>> result = new OASISResult<IEnumerable<ISolarSystem>>();
            OASISResult<IEnumerable<IGalaxyCluster>> galaxyClustersResult = await GetAllGalaxyClustersForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IGalaxyCluster>, IEnumerable<ISolarSystem>>.CopyResult(galaxyClustersResult, ref result);

            if (!galaxyClustersResult.IsError)
            {
                List<ISolarSystem> solarSystems = new List<ISolarSystem>();

                foreach (IGalaxyCluster cluster in galaxyClustersResult.Result)
                    solarSystems.AddRange(cluster.SoloarSystems);

                result.Result = solarSystems;
            }

            return result;
        }

        public OASISResult<IEnumerable<ISolarSystem>> GetAllSolarSystemsOutSideOfGalaxiesForMultiverse(bool refresh = true)
        {
            return GetAllSolarSystemsOutSideOfGalaxiesForMultiverseAsync(refresh).Result;
        }

        //public async Task<OASISResult<IEnumerable<ISolarSystem>>> GetAllSolarSystemsOutSideOfGalaxyClustersForMultiverseAsync(bool refresh = true)
        //{
        //    OASISResult<IEnumerable<ISolarSystem>> result = new OASISResult<IEnumerable<ISolarSystem>>();
        //    OASISResult<IEnumerable<IDimension>> dimensionsResult = await GetAllDimensionsForMultiverseAsync(refresh);
        //    OASISResultCollectionToCollectionHelper<IEnumerable<IDimension>, IEnumerable<ISolarSystem>>.CopyResult(dimensionsResult, ref result);

        //    if (!dimensionsResult.IsError)
        //    {
        //        List<ISolarSystem> solarSystems = new List<ISolarSystem>();

        //        foreach (IDimension dimension in dimensionsResult.Result)
        //            solarSystems.AddRange(dimension.SoloarSystems);

        //        result.Result = solarSystems;
        //    }

        //    return result;
        //}

        public async Task<OASISResult<IEnumerable<ISolarSystem>>> GetAllSolarSystemsOutSideOfGalaxyClustersForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<ISolarSystem>> result = new OASISResult<IEnumerable<ISolarSystem>>();
            OASISResult<IEnumerable<IUniverse>> universesResult = await GetAllUniversesForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IUniverse>, IEnumerable<ISolarSystem>>.CopyResult(universesResult, ref result);

            if (!universesResult.IsError)
            {
                List<ISolarSystem> solarSystems = new List<ISolarSystem>();

                foreach (IUniverse universe in universesResult.Result)
                    solarSystems.AddRange(universe.SolarSystems);

                result.Result = solarSystems;
            }

            return result;
        }

        public OASISResult<IEnumerable<ISolarSystem>> GetAllSolarSystemsOutSideOfGalaxyClustersForMultiverse(bool refresh = true)
        {
            return GetAllSolarSystemsOutSideOfGalaxyClustersForMultiverseAsync(refresh).Result;
        }


        public async Task<OASISResult<IEnumerable<ISolarSystem>>> GetAllSolarSystemsForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<ISolarSystem>> result = new OASISResult<IEnumerable<ISolarSystem>>();
            OASISResult<IEnumerable<IGalaxy>> galaxiesResult = await GetAllGalaxiesForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IGalaxy>, IEnumerable<ISolarSystem>>.CopyResult(galaxiesResult, ref result);
            List<ISolarSystem> solarSystems = new List<ISolarSystem>();

            if (!galaxiesResult.IsError)
            {
                foreach (IGalaxy galaxy in galaxiesResult.Result)
                    solarSystems.AddRange(galaxy.SolarSystems);

                result.Result = solarSystems;
            }

            OASISResult<IEnumerable<ISolarSystem>> solarSystemsOutsideResult = await GetAllSolarSystemsOutSideOfGalaxyClustersForMultiverseAsync(refresh);

            if (!solarSystemsOutsideResult.IsError)
                solarSystems.AddRange(solarSystemsOutsideResult.Result);

            solarSystemsOutsideResult = await GetAllSolarSystemsOutSideOfGalaxiesForMultiverseAsync(refresh);

            if (!solarSystemsOutsideResult.IsError)
                solarSystems.AddRange(solarSystemsOutsideResult.Result);

            result.Result = solarSystems;
            return result;
        }

        public OASISResult<IEnumerable<ISolarSystem>> GetAllSolarSystemsForMultiverse(bool refresh = true)
        {
            return GetAllSolarSystemsForMultiverseAsync(refresh).Result;
        }

        public async Task<OASISResult<IEnumerable<IStar>>> GetAllStarsOutSideOfGalaxiesForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IStar>> result = new OASISResult<IEnumerable<IStar>>();
            OASISResult<IEnumerable<IGalaxyCluster>> galaxyClustersResult = await GetAllGalaxyClustersForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IGalaxyCluster>, IEnumerable<IStar>>.CopyResult(galaxyClustersResult, ref result);

            if (!galaxyClustersResult.IsError)
            {
                List<IStar> stars = new List<IStar>();

                foreach (IGalaxyCluster cluster in galaxyClustersResult.Result)
                    stars.AddRange(cluster.Stars);

                result.Result = stars;
            }

            return result;
        }

        public OASISResult<IEnumerable<IStar>> GetAllStarsOutSideOfGalaxiesForMultiverse(bool refresh = true)
        {
            return GetAllStarsOutSideOfGalaxiesForMultiverseAsync(refresh).Result;
        }

        //public async Task<OASISResult<IEnumerable<IStar>>> GetAllStarsOutSideOfGalaxyClustersForMultiverseAsync(bool refresh = true)
        //{
        //    OASISResult<IEnumerable<IStar>> result = new OASISResult<IEnumerable<IStar>>();
        //    OASISResult<IEnumerable<IDimension>> dimensionsResult = await GetAllDimensionsForMultiverseAsync(refresh);
        //    OASISResultCollectionToCollectionHelper<IEnumerable<IDimension>, IEnumerable<IStar>>.CopyResult(dimensionsResult, ref result);

        //    if (!dimensionsResult.IsError)
        //    {
        //        List<IStar> stars = new List<IStar>();

        //        foreach (IDimension dimension in dimensionsResult.Result)
        //            stars.AddRange(dimension.Stars);

        //        result.Result = stars;
        //    }

        //    return result;
        //}

        public async Task<OASISResult<IEnumerable<IStar>>> GetAllStarsOutSideOfGalaxyClustersForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IStar>> result = new OASISResult<IEnumerable<IStar>>();
            OASISResult<IEnumerable<IUniverse>> universesResult = await GetAllUniversesForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IUniverse>, IEnumerable<IStar>>.CopyResult(universesResult, ref result);

            if (!universesResult.IsError)
            {
                List<IStar> stars = new List<IStar>();

                foreach (IUniverse universe in universesResult.Result)
                    stars.AddRange(universe.Stars);

                result.Result = stars;
            }

            return result;
        }

        public OASISResult<IEnumerable<IStar>> GetAllStarsOutSideOfGalaxyClustersForMultiverse(bool refresh = true)
        {
            return GetAllStarsOutSideOfGalaxyClustersForMultiverseAsync(refresh).Result;
        }


        public async Task<OASISResult<IEnumerable<IStar>>> GetAllStarsForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IStar>> result = new OASISResult<IEnumerable<IStar>>();
            OASISResult<IEnumerable<ISuperStar>> superStarsResult = await GetAllSuperStarsForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<ISuperStar>, IEnumerable<IStar>>.CopyResult(superStarsResult, ref result);
            List<IStar> stars = new List<IStar>();

            if (!superStarsResult.IsError)
            {
                foreach (ISuperStar superStar in superStarsResult.Result)
                {
                    OASISResult<IEnumerable<IStar>> starsResult = await ((ISuperStarCore)superStar.CelestialBodyCore).GetAllStarsForGalaxyAsync(refresh);

                    if (!starsResult.IsError)
                        stars.AddRange(starsResult.Result);
                }
            }

            OASISResult<IEnumerable<IStar>> starsOutsideResult = await GetAllStarsOutSideOfGalaxyClustersForMultiverseAsync(refresh);

            if (!starsOutsideResult.IsError)
                stars.AddRange(starsOutsideResult.Result);

            starsOutsideResult = await GetAllStarsOutSideOfGalaxiesForMultiverseAsync(refresh);

            if (!starsOutsideResult.IsError)
                stars.AddRange(starsOutsideResult.Result);

            result.Result = stars;
            return result;
        }

        public OASISResult<IEnumerable<IStar>> GetAllStarsForMultiverse(bool refresh = true)
        {
            return GetAllStarsForMultiverseAsync(refresh).Result;
        }

        public async Task<OASISResult<IEnumerable<IPlanet>>> GetAllPlanetsOutSideOfGalaxiesForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IPlanet>> result = new OASISResult<IEnumerable<IPlanet>>();
            OASISResult<IEnumerable<IGalaxyCluster>> galaxyClustersResult = await GetAllGalaxyClustersForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IGalaxyCluster>, IEnumerable<IPlanet>>.CopyResult(galaxyClustersResult, ref result);

            if (!galaxyClustersResult.IsError)
            {
                List<IPlanet> planets = new List<IPlanet>();

                foreach (IGalaxyCluster cluster in galaxyClustersResult.Result)
                    planets.AddRange(cluster.Planets);

                result.Result = planets;
            }

            return result;
        }

        public OASISResult<IEnumerable<IPlanet>> GetAllPlanetsOutSideOfGalaxiesForMultiverse(bool refresh = true)
        {
            return GetAllPlanetsOutSideOfGalaxiesForMultiverseAsync(refresh).Result;
        }
        /*
        public async Task<OASISResult<IEnumerable<IPlanet>>> GetAllPlanetsOutSideOfGalaxyClustersForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IPlanet>> result = new OASISResult<IEnumerable<IPlanet>>();
            OASISResult<IEnumerable<IDimension>> dimensionsResult = await GetAllDimensionsForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IDimension>, IEnumerable<IPlanet>>.CopyResult(dimensionsResult, ref result);

            if (!dimensionsResult.IsError)
            {
                List<IPlanet> planets = new List<IPlanet>();

                foreach (IDimension dimension in dimensionsResult.Result)
                    planets.AddRange(dimension.Planets);

                result.Result = planets;
            }

            return result;
        }*/

        public async Task<OASISResult<IEnumerable<IPlanet>>> GetAllPlanetsOutSideOfGalaxyClustersForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IPlanet>> result = new OASISResult<IEnumerable<IPlanet>>();
            OASISResult<IEnumerable<IUniverse>> universesResult = await GetAllUniversesForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IUniverse>, IEnumerable<IPlanet>>.CopyResult(universesResult, ref result);

            if (!universesResult.IsError)
            {
                List<IPlanet> planets = new List<IPlanet>();

                foreach (IUniverse universe in universesResult.Result)
                    planets.AddRange(universe.Planets);

                result.Result = planets;
            }

            return result;
        }

        public OASISResult<IEnumerable<IPlanet>> GetAllPlanetsOutSideOfGalaxyClustersForMultiverse(bool refresh = true)
        {
            return GetAllPlanetsOutSideOfGalaxyClustersForMultiverseAsync(refresh).Result;
        }

        public async Task<OASISResult<IEnumerable<IPlanet>>> GetAllPlanetsForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IPlanet>> result = new OASISResult<IEnumerable<IPlanet>>();
            OASISResult<IEnumerable<ISuperStar>> superStarsResult = await GetAllSuperStarsForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<ISuperStar>, IEnumerable<IPlanet>>.CopyResult(superStarsResult, ref result);
            List<IPlanet> planets = new List<IPlanet>();

            if (!superStarsResult.IsError)
            {
                foreach (ISuperStar superStar in superStarsResult.Result)
                {
                    OASISResult<IEnumerable<IPlanet>> planetsResult = await ((ISuperStarCore)superStar.CelestialBodyCore).GetAllPlanetsForGalaxyAsync(refresh);

                    if (!planetsResult.IsError)
                        planets.AddRange(planetsResult.Result);
                }
            }

            OASISResult<IEnumerable<IPlanet>> planetsOutsideResult = await GetAllPlanetsOutSideOfGalaxyClustersForMultiverseAsync(refresh);

            if (!planetsOutsideResult.IsError)
                planets.AddRange(planetsOutsideResult.Result);

            planetsOutsideResult = await GetAllPlanetsOutSideOfGalaxiesForMultiverseAsync(refresh);

            if (!planetsOutsideResult.IsError)
                planets.AddRange(planetsOutsideResult.Result);

            result.Result = planets;
            return result;
        }

        public OASISResult<IEnumerable<IPlanet>> GetAllPlanetsForMultiverse(bool refresh = true)
        {
            return GetAllPlanetsForMultiverseAsync(refresh).Result;
        }


        /*
        public async Task<OASISResult<IEnumerable<IPlanet>>> GetAllPlanetsForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IPlanet>> result = new OASISResult<IEnumerable<IPlanet>>();
            OASISResult<IEnumerable<IStar>> starsResult = await GetAllStarsForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IStar>, IEnumerable<IPlanet>>.CopyResult(starsResult, ref result);

            if (!starsResult.IsError)
            {
                List<IPlanet> planets = new List<IPlanet>();

                foreach (IStar star in starsResult.Result)
                {
                    OASISResult<IEnumerable<IPlanet>> planetsResult = await ((IStarCore)star.CelestialBodyCore).GetAllPlanetsForSolarSystemAsync(refresh);

                    if (!planetsResult.IsError)
                        planets.AddRange(planetsResult.Result);
                }

                result.Result = planets;
            }

            return result;
        }

        public OASISResult<IEnumerable<IPlanet>> GetAllPlanetsForMultiverse(bool refresh = true)
        {
            return GetAllPlanetsForMultiverseAsync(refresh).Result;
        }*/

        public async Task<OASISResult<IEnumerable<IMoon>>> GetAllMoonsForMultiverseAsync(bool refresh = true)
        {
            OASISResult<IEnumerable<IMoon>> result = new OASISResult<IEnumerable<IMoon>>();
            OASISResult<IEnumerable<IPlanet>> planetsResult = await GetAllPlanetsForMultiverseAsync(refresh);
            OASISResultCollectionToCollectionHelper<IEnumerable<IPlanet>, IEnumerable<IMoon>>.CopyResult(planetsResult, ref result);

            if (!planetsResult.IsError)
            {
                List<IMoon> moons = new List<IMoon>();

                foreach (IPlanet planet in planetsResult.Result)
                {
                    OASISResult<IEnumerable<IMoon>> moonsResult = await ((IPlanetCore)planet.CelestialBodyCore).GetMoonsAsync(refresh);

                    if (!moonsResult.IsError)
                        moons.AddRange(moonsResult.Result);
                }

                result.Result = moons;
            }

            return result;
        }

        public OASISResult<IEnumerable<IMoon>> GetAllMoonsForMultiverse(bool refresh = true)
        {
            return GetAllMoonsForMultiverseAsync(refresh).Result;
        }
    }
}