using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Integration.Azure
{
    using App.Core.Shared.Contracts;

    public class AzureIntegrationInitializer : IHasAppCoreInitializer, IHasInitialize
    {
        private readonly AzureApplicationRegistrationIntegrationInitializer _azureApplicaitonRegistrationIntegrationInitializer;
        private readonly AzureKeyVaultIntegrationInitializer _azureKeyVaultIntegrationInitializer;
        private readonly AzureStorageIntegrationInitializer _azureStorageIntegrationInitializer;

        public AzureIntegrationInitializer(
            AzureApplicationRegistrationIntegrationInitializer azureApplicaitonRegistrationIntegrationInitializer,
            AzureKeyVaultIntegrationInitializer azureKeyVaultIntegrationInitializer,
            AzureStorageIntegrationInitializer azureStorageIntegrationInitializer
            )
        {
            this._azureApplicaitonRegistrationIntegrationInitializer = azureApplicaitonRegistrationIntegrationInitializer;
            this._azureKeyVaultIntegrationInitializer = azureKeyVaultIntegrationInitializer;
            this._azureStorageIntegrationInitializer = azureStorageIntegrationInitializer;
        }

        public void Initialize()
        {
            this._azureApplicaitonRegistrationIntegrationInitializer.Initialize();
            this._azureKeyVaultIntegrationInitializer.Initialize();
            this._azureStorageIntegrationInitializer.Initialize();
        }
    }
}
