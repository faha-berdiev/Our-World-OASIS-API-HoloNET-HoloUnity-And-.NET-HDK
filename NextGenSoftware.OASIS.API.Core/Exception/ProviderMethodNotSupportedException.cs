namespace NextGenSoftware.OASIS.API.Core.Exception
{
    public class ProviderMethodNotSupportedException : System.Exception
    {
        public ProviderMethodNotSupportedException(string providerName, string providerMethod)
            : base($"Method: {providerMethod} not supported in {providerName} provider.")
        {
        }
    }
}