using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Events;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;
using NextGenSoftware.OASIS.API.Core.Objects;

namespace NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.Prototypes{

    public class Comet : Holon, IComet
    {
        public SpaceQuadrantType SpaceQuadrant { get; set; }
        public int SpaceSector { get; set; }
        public float SuperGalacticLatitute { get; set; }
        public float SuperGalacticLongitute { get; set; }
        public float GalacticLatitute { get; set; }
        public float GalacticLongitute { get; set; }
        public float HorizontalLatitute { get; set; }
        public float HorizontalLongitute { get; set; }
        public float EquatorialLatitute { get; set; }
        public float EquatorialLongitute { get; set; }
        public float EclipticLatitute { get; set; }
        public float EclipticLongitute { get; set; }
        public int Size { get; set; }
        public int Radius { get; set; }
        public int Age { get; set; }
        public int Mass { get; set; }
        public int Temperature { get; set; }
        public int Weight { get; set; }
        public int GravitaionalPull { get; set; }
        public int OrbitPositionFromParentStar { get; set; }
        public int CurrentOrbitAngleOfParentStar { get; set; } //Angle between 0 and 360 degrees of how far around the orbit it it of its parent star.
        public int DistanceFromParentStarInMetres { get; set; }
        public int RotationSpeed { get; set; }
        public int TiltAngle { get; set; }
        public int NumberRegisteredAvatars { get; set; }
        public int NunmerActiveAvatars { get; set; }

        public ICelestialBodyCore CelestialBodyCore { get; set; }
        public GenesisType GenesisType { get; set; }
        public bool IsInitialized { get; }
        public List<IMoon> Moons { get; set; } = new List<IMoon>();

        public Comet(){}

        public event Events.HolonLoaded OnHolonLoaded;
        public event Events.HolonSaved OnHolonSaved;
        public event Events.HolonsLoaded OnHolonsLoaded;
        public event Events.Initialized OnInitialized;
        public event Events.ZomeError OnZomeError;
        public event Events.ZomesLoaded OnZomesLoaded;

        public Task<OASISResult<ICelestialBody>> SaveAsync(bool saveChildren = true, bool continueOnError = true)
        {
            throw new NotImplementedException();
        }

        public OASISResult<ICelestialBody> Save(bool saveChildren = true, bool continueOnError = true)
        {
            throw new NotImplementedException();
        }

        public Task<OASISResult<IEnumerable<IZome>>> LoadZomesAsync()
        {
            throw new NotImplementedException();
        }

        public OASISResult<IEnumerable<IZome>> LoadZomes()
        {
            throw new NotImplementedException();
        }

        public Task<OASISResult<ICelestialBody>> LoadCelestialBodyAsync()
        {
            throw new NotImplementedException();
        }

        public OASISResult<ICelestialBody> LoadCelestialBody()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Dim()
        {
            throw new NotImplementedException();
        }

        public void Emit()
        {
            throw new NotImplementedException();
        }

        public void Evolve()
        {
            throw new NotImplementedException();
        }

        public CoronalEjection Flare()
        {
            throw new NotImplementedException();
        }

        public void Love()
        {
            throw new NotImplementedException();
        }

        public void Mutate()
        {
            throw new NotImplementedException();
        }

        public void Radiate()
        {
            throw new NotImplementedException();
        }

        public void Reflect()
        {
            throw new NotImplementedException();
        }

        public void Seed()
        {
            throw new NotImplementedException();
        }

        public void Shine()
        {
            throw new NotImplementedException();
        }

        public void Super()
        {
            throw new NotImplementedException();
        }

        public void Twinkle(){
            throw new NotImplementedException();
        }
    }
}