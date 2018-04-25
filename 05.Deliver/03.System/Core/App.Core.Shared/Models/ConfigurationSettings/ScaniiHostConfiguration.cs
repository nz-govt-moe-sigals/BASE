

namespace App.Core.Shared.Models.Configuration.AppHost
{
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Models.ConfigurationSettings;

    public class ScaniiHostConfiguration: IHostSettingsBasedConfigurationObject
    {

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationMalwareDetectionScaniiClientId)]
        public string Key
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationMalwareDetectionScaniiClientSecret)]
        public string Secret
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationMalwareDetectionScaniiBaseUri)]
        public string BaseUri
        {
            get; set;
        }
    }
}