namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Models.Entity
{
    public class EntityReference
    {
        public string Reference { get; set; }

        public EntityReference(string reference)
        {
            Reference = reference;
        }
        
        public EntityReference () {}
    }
}