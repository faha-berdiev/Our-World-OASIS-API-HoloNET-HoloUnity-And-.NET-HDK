﻿namespace NextGenSoftware.OASIS.API.Providers.EthereumOASIS.Infrastrucutre.Factory.ConfigurationProvider
{
    public static class ConfigurationFactory
    {
        public static IConfigurationProvider GetLocalStorageConfigurationProvider()
        {
            return new LocalStorageConfigurationProvider();
        }
    }
}