namespace App.Core.Infrastructure.Initialization.Integration.Azure
{
    using System;
    using App.Core.Infrastructure.Constants.Exceptions;
    using App.Core.Infrastructure.Services;
    using App.Core.Infrastructure.Services.Configuration;
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Contracts;
    using App.Core.Shared.Models.Configuration;


    public class AzureKeyVaultIntegrationInitializer : IHasAppCoreInitializer, IHasInitialize
    {
        private readonly DemoConfiguration _demoConfiguration;
        private readonly AzureKeyVaultServiceConfiguration _azureKeyVaultServiceConfiguration;
        private readonly IAzureKeyVaultService _azureKeyVaultService;

        public AzureKeyVaultIntegrationInitializer(DemoConfiguration demoConfiguration, AzureKeyVaultServiceConfiguration azureKeyVaultServiceConfiguration, IAzureKeyVaultService azureKeyVaultService)
        {
            this._demoConfiguration = demoConfiguration;
            this._azureKeyVaultServiceConfiguration = azureKeyVaultServiceConfiguration;
            this._azureKeyVaultService = azureKeyVaultService;
        }
        public void Initialize()
        {
            // Verify Access:
            VerifyKeystoreUrlsAreSet();
            VerifyAccessToKeys();

        }
        private void VerifyKeystoreUrlsAreSet()
        {
            if (string.IsNullOrWhiteSpace(this._azureKeyVaultServiceConfiguration.Configuration.SystemKeyVaultUrl))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: KeyVault System Url is not correctly configured (has no value).");
            }
            if (string.IsNullOrWhiteSpace(this._azureKeyVaultServiceConfiguration.Configuration.SystemKeyVaultUrl))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: KeyVault Organisation Url is not configured (has no value).");
            }
            if (!this._azureKeyVaultServiceConfiguration.Configuration.SystemKeyVaultUrl.StartsWith("https://"))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: KeyVault System Url is not correctly configured (does not start with 'https://').");
            }
            if (!this._azureKeyVaultServiceConfiguration.Configuration.OrganisationKeyVaultUrl.StartsWith("https://"))
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: KeyVault Organisation Url is not configured (does not start with 'https://')..");
            }

        }

        private void VerifyAccessToKeys()
        {
            try
            {
                string[] keyNames =
                    this._azureKeyVaultService.ListSecretKeysAsync(false).Result;
                if (keyNames.Length == 0)
                {
                    // Highly suspect.
                    if ((this._demoConfiguration.DemoMode) ||(this._azureKeyVaultServiceConfiguration.Configuration.DisableConfigurationCheck))
                    {
                        return;
                    }
                    throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure KeyVault Service contains no Keys (and App:Code:DemoMode setting=false).");
                }

            }
            catch (Exception e)
            {
                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Could not access Azure KeyVault Service", e);
            }
            // if count is zero, it's suspect that not correctly configured...
        }

    }
}