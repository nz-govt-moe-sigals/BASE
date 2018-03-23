using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IMediaMetadataService"/>
    /// </summary>
    public class MediaMetadataServiceConfiguration : IServiceConfigurationObject
    {
        public readonly MediaManagementConfiguration MediaManagementConfiguration;

        public MediaMetadataServiceConfiguration(IHostSettingsService hostSettingsService)
        {
            MediaManagementConfiguration = hostSettingsService.GetObject<MediaManagementConfiguration>();


        }
    }
}
