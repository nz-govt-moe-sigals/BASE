﻿
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
        /// Gets or sets (from AppSettings)
        /// the ResourceName Suffix of this StorageAccount.
        /// <para>
        /// <para>
        /// Default Value is 'm2'.
        /// </para>
        /// <para>
        /// The value is appended to <see cref="ResourceName"/>.
        /// </para>
        /// <para>
        /// Can be overridden (or cleared) using 
        /// <see cref="Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountMedia2ResourceNameSuffix"/>,
        /// in AppSettings.
        /// </para>
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountMedia2ResourceNameSuffix)]
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
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureStorageAccountMedia2Key)]
        public string Key
        {
            get; set;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="AzureStorageAccountMedia1ConfigurationSettings"/> class.
        /// </summary>
        public AzureStorageAccountMedia2ConfigurationSettings()
        {
            ResourceNameSuffix = "m2";
        }

    }
}
