﻿using System;
using System.Collections.Generic;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;
using NextGenSoftware.OASIS.API.Core.Enums;

namespace NextGenSoftware.OASIS.STAR.CelestialSpace
{
    public class SecondDimension : MultiverseDimension, ISecondDimension
    {
        public IUniverse Universe { get; set; }

        public SecondDimension(IMultiverse multiverse = null) : base(multiverse)
        {
            Init(multiverse);
        }

        public SecondDimension(Guid id, IMultiverse multiverse = null) : base(id, multiverse)
        {
            Init(multiverse);
        }

        public SecondDimension(Dictionary<ProviderType, string> providerKey, IMultiverse multiverse = null) : base(providerKey, multiverse)
        {
            Init(multiverse);
        }

        private void Init(IMultiverse multiverse = null)
        {
            this.Name = "The Second Dimension";
            this.Description = "The Animal/Vegetation Plane - where aniamls and plants exist.";
            this.DimensionLevel = DimensionLevel.Second;
            Universe = new Universe(this);
            base.RegisterCelestialSpaces(new List<ICelestialSpace>() { Universe });
        }
    }
}