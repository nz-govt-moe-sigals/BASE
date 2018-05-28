using App.Core.Shared.Models.ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration
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
