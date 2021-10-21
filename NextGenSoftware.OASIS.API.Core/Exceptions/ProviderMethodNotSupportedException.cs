namespace NextGenSoftware.OASIS.API.Core.Exceptions
{
    public class ProviderMethodNotSupportedException : System.Exception
    {
        public ProviderMethodNotSupportedException(string providerName, string providerMethod)
            : base($"Method: {providerMethod} not supported in {providerName} provider.")
        {
        }
    }
}