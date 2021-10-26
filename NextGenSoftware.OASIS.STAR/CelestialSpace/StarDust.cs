﻿using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;

namespace NextGenSoftware.OASIS.STAR.CelestialSpace
{
    public class StarDust : Holon, IStarDust
    {
        public StarDust()
        {
            this.HolonType = API.Core.Enums.HolonType.StarDust;
        }
    }
}