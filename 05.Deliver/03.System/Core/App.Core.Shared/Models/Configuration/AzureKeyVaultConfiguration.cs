using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;


    /// <summary>
    /// An immutable host configuration object 
    /// describing the settings to access the 
    /// Azure Key Vault Service.
    /// </summary>
    public class AzureKeyVaultConfiguration
    {
        [Alias("App:Core:Integration:Azure:KeyVaultStores:DisableConfigurationCheck")]
        public bool DisableConfigurationCheck
        {
            get; set;
        }

        [Alias("App:Core:Integration:Azure:KeyVaultStores:System:Url")]
        public string SystemKeyVaultUrl { get; set; }

        [Alias("App:Core:Integration:Azure:KeyVaultStores:Organisation:Url")]
        public string OrganisationKeyVaultUrl
        {
            get; set;
        }

    }
}
