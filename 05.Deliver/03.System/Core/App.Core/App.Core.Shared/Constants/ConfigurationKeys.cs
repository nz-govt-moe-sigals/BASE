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
        public const string AppCoreIntegrationAzureCommonResourceName = SystemAzureIntegrationKeyPrefix + "Arm-Resources-DefaultName";

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
        // Integration / Redis Cache:
        public const string AppCoreIntegrationAzureRedisCacheResourceName = SystemAzureIntegrationKeyPrefix + "Redis-Cache-ResourceName";
        public const string AppCoreIntegrationAzureRedisCacheDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "Redis-Cache-Key";

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
        // SMTP (note that it does not prefix with Azure, as it is hosted somewhere else):
        public const string AppCoreIntegrationSmtpServiceEnabled = SystemIntegrationKeyPrefix + "Services-SmtpService-Enabled";
        public const string AppCoreIntegrationSmtpServiceBaseUri = SystemIntegrationKeyPrefix + "Services-SmtpService-Uri";
        public const string AppCoreIntegrationSmtpServiceClientId = SystemIntegrationKeyPrefix + "Services-SmtpService-Client-Id";
        public const string AppCoreIntegrationSmtpServiceClientSecret = SystemIntegrationKeyPrefix + "Services-SmtpService-Client-Secret";
        public const string AppCoreIntegrationSmtpServiceClientMiscConfig = SystemIntegrationKeyPrefix + "Services-SmtpService-Client-MiscConfig";


        // -----
        // Scanii (note that it does not prefix with Azure, as it is hosted somewhere else):
        public const string AppCoreIntegrationMalwareDetectionEnabled = SystemIntegrationKeyPrefix + "Services-MalwareDetectionService-Enabled";
        public const string AppCoreIntegrationMalwareDetectionBaseUri = SystemIntegrationKeyPrefix + "Services-MalwareDetectionService-Uri";
        public const string AppCoreIntegrationMalwareDetectionClientId = SystemIntegrationKeyPrefix + "Services-MalwareDetectionService-Client-Id";
        public const string AppCoreIntegrationMalwareDetectionClientSecret = SystemIntegrationKeyPrefix + "Services-MalwareDetectionService-Client-Secret";
        public const string AppCoreIntegrationMalwareDetectionClientMiscConfig = SystemIntegrationKeyPrefix + "Services-MalwareDetectionService-Client-MiscConfig";


        // -----
        // Some Misc Service (note that it does not prefix with Azure, as it is hosted somewhere else):
        public const string AppCoreIntegrationService01Name = SystemIntegrationKeyPrefix + "Services-Service01-Name";
        public const string AppCoreIntegrationService01Enabled = SystemIntegrationKeyPrefix + "Services-Service01-Enabled";
        public const string AppCoreIntegrationService01BaseUri = SystemIntegrationKeyPrefix + "Services-Service01-Uri";
        public const string AppCoreIntegrationService01ClientId = SystemIntegrationKeyPrefix + "Services-Service01-Client-Id";
        public const string AppCoreIntegrationService01ClientSecret = SystemIntegrationKeyPrefix + "Services-Service01-Client-Secret";
        public const string AppCoreIntegrationService01MiscConfig = SystemIntegrationKeyPrefix + "Services-Service01-Client-MiscConfig";

        // -----
        // Some Misc Service (note that it does not prefix with Azure, as it is hosted somewhere else):
        public const string AppCoreIntegrationService02Name = SystemIntegrationKeyPrefix + "Services-Service02-Name";
        public const string AppCoreIntegrationService02Enabled = SystemIntegrationKeyPrefix + "Services-Service02-Enabled";
        public const string AppCoreIntegrationService02BaseUri = SystemIntegrationKeyPrefix + "Services-Service02-Uri";
        public const string AppCoreIntegrationService02ClientId = SystemIntegrationKeyPrefix + "Services-Service02-Client-Id";
        public const string AppCoreIntegrationService02ClientSecret = SystemIntegrationKeyPrefix + "Services-Service02-Client-Secret";
        public const string AppCoreIntegrationService02MiscConfig = SystemIntegrationKeyPrefix + "Services-Service02-Client-MiscConfig";

        // -----
        // Some Misc Service (note that it does not prefix with Azure, as it is hosted somewhere else):
        public const string AppCoreIntegrationService03Name = SystemIntegrationKeyPrefix + "Services-Service03-Name";
        public const string AppCoreIntegrationService03Enabled = SystemIntegrationKeyPrefix + "Services-Service03-Enabled";
        public const string AppCoreIntegrationService03BaseUri = SystemIntegrationKeyPrefix + "Services-Service03-Uri";
        public const string AppCoreIntegrationService03ClientId = SystemIntegrationKeyPrefix + "Services-Service03-Client-Id";
        public const string AppCoreIntegrationService03ClientSecret = SystemIntegrationKeyPrefix + "Services-Service03-Client-Secret";
        public const string AppCoreIntegrationService03MiscConfig = SystemIntegrationKeyPrefix + "Services-Service03-Client-MiscConfig";
    }
}
