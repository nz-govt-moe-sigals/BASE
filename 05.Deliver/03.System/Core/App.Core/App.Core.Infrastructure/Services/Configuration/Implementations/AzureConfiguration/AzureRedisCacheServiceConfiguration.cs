
using System;
using App.Core.Shared.Models.ConfigurationSettings;

namespace App.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration
{
    public class AzureRedisCacheServiceConfiguration : ICoreServiceConfigurationObject
    {

        public string ConnectionString { get;  }

        public bool Enabled { get;  }


        public AzureRedisCacheServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();
            var configuration = keyVaultService.GetObject<AzureRedisCacheConfigurationSettings>();
  
            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            if (!Boolean.TryParse(configuration.Enabled, out bool enabled))
            {
                enabled = true;
            }

            Enabled = enabled;
            ConnectionString = $"{configuration.ResourceName}.redis.cache.windows.net, ssl = true, password = {configuration.Key}";
            
        }
    }
}
