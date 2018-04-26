using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Constants
{
    public static class ConfigurationKeys
    {
        public const string SystemKeyPrefix = "System-";
        public const string SystemIntegrationKeyPrefix = SystemKeyPrefix + "Integration-";
        public const string SystemAzureIntegrationKeyPrefix = SystemIntegrationKeyPrefix + "Azure-";

        // -----
        // Demo mode
        public const string AppCoreDemoMode = SystemKeyPrefix + "DemoMode";
        // -----
        // App Name & Description
        public const string AppCoreApplicationName = SystemKeyPrefix + "Application-Info-Name";
        public const string AppCoreApplicationDescription = SystemKeyPrefix + "Application-Info-Description";
        // -----
        // App Information
        public const string AppCoreApplicationProviderName = SystemKeyPrefix + "Application-Provider-Name";
        public const string AppCoreApplicationProviderDescription = SystemKeyPrefix + "Application-Provider-Description";
        public const string AppCoreApplicationProviderSiteUrl = SystemKeyPrefix + "Application-Provider-SiteUrl";
        public const string AppCoreApplicationProviderContactUrl = SystemKeyPrefix + "Application-Provider-ContactUrl";
        // -----
        // Creator Information
        public const string AppCoreApplicationCreatorName = SystemKeyPrefix + "Application-Creator-Name";
        public const string AppCoreApplicationCreatorDescription = SystemKeyPrefix + "Application-Creator-Description";
        public const string AppCoreApplicationCreatorSiteUrl = SystemKeyPrefix + "Application-Creator-SiteUrl";
        public const string AppCoreApplicationCreatorContactUrl = SystemKeyPrefix + "Application-Creator-ContactUrl";


        // -----
        // Media Management
        public const string AppCoreMediaHashType = SystemKeyPrefix + "Media-HashType";
        // -----
        // Azure AAD (if not moved on to using MSI, which is far safer):
        public const string AppCoreIDAAADClientId = SystemIntegrationKeyPrefix + "Oidc-AAD:ClientId";
        public const string AppCoreIDAAADClientSecret = SystemIntegrationKeyPrefix + "Oidc-AAD:ClientSecret";

        // -----
        // Integration / Azure:
        // WHen reosurces are not named (eg: DocumentDbResourceName), falls back to this setting:
        public const string AppCoreIntegrationAzureCommonResourceName = SystemAzureIntegrationKeyPrefix + "Common-ResourceName";
        // -----
        // Integration / Azure / AppInsights 
        public const string AppCoreIntegrationAzureApplicationInsightsInstrumentationKey =
            SystemAzureIntegrationKeyPrefix + "ApplicationInsights-InstrumentationKey";
        public const string AppCoreIntegrationAzureApplicationInsightsInstrumentationKeyEnabled =
            SystemAzureIntegrationKeyPrefix + "ApplicationInsights-Enabled";
        // -----
        // Integration / Azure / Key Vault
        public const string AppCoreIntegrationAzureKeyVaultStoreResourceName = SystemAzureIntegrationKeyPrefix + "KeyVaultStores-Default-ResourceName";
        // -----
        // Integration / Azure / Storage Account / Common
        // -----
        // Integration / Azure / Storage Account / Diagnostics
        public const string AppCoreIntegrationAzureStorageAccountDiagnosticsResourceName = SystemAzureIntegrationKeyPrefix + "StorageAccount-Diagnostics-ResourceName";
        public const string AppCoreIntegrationAzureStorageAccountDiagnosticsResourceNameSuffix = SystemAzureIntegrationKeyPrefix + "StorageAccount-Diagnostics-ResourceName-Suffix";
        public const string AppCoreIntegrationAzureStorageAccountDiagnosticsKey = SystemAzureIntegrationKeyPrefix + "StorageAccount-Diagnostics-Key";
        // -----
        // Integration / Azure / Storage Account / Default
        public const string AppCoreIntegrationAzureStorageAccountDefaultResourceName = SystemAzureIntegrationKeyPrefix + "StorageAccount-Default-ResourceName";
        public const string AppCoreIntegrationAzureStorageAccountDefaultResourceNameSuffix = SystemAzureIntegrationKeyPrefix + "StorageAccount-Default-ResourceName-Suffix";
        public const string AppCoreIntegrationAzureStorageAccountDefaultKey = SystemAzureIntegrationKeyPrefix + "StorageAccount-Default-Key";
        // -----
        // Integration / DocumentDb:
        public const string AppCoreIntegrationAzureDocumentDbResourceName = SystemAzureIntegrationKeyPrefix + "DocumentDb-Default-ResourceName";
        //public const string AppCoreIntegrationAzureDocumentDbResourceEndpointUrl = SystemKeyPrefix + "Integration:Azure:DocumentDb:EndpointUrl";
        // The following should not be use if we are using MSI:
        public const string AppCoreIntegrationAzureDocumentDbAuthorizationKey = SystemAzureIntegrationKeyPrefix + "DocumentDb-Default-Key";
        // -----
        // CodeFirst (dubiously SystemAzureIntegrationKeyPrefix rather than SystemIntegrationKeyPrefix, but thinking of it as a production variable...sortof...?):
        public const string AppCoreCodeFirstAttachDebuggerToPSSeeding = SystemAzureIntegrationKeyPrefix + "SqlDatabase-CodeFirst-AttachDebuggerToPSSeeding";
        public const string AppCoreCodeFirstSeedIncludeDemoEntries = SystemAzureIntegrationKeyPrefix + "SqlDatabase-CodeFirst-SeedIncludeDemoEntries";
        // -----
        // Scanii (note that it does not prefix with Azure, as it is hosted somewhere else):
        public const string AppCoreIntegrationMalwareDetectionScaniiClientId = SystemIntegrationKeyPrefix + "Scanii-MalwareDetection-OAuth-ClientId";
        public const string AppCoreIntegrationMalwareDetectionScaniiClientSecret = SystemIntegrationKeyPrefix + "Scanii-MalwareDetection-OAuth-ClientSecret";
        public const string AppCoreIntegrationMalwareDetectionScaniiBaseUri = SystemIntegrationKeyPrefix + "Scanii-MalwareDetection-BaseUri";

    }
}
