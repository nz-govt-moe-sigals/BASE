
namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Constants;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="IAzureKeyVaultService"/>
    /// </summary>
    public class AzureKeyVaultServiceConfiguration : IServiceConfigurationObject
    {
        /// <summary>
        /// Gets or sets the standard key divider character ('-').
        /// <para>
        /// Whereas AppHost keys can contain ':', etc. -- KeyVault cannot, so 
        /// they must be converted to this character (eg: '-', or '_', or maybe even '')
        /// </para>
        /// </summary>
        public string KeyStandardNameComponentDivider { get; private set; }

        /// <summary>
        /// Gets or sets the key illegal characters.
        /// <para>
        /// Whereas AppHost keys can contain ':', etc. -- KeyVault cannot, so 
        /// they must be converted to this character (eg: '-', or '_', or maybe even '')
        /// </para>
        /// </summary>
        /// <value>
        /// The key illegal characters.
        /// </value>
        public string[] KeyIllegalCharacters {get; private set;}




        /// <summary>
        /// Gets the name of the KeyVault Resource.
        /// <para>
        /// If not defined in AppSettings using 
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureKeyVaultStoreResourceName"/>
        /// will fall back to value provided by <see cref="Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// </para>
        /// </summary>
        public string ResourceName { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public string KeyPrefix
        {
            get;
            private set;
        }

        //public readonly AadApplicationRegistrationInformationHostConfiguration AADClientInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyVaultServiceConfiguration"/> class.
        /// <para>
        /// Note that this one of the only settings that goes directly to HostSettingsService.
        /// </para>
        /// </summary>
        /// <param name="hostSettingsService">The host settings service.</param>
        public AzureKeyVaultServiceConfiguration(IHostSettingsService hostSettingsService /*NO: IAzureKeyVaultService*/)
        {
            KeyStandardNameComponentDivider = "-";
            KeyIllegalCharacters = new[] {":", "."};


            // Get the configuration for this service:
            var commonConfiguration = hostSettingsService.GetObject<AzureCommonConfigurationSettings>();
            var configuration = hostSettingsService.GetObject<AzureKeyVaultConfigurationSettings>();

            //Get the resourceName for the KeyVault
            this.ResourceName = configuration.ResourceName;
            if (string.IsNullOrEmpty(ResourceName))
            {
                ResourceName = commonConfiguration.RootResourceName;
            }

            
            //this.KeyPrefix = configuration.KeyPrefix;


            // To make the Service Client, you should be using MSI...but in case you are not...
            // But - really - you really shouldn't be putting this kind of secrets in either AppSettings either 
            // by code (where it could inadvertently get checked in) or by vsts build pipelines
            // where everyone/contractors can see them..and reuse from remote locations.
            //this.AADClientInfo = hostSettingsService.GetObject<AadApplicationRegistrationInformationHostConfiguration>();
        }

    }
}
