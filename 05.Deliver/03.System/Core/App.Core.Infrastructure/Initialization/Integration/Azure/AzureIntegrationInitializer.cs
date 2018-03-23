using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Integration.Azure
{
    using App.Core.Shared.Contracts;


    /// <summary>
    /// Class to initialize integration with all Azure Services the application
    /// depends on.
    /// <para>
    /// The class should *NOT* be invoked during startup.
    /// </para>
    /// <para>
    /// The class should invoke integration with the KeyVault, Storage, and Database
    /// (ie, invoke <see cref="AzureKeyVaultIntegrationInitializer"/>,
    /// <see cref="AzureStorageIntegrationInitializer "/>, etc.)
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Initialization.IHasAppCoreInitializer" />
    /// <seealso cref="App.Core.Shared.Contracts.IHasInitialize" />
    public class AzureIntegrationInitializer : IHasAppCoreInitializer, IHasInitialize
    {
        private readonly AzureApplicationRegistrationIntegrationInitializer _azureApplicaitonRegistrationIntegrationInitializer;
        private readonly AzureKeyVaultIntegrationInitializer _azureKeyVaultIntegrationInitializer;
        private readonly AzureStorageIntegrationInitializer _azureStorageIntegrationInitializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureIntegrationInitializer"/> class.
        /// <para>
        /// Should *NOT* be invoked at startup: the startup home page should not rely on
        /// Data Storage for site immutable images, nor authentication, which has not occurred, 
        /// and not database values...although it quickly gets tricky around caching, which 
        /// can fallback to methods thta invoke dbContext...and therefore database (ie, 
        /// try to keep caching for home and diagnostics pages separate from the rest of the system).
        /// TODO: Keep caching separate for Home/Diagnostics page. That might be hard with localisation added in the mix. 
        /// </para>
        /// <para>
        /// Invoked by <see cref="AzureStorageIntegrationInitializer"/>
        /// </para>
        /// </summary>
        /// <param name="azureApplicaitonRegistrationIntegrationInitializer">The azure applicaiton registration integration initializer.</param>
        /// <param name="azureKeyVaultIntegrationInitializer">The azure key vault integration initializer.</param>
        /// <param name="azureStorageIntegrationInitializer">The azure storage integration initializer.</param>
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
