using App.Core.Shared.Models.ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    public class GeoIPServiceConfiguration : ICoreServiceConfigurationObject
    {
        public GeoIPServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            Configuration = keyVaultService.GetObject<GeoIPServiceConfigurationSettings>();

        }

        public GeoIPServiceConfigurationSettings Configuration { get; }

    }
}
