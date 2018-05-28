namespace App.Core.Shared.Models.ConfigurationSettings
{
    using App.Core.Shared.Attributes;

    public class AzureEnvironmentSettings : IHostSettingsBasedConfigurationObject, IKeyVaultBasedConfigurationObject
    {

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreEnvironmentSubscriptionId)]
        public string SubscriptionId { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreEnvironmentTenantId)]
        public string TenantId { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreEnvironmentResourceGroupName)]
        public string ResourceGroupName { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreEnvironmentResourceGroupLocation)]
        public string ResourceGroupLocation { get; set; }
    }

}
