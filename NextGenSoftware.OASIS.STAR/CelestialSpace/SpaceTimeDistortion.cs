﻿using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;

namespace NextGenSoftware.OASIS.STAR.CelestialSpace
{
    public class SpaceTimeDistortion : Holon, ISpaceTimeDistortion
    {
        public SpaceTimeDistortion()
        {
            this.HolonType = API.Core.Enums.HolonType.SpaceTimeDistortion;
        }
    }
}