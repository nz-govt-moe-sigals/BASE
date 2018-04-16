using System;


namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.ConfigurationSettings;

    public class DocumentDbServiceConfiguration
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
