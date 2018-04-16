namespace App.Core.Shared.Models.ConfigurationSettings
{
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Models.Configuration;

    public class MediaManagementConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        private string _hashType;

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreMediaHashType)]
        public string HashType
        {
            get { return this._hashType?? "SHA-256"; }
            set { this._hashType = value; }
        }
    }
}