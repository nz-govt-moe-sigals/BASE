using App.Core.Shared.Attributes;


namespace App.Core.Shared.Models.ConfigurationSettings
{
    public class GeolocationServiceConfigurationSettings
    {
        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeolocationServiceClientId)]
        public string Key
        {
            get; set;
        }

        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeolocationServiceClientSecret)]
        public string Secret
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeolocationServiceBaseUri)]
        public string BaseUri
        {
            get; set;
        }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeolocationServiceMiscConfig)]
        public string MiscConfig
        {
            get; set;
        }
    }
}
