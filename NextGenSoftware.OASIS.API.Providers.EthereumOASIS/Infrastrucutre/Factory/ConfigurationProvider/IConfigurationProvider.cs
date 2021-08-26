using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastrucutre.Factory.ConfigurationProvider
{
    public interface IConfigurationProvider
    {
        Task SetKey(string key, string value);
        Task<string> GetKey(string key);
    }
}