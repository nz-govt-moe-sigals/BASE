using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IMediaMetadataService"/>
    /// </summary>
    public class MediaMetadataServiceConfiguration : IServiceConfigurationObject
    {
        public readonly MediaManagementConfigurationSettings MediaManagementConfiguration;

        public MediaMetadataServiceConfiguration(IAzureKeyVaultService azureKeyVaultService)
        {
            //From AppSettings:
            MediaManagementConfiguration = azureKeyVaultService.GetObject<MediaManagementConfigurationSettings>();

            // At this point, there's nothing needed from KeyVault.
        }
    }
}
