using System;


namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Contracts;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// 
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
    public class DocumentDbServiceConfiguration : ICoreServiceConfigurationObject
    {
        public Uri EndpointUrl
        {
            get; set;
        }
        public string AuthorizationKey
        {
            get; set;
        }

        public int TimeoutMilliseconds
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentDbServiceConfiguration" /> class.
        /// </summary>
        public DocumentDbServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject< AzureCommonConfigurationSettings>();
            var configuration = keyVaultService.GetObject<AzureDocumentDbConfigurationSettings>();
            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            //this.EndpointUrl = configuration.EndpointUrl;
            this.AuthorizationKey = configuration.AuthorizationKey;

            this.TimeoutMilliseconds = 10 * 1000;
        }
    }
}
