using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Constants
{
    public static class ConfigurationKeys
    {
        // -----
        // Demo mode
        public const string AppCoreDemoMode = "App-Core-DemoMode";
        // -----
        // App Name & Description
        public const string AppCoreApplicationName = "App-Core-Application-Name";
        public const string AppCoreApplicationDescription = "App-Core-Application-Description";
        // -----
        // App Information
        public const string AppCoreApplicationProviderName = "App-Core-Application-Provider-Name";
        public const string AppCoreApplicationProviderDescription = "App-Core-Application-Provider-Description";
        public const string AppCoreApplicationProviderSiteUrl = "App-Core-Application-Provider-SiteUrl";
        public const string AppCoreApplicationProviderContactUrl = "App-Core-Application-Provider-ContactUrl";
        // -----
        // Creator Information
        public const string AppCoreApplicationCreatorName = "App-Core-Application-Creator-Name";
        public const string AppCoreApplicationCreatorDescription = "App-Core-Application-Creator-Description";
        public const string AppCoreApplicationCreatorSiteUrl = "App-Core-Application-Creator-SiteUrl";
        public const string AppCoreApplicationCreatorContactUrl = "App-Core-Application-Creator-ContactUrl";


        // -----
        // Media Management
        public const string AppCoreMediaHashType = "App-Core-Media-HashType";
        // -----
        // Azure AAD (if not moved on to using MSI, which is far safer):
        public const string AppCoreIDAAADClientId = "App-Core-Integration-Oidc-AAD:ClientId";
        public const string AppCoreIDAAADClientSecret = "App-Core-Integration-Oidc-AAD:ClientSecret";

        // -----
        // Integration / Azure:
        // WHen reosurces are not named (eg: DocumentDbResourceName), falls back to this setting:
        public const string AppCoreIntegrationAzureCommonResourceName = "App-Core-Integration-Azure-Common-ResourceName";
        // -----
        // Integration / Azure / AppInsights 
        public const string AppCoreIntegrationAzureApplicationInsightsInstrumentationKey =
            "App-Core-Integration-Azure-ApplicationInsights-InstrumentationKey";
        public const string AppCoreIntegrationAzureApplicationInsightsInstrumentationKeyEnabled =
            "App-Core-Integration-Azure-ApplicationInsights-Enabled";
        // -----
        // Integration / Azure / Key Vault
        public const string AppCoreIntegrationAzureKeyVaultStoreResourceName = "App-Core-Integration-Azure-KeyVaultStores-Default-ResourceName";
        // -----
        // Integration / Azure / Storage Account / Common
        // -----
        // Integration / Azure / Storage Account / Diagnostics
        public const string AppCoreIntegrationAzureStorageAccountDiagnosticsResourceName = "App-Core-Integration-Azure-StorageAccount-Diagnostics-ResourceName";
        public const string AppCoreIntegrationAzureStorageAccountDiagnosticsResourceNameSuffix = "App-Core-Integration-Azure-StorageAccount-Diagnostics-ResourceName-Suffix";
        public const string AppCoreIntegrationAzureStorageAccountDiagnosticsKey = "App-Core-Integration-Azure-StorageAccount-Diagnostics-Key";
        // -----
        // Integration / Azure / Storage Account / Default
        public const string AppCoreIntegrationAzureStorageAccountDefaultResourceName = "App-Core-Integration-Azure-StorageAccount-Default-ResourceName";
        public const string AppCoreIntegrationAzureStorageAccountDefaultResourceNameSuffix = "App-Core-Integration-Azure-StorageAccount-Default-ResourceName-Suffix";
        public const string AppCoreIntegrationAzureStorageAccountDefaultKey = "App-Core-Integration-Azure-StorageAccount-Default-Key";
        // -----
        // Integration / DocumentDb:
        public const string AppCoreIntegrationAzureDocumentDbResourceName = "App-Core-Integration-Azure-DocumentDb-Default-ResourceName";
        //public const string AppCoreIntegrationAzureDocumentDbResourceEndpointUrl = "App-Core-Integration:Azure:DocumentDb:EndpointUrl";
        // The following should not be use if we are using MSI:
        public const string AppCoreIntegrationAzureDocumentDbAuthorizationKey = "App-Core-Integration-Azure-DocumentDb-Default-Key";
        // -----
        // CodeFirst:
        public const string AppCoreCodeFirstAttachDebuggerToPSSeeding = "App-Core-Integration-Sql-CodeFirst-AttachDebuggerToPSSeeding";
        public const string AppCoreCodeFirstSeedIncludeDemoEntries = "App-Core-Integration-Sql-CodeFirst-SeedIncludeDemoEntries";
        // -----
        // Scanii:
        public const string AppCoreIntegrationMalwareDetectionScaniiKey = "App-Core-Integration-Scanii-MalwareDetection-Key";
        public const string AppCoreIntegrationMalwareDetectionScaniiSecret = "App-Core-Integration-Scanii-MalwareDetection-Secret";
        public const string AppCoreIntegrationMalwareDetectionScaniiBaseUri = "App-Core-Integration-Scanii-MalwareDetection-BaseUri";

    }
}
