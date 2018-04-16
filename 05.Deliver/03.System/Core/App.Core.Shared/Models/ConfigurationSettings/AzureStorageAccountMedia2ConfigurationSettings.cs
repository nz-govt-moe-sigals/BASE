
namespace App.Core.Shared.Models.ConfigurationSettings
{
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration needed to 
    /// access the
    /// Media1 Azure Storage Account Service.
    /// </summary>
    public class AzureStorageAccountMedia2ConfigurationSettings : IKeyVaultBasedConfigurationObject, IStorageAccountConfigurationSettings
    {
        /// <summary>
        /// Gets or sets (from AppSettings)
        /// the ResourceName of this StorageAccount.
        /// <para>
        /// <para>
        /// If not provided in AppSettings, using
        /// <see cref="Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountMedia2ResourceName"/>
        /// falls back to 
        /// <see cref="Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName"/>
        /// plus 'di'.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountMedia2ResourceName)]
        public string ResourceName
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
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountMedia2Key)]
        public string Key
        {
            get; set;
        }
    }
}
