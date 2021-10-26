﻿using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;

namespace NextGenSoftware.OASIS.STAR.CelestialSpace
{
    public class GravitationalWave : Holon, IGravitationalWave
    {
        public GravitationalWave()
        {
            this.HolonType = API.Core.Enums.HolonType.GravitationalWave;
        }
    }
}