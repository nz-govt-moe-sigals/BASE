namespace App.Core.Shared.Models.ConfigurationSettings
{
    using System;
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the Creator of the application
    /// (distinct from the Distributor/Resellers) in many commercial cases.
    /// <para>
    /// An Immutable Host Settings configuration object
    /// retrieved from the Host Settings.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Models.IHasName" />
    /// <seealso cref="App.Core.Shared.Models.IHasDescription" />
    public class ApplicationCreatorInformationConfigurationSettings : IHostSettingsBasedConfigurationObject,  IHasName, IHasDescription
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCreatorInformationConfigurationSettings"/> class.
        /// </summary>
        public ApplicationCreatorInformationConfigurationSettings()
        {
            this.Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        public Guid Id
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationCreatorName)]
        public string Name
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationCreatorDescription)]
        public string Description
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationCreatorSiteUrl)]
        public string SiteUrl
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationCreatorContactUrl)]
        public string ContactUrl
        {
            get; set;
        }
    }
}