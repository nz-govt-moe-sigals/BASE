
using App.Core.Shared.Models.ConfigurationSettings;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    public class AzureRedisCacheServiceConfiguration : ICoreServiceConfigurationObject
    {

        public string ConnectionString { get; set; }


        public AzureRedisCacheServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();
            var configuration = keyVaultService.GetObject<AzureRedisCacheConfigurationSettings>();

            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            string authKey = configuration.Key;

            ConnectionString = $"{configuration.ResourceName}.redis.cache.windows.net, ssl = true, password = {configuration.Key}";
        }
    }
}
