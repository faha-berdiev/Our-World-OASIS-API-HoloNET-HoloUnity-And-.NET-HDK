﻿using System.Collections.Generic;
using NextGenSoftware.OASIS.API.Core.Holons;
using NextGenSoftware.OASIS.API.ONODE.BLL.Interfaces;

namespace NextGenSoftware.OASIS.API.ONODE.BLL.Holons
{
    public class MissionData : Holon, IMissionData
    {
        public List<Mission> Missions { get; set; } = new List<Mission>();
    }
}