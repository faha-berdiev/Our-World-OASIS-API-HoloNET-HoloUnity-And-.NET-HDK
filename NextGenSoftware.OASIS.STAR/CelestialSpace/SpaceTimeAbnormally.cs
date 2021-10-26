﻿using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;

namespace NextGenSoftware.OASIS.STAR.CelestialSpace
{
    public class SpaceTimeAbnormally : Holon, ISpaceTimeAbnormally
    {
        public SpaceTimeAbnormally()
        {
            this.HolonType = API.Core.Enums.HolonType.SpaceTimeAbnormally;
        }
    }
}