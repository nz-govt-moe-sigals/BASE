using App.Core.Shared.Models.ConfigurationSettings;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    public class AzureCognitiveServicesComputerVisionServiceConfiguration : ICoreServiceConfigurationObject
    {
        public AzureCognitiveServicesComputerVisionServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();

            var configuration = keyVaultService.GetObject<AzureCognitiveServicesComputerVisionConfigurationSettings>();

            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            string authKey = configuration.Key;

            // https://australiaeast.api.cognitive.microsoft.com/vision/v1.0
        }
    }
}
