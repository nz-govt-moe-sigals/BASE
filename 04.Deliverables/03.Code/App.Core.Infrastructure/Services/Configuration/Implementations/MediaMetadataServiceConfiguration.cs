using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;

    public class MediaMetadataServiceConfiguration
    {
        public readonly MediaManagementConfiguration MediaManagementConfiguration;

        public MediaMetadataServiceConfiguration(IHostSettingsService hostSettingsService)
        {
            MediaManagementConfiguration = hostSettingsService.GetObject<MediaManagementConfiguration>();


        }
    }
}
