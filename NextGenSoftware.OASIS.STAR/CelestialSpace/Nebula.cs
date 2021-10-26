﻿using System.Collections.Generic;
using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;

namespace NextGenSoftware.OASIS.STAR.CelestialSpace
{
    public class Nebula : Holon, INebula
    {
        public Nebula()
        {
            this.HolonType = API.Core.Enums.HolonType.Nebula;
        }
    }
}