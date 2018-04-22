
namespace App.Core.Shared.Models.ConfigurationSettings
{
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Constants;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration needed to 
    /// access the
    /// Media Azure Storage Account Service.
    /// </summary>
    public class AzureStorageAccountDefaultConfigurationSettings: IKeyVaultBasedConfigurationObject, IStorageAccountConfigurationSettings
    {
        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName of this StorageAccount.
        /// <para>
        /// <para>
        /// If not provided in AppSettings, using
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceName"/>
        /// falls back to 
        /// <see cref="Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// plus 'di'.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceName)]
        public string ResourceName
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName Suffix of this StorageAccount.
        /// <para>
        /// <para>
        /// Default Value is 'm1'.
        /// </para>
        /// <para>
        /// The value is appended to <see cref="ResourceName"/>.
        /// </para>
        /// <para>
        /// Can be overridden (or cleared) using 
        /// <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceNameSuffix"/>,
        /// in AppSettings.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceNameSuffix)]
        public string ResourceNameSuffix
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets 
        /// (from the KeyVault) 
        /// the Key for the ServiceAccount.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultKey)]
        public string Key
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureStorageAccountDefaultConfigurationSettings"/> class.
        /// </summary>
        public AzureStorageAccountDefaultConfigurationSettings()
        {
            ResourceNameSuffix = "";
        }

    }
}
