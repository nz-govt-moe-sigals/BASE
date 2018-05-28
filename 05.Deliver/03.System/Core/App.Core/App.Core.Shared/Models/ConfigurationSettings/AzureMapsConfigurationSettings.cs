using App.Core.Shared.Attributes;

namespace App.Core.Shared.Models.ConfigurationSettings
{
    public class AzureMapsConfigurationSettings
    {
        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName of this Map service.
        /// <para>
        /// <para>
        /// If not provided in AppSettings, using
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureMapsDefaultResourceName"/>
        /// falls back to 
        /// <see cref="Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// plus 'di'.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureMapsDefaultResourceName)]
        public string ResourceName
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureMapsDefaultAuthorizationKey)]
        public string Key
        {
            get; set;
        }
    }
}
