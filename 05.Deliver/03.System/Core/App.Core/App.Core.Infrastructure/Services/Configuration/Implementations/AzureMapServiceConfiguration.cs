using App.Core.Shared.Models.ConfigurationSettings;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    public class AzureMapServiceConfiguration : ICoreServiceConfigurationObject
    {

        public string RootUri = "https://atlas.microsoft.com";// /search/address/reverse/json?subscription-key={subscription-key}&api-version=1.0&query={query}"

        public string Key { get; set; }


        public AzureMapServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();

            var configuration = keyVaultService.GetObject<AzureMapsConfigurationSettings>();

            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            Key = configuration.Key;
        }
    }
}