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
        public const string IntegrationKeyPrefix = "Integration-";
        public const string SystemIntegrationKeyPrefix = SystemKeyPrefix + IntegrationKeyPrefix;
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
        // Environment / Azure (pushed in by deployment engine):
        public const string AppCoreEnvironmentSubscriptionId = SystemAzureIntegrationKeyPrefix + "SubscriptionId";
        public const string AppCoreEnvironmentTenantId = SystemAzureIntegrationKeyPrefix + "TenantId";
        public const string AppCoreEnvironmentResourceGroupName = SystemAzureIntegrationKeyPrefix + "resourcegroup-name";
        public const string AppCoreEnvironmentResourceGroupLocation = SystemAzureIntegrationKeyPrefix + "resourcegroup-location";


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
        // Integration / Azure / Microsoft / Redis / Cache / Default (key has Cache before Redis):
        public const string AppCoreIntegrationAzureRedisCacheResourceName = SystemAzureIntegrationKeyPrefix + "Cache-Redis-Default-ResourceName";
        public const string AppCoreIntegrationAzureRedisCacheDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "Cache-Redis-Default-Key";

        // -----
        // Integration / Azure / Microsoft / DocumentDb / Default (do not name as Default):
        public const string AppCoreIntegrationAzureDocumentDbResourceName = SystemAzureIntegrationKeyPrefix + "DocumentDb-Default-ResourceName";
        //public const string AppCoreIntegrationAzureDocumentDbResourceEndpointUrl = SystemKeyPrefix + "Integration:Azure:DocumentDb:EndpointUrl";
        // The following should not be use if we are using MSI:
        public const string AppCoreIntegrationAzureDocumentDbAuthorizationKey = SystemAzureIntegrationKeyPrefix + "DocumentDb-Default-Key";
        // Integration / Azure / Search / Default (key has plural name):
        public const string AppCoreIntegrationAzureSearchDefaultResourceName = SystemAzureIntegrationKeyPrefix + "SearchServices-Default-ResourceName";
        public const string AppCoreIntegrationAzureSearchDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "SearchServices-Default-Key";
        // -----
        // Integration / Azure / Maps / Default (key has plural name):
        public const string AppCoreIntegrationAzureMapsDefaultResourceName = SystemAzureIntegrationKeyPrefix + "MapServices-Default-ResourceName";
        public const string AppCoreIntegrationAzureMapsDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "MapServices-Default-Key";
        // -----
        // Integration / Azure / Maps / CognitiveServices / ContentModerator / Default  (key has plural name):
        public const string AppCoreIntegrationAzureCognitiveServicesContentModeratorDefaultResourceName = SystemAzureIntegrationKeyPrefix + "CognitiveServices-ContentModerator-Default-ResourceName";
        public const string AppCoreIntegrationAzureCognitiveServicesContentModeratorDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "CognitiveServices-ContentModerator-Default-Key";
        // -----
        // Integration / Azure / Maps / CognitiveServices / ContentModerator / Default (key has plural name):
        public const string AppCoreIntegrationAzureCognitiveServicesLanguageUnderstandingDefaultResourceName = SystemAzureIntegrationKeyPrefix + "CognitiveServices-LanguageUnderstanding-Default-ResourceName";
        public const string AppCoreIntegrationAzureCognitiveServicesLanguageUnderstandingDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "CognitiveServices-LanguageUnderstanding-Default-Key";
        // -----
        // Integration / Azure / Maps / CognitiveServices / ComputerVision / Default (key has plural name):
        public const string AppCoreIntegrationAzureCognitiveServicesComputerVisionDefaultResourceName = SystemAzureIntegrationKeyPrefix + "CognitiveServices-ComputerVision-Default-ResourceName";
        public const string AppCoreIntegrationAzureCognitiveServicesComputerVisionDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "CognitiveServices-ComputerVision-Default-Key";
        // -----
        // Integration / Azure / Maps / CognitiveServices / CustomVision / Default (key has plural name):
        public const string AppCoreIntegrationAzureCognitiveServicesCustomVisionTrainingDefaultResourceName = SystemAzureIntegrationKeyPrefix + "CognitiveServices-CustomVision-Training-Default-ResourceName";
        public const string AppCoreIntegrationAzureCognitiveServicesCustomVisionTrainingDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "CognitiveServices-ComputerVision-Training-Default-Key";

        public const string AppCoreIntegrationAzureCognitiveServicesCustomVisionPredictionDefaultResourceName = SystemAzureIntegrationKeyPrefix + "CognitiveServices-CustomVision-Prediction-Default-ResourceName";
        public const string AppCoreIntegrationAzureCognitiveServicesCustomVisionPredictionDefaultAuthorizationKey = SystemAzureIntegrationKeyPrefix + "CognitiveServices-ComputerVision-Prediction-Default-Key";
        // -----








        // -----
        // CodeFirst (dubiously SystemAzureIntegrationKeyPrefix rather than SystemIntegrationKeyPrefix, but thinking of it as a production variable...sortof...?):
        public const string AppCoreCodeFirstAttachDebuggerToPSSeeding = SystemAzureIntegrationKeyPrefix + "SqlDatabase-CodeFirst-AttachDebuggerToPSSeeding";
        public const string AppCoreCodeFirstSeedIncludeDemoEntries = SystemAzureIntegrationKeyPrefix + "SqlDatabase-CodeFirst-SeedIncludeDemoEntries";

        // -----
        // SMTP (note that it does not prefix with Azure, as it is hosted somewhere else) / (Do not name as Default):
        public const string AppCoreIntegrationSmtpServiceEnabled = SystemIntegrationKeyPrefix + "SmtpService-Enabled";
        public const string AppCoreIntegrationSmtpServiceBaseUri = SystemIntegrationKeyPrefix + "SmtpService-Uri";
        public const string AppCoreIntegrationSmtpServiceClientId = SystemIntegrationKeyPrefix + "SmtpService-Client-Id";
        public const string AppCoreIntegrationSmtpServiceClientSecret = SystemIntegrationKeyPrefix + "SmtpService-Client-Secret";
        public const string AppCoreIntegrationSmtpServiceClientMiscConfig = SystemIntegrationKeyPrefix + "SmtpService-Client-MiscConfig";


        // -----
        // Scanii (note that it does not prefix with Azure, as it is hosted somewhere else) / (Do not name as Default):
        public const string AppCoreIntegrationMalwareDetectionEnabled = SystemIntegrationKeyPrefix + "MalwareDetectionService-Enabled";
        public const string AppCoreIntegrationMalwareDetectionBaseUri = SystemIntegrationKeyPrefix + "MalwareDetectionService-Uri";
        public const string AppCoreIntegrationMalwareDetectionClientId = SystemIntegrationKeyPrefix + "MalwareDetectionService-Client-Id";
        public const string AppCoreIntegrationMalwareDetectionClientSecret = SystemIntegrationKeyPrefix + "MalwareDetectionService-Client-Secret";
        public const string AppCoreIntegrationMalwareDetectionClientMiscConfig = SystemIntegrationKeyPrefix + "MalwareDetectionService-Client-MiscConfig";

        // -----
        // Integration / [SituationSpecific] / GeoLocationService  / (Do not name as Default):
        public const string AppCoreIntegrationGeoIPServiceEnabled = SystemIntegrationKeyPrefix + "GeoIPService-Enabled";
        public const string AppCoreIntegrationGeoIPServiceBaseUri = SystemIntegrationKeyPrefix + "GeoIPService-Uri";
        public const string AppCoreIntegrationGeoIPServiceClientId = SystemIntegrationKeyPrefix + "GeoIPService-Client-Id";
        public const string AppCoreIntegrationGeoIPServiceClientSecret = SystemIntegrationKeyPrefix + "GeoIPService-Client-Secret";
        public const string AppCoreIntegrationGeoIPServiceClientMiscConfig = SystemIntegrationKeyPrefix + "GeoIPService-Client-MiscConfig";
        // -----


        // -----
        // Some Misc Service (note that it does not prefix with Azure, as it is hosted somewhere else) / (Do not name as Default):
        public const string AppCoreIntegrationService01Name = SystemIntegrationKeyPrefix + "Service01-Name";
        public const string AppCoreIntegrationService01Enabled = SystemIntegrationKeyPrefix + "Service01-Enabled";
        public const string AppCoreIntegrationService01BaseUri = SystemIntegrationKeyPrefix + "Service01-Uri";
        public const string AppCoreIntegrationService01ClientId = SystemIntegrationKeyPrefix + "Service01-Client-Id";
        public const string AppCoreIntegrationService01ClientSecret = SystemIntegrationKeyPrefix + "Service01-Client-Secret";
        public const string AppCoreIntegrationService01MiscConfig = SystemIntegrationKeyPrefix + "Service01-Client-MiscConfig";

        // -----
        // Some Misc Service (note that it does not prefix with Azure, as it is hosted somewhere else) / (Do not name as Default):
        public const string AppCoreIntegrationService02Name = SystemIntegrationKeyPrefix + "Service02-Name";
        public const string AppCoreIntegrationService02Enabled = SystemIntegrationKeyPrefix + "Service02-Enabled";
        public const string AppCoreIntegrationService02BaseUri = SystemIntegrationKeyPrefix + "Service02-Uri";
        public const string AppCoreIntegrationService02ClientId = SystemIntegrationKeyPrefix + "Service02-Client-Id";
        public const string AppCoreIntegrationService02ClientSecret = SystemIntegrationKeyPrefix + "Service02-Client-Secret";
        public const string AppCoreIntegrationService02MiscConfig = SystemIntegrationKeyPrefix + "Service02-Client-MiscConfig";

        // -----
        // Some Misc Service (note that it does not prefix with Azure, as it is hosted somewhere else) / (Do not name as Default):
        public const string AppCoreIntegrationService03Name = SystemIntegrationKeyPrefix + "Service03-Name";
        public const string AppCoreIntegrationService03Enabled = SystemIntegrationKeyPrefix + "Service03-Enabled";
        public const string AppCoreIntegrationService03BaseUri = SystemIntegrationKeyPrefix + "Service03-Uri";
        public const string AppCoreIntegrationService03ClientId = SystemIntegrationKeyPrefix + "Service03-Client-Id";
        public const string AppCoreIntegrationService03ClientSecret = SystemIntegrationKeyPrefix + "Service03-Client-Secret";
        public const string AppCoreIntegrationService03MiscConfig = SystemIntegrationKeyPrefix + "Service03-Client-MiscConfig";
    }
}
