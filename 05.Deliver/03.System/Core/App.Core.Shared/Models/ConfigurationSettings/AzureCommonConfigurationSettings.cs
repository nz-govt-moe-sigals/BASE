namespace App.Core.Shared.Models.ConfigurationSettings
{
    using App.Core.Shared.Attributes;

    public class AzureCommonConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        /// <summary>
        /// Gets or sets the root of the Azure Resource Names
        /// (eg: something like 'corpappbranchenv')
        /// from AppSettings, 
        /// using the 
        /// <see cref="Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// AppSettings 
        /// key.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName)]
        public string RootResourceName
        {
            get; set;
        }
    }
}