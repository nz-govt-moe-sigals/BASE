using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Contracts;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IMediaMetadataService"/>
    /// <para>
    /// Inherits from <see cref="ICoreServiceConfigurationObject"/>
    /// whic inherits from <see cref="IHasSingletonLifecycle"/>
    /// to hint at startup that the Configuration object should be 
    /// IoC registered for the duration of the application (not the thread).
    /// as some configuration hits remote services (eg: Azure KeyVault)
    /// which would be rather slow.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.Configuration.ICoreServiceConfigurationObject" />
    public class MediaMetadataServiceConfiguration : ICoreServiceConfigurationObject
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
