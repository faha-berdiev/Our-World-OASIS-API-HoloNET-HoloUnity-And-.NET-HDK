﻿using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;
using NextGenSoftware.OASIS.API.Providers.CosmosOASIS.Entites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.API.Providers.CosmosOASIS.Entities
{
    public class Holon : Entity, IHolon
    {
        public new Guid Id { get { return Guid.Parse(base.Id); } set { base.Id = $"{value}"; } }
        public string Name { get; set; }
        public string Description { get; set; }
        public IHolon Original { get; set; }
        public bool IsNewHolon { get; set; }
        public bool IsChanged { get; set; }
        public Dictionary<ProviderType, string> ProviderKey { get; set; }
        public Dictionary<ProviderType, Dictionary<string, string>> ProviderMetaData { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public HolonType HolonType { get; set; }
        public Guid ParentOmiverseId { get; set; }
        public IOmiverse ParentOmiverse { get; set; }
        public Guid ParentMultiverseId { get; set; }
        public IMultiverse ParentMultiverse { get; set; }
        public Guid ParentUniverseId { get; set; }
        public IUniverse ParentUniverse { get; set; }
        public Guid ParentDimensionId { get; set; }
        public IDimension ParentDimension { get; set; }
        public Guid ParentGalaxyClusterId { get; set; }
        public IGalaxyCluster ParentGalaxyCluster { get; set; }
        public Guid ParentGalaxyId { get; set; }
        public IGalaxy ParentGalaxy { get; set; }
        public Guid ParentSolarSystemId { get; set; }
        public ISolarSystem ParentSolarSystem { get; set; }
        public Guid ParentGreatGrandSuperStarId { get; set; }
        public IGreatGrandSuperStar ParentGreatGrandSuperStar { get; set; }
        public Guid ParentGrandSuperStarId { get; set; }
        public IGrandSuperStar ParentGrandSuperStar { get; set; }
        public Guid ParentSuperStarId { get; set; }
        public ISuperStar ParentSuperStar { get; set; }
        public Guid ParentStarId { get; set; }
        public IStar ParentStar { get; set; }
        public Guid ParentPlanetId { get; set; }
        public IPlanet ParentPlanet { get; set; }
        public Guid ParentMoonId { get; set; }
        public IMoon ParentMoon { get; set; }
        public Guid ParentZomeId { get; set; }
        public IZome ParentZome { get; set; }
        public Guid ParentHolonId { get; set; }
        public IHolon ParentHolon { get; set; }
        public IEnumerable<IHolon> Children { get; set; }
        public ObservableCollection<IHolon> ChildrenTest { get; set; }
        public Guid CreatedByAvatarId { get; set; }
        public Core.Holons.Avatar CreatedByAvatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedByAvatarId { get; set; }
        public Core.Holons.Avatar ModifiedByAvatar { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid DeletedByAvatarId { get; set; }
        public Core.Holons.Avatar DeletedByAvatar { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsActive { get; set; }
        public int Version { get; set; }
        public EnumValue<ProviderType> CreatedProviderType { get; set; }
        public ObservableCollection<INode> Nodes { get; set; }
        public DimensionLevel DimensionLevel { get; set; }
        public SubDimensionLevel SubDimensionLevel { get; set; }
        public Guid PreviousVersionId { get; set; }
        public Dictionary<ProviderType, string> PreviousVersionProviderKey { get; set; }
        public EnumValue<OASISType> CreatedOASISType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool HasHolonChanged(bool checkChildren = true)
        {
            throw new NotImplementedException();
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
