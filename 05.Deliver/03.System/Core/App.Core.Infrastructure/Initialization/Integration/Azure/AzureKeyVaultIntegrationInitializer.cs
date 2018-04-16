//namespace App.Core.Infrastructure.Initialization.Integration.Azure
//{
//    using System;
//    using App.Core.Infrastructure.Constants.Exceptions;
//    using App.Core.Infrastructure.Services;
//    using App.Core.Infrastructure.Services.Configuration;
//    using App.Core.Infrastructure.Services.Configuration.Implementations;
//    using App.Core.Shared.Contracts;
//    using App.Core.Shared.Models.Configuration;
//    using App.Core.Shared.Models.Configuration.AppHost;


//    public class AzureKeyVaultIntegrationInitializer : IHasAppCoreInitializer, IHasInitialize
//    {
//        private readonly DemoHostConfiguration _demoConfiguration;
//        private readonly AzureKeyVaultServiceConfiguration _azureKeyVaultServiceConfiguration;
//        private readonly IAzureKeyVaultService _azureKeyVaultService;

//        public AzureKeyVaultIntegrationInitializer(DemoHostConfiguration demoConfiguration, AzureKeyVaultServiceConfiguration azureKeyVaultServiceConfiguration, IAzureKeyVaultService azureKeyVaultService)
//        {
//            this._demoConfiguration = demoConfiguration;
//            this._azureKeyVaultServiceConfiguration = azureKeyVaultServiceConfiguration;
//            this._azureKeyVaultService = azureKeyVaultService;
//        }
//        public void Initialize()
//        {
//            // Verify Access:
//            VerifyAccessToKeys();

//        }

//        private void VerifyAccessToKeys()
//        {
//            try
//            {
//                string[] keyNames =
//                    this._azureKeyVaultService.ListSecretKeysAsync(false).Result;
//                if (keyNames.Length == 0)
//                {
//                    // Highly suspect.
//                    if ((this._demoConfiguration.DemoMode))
//                    {
//                        return;
//                    }
//                    throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure KeyVault Service contains no Keys (and App-Code-DemoMode setting=false).");
//                }

//            }
//            catch (Exception e)
//            {
//                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Could not access Azure KeyVault Service", e);
//            }
//            // if count is zero, it's suspect that not correctly configured...
//        }

//    }
//}