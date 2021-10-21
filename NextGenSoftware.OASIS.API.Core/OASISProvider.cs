
using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces;

namespace NextGenSoftware.OASIS.API.Core
{
    public abstract class OASISProvider : IOASISProvider
    {
        public string ProviderName { get; set; }
        public string ProviderDescription { get; set; }

        public EnumValue<ProviderCategory> ProviderCategory { get; set; }

        public EnumValue<ProviderType> ProviderType { get; set; }
        public bool ProviderActivated { get; set; }

        virtual public OASISResult<bool> ActivateProvider()
        {
            ProviderActivated = true;
            return new OASISResult<bool>(ProviderActivated) {Message = "Provider Activated"};
        }

        virtual public OASISResult<bool> DeActivateProvider()
        {
            ProviderActivated = false;
            return new OASISResult<bool>(ProviderActivated) {Message = "Provider Deactivated"};
        }
    }
}
