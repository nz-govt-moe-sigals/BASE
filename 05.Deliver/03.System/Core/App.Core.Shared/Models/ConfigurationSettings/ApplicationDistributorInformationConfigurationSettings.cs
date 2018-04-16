namespace App.Core.Shared.Models.ConfigurationSettings
{
    using System;
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the Distributor of the application
    /// (distinct from the Creator) in many commercial cases.
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.IHasName" />
    /// <seealso cref="App.Core.Shared.Models.IHasDescription" />
    public class ApplicationDistributorInformationConfigurationSettings : IHostSettingsBasedConfigurationObject, IHasName , IHasDescription
    {
        public ApplicationDistributorInformationConfigurationSettings()
        {
            this.Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        public Guid Id { get; set; }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias( Constants.ConfigurationKeys.AppCoreApplicationProviderName)]
        public string Name
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationProviderDescription)]
        public string Description
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationProviderSiteUrl)]
        public string SiteUrl { get; set; }


        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationProviderContactUrl)]
        public string ContactUrl { get; set; }
    }
}