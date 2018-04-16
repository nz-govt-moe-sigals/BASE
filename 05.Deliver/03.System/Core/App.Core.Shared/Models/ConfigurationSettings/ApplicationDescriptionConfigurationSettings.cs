namespace App.Core.Shared.Models.ConfigurationSettings
{
    using System;
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the Application (ie, shows up on the header).
    /// </summary>
    public class ApplicationDescriptionConfigurationSettings : IHostSettingsBasedConfigurationObject, IHasName, IHasDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDescriptionConfigurationSettings"/> class.
        /// </summary>
        public ApplicationDescriptionConfigurationSettings()
        {
            this.Id = new Guid();
        }

        // OData always needs an Id. It can be another field, but too much bother
        // to configure it...
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the Application
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias (Constants.ConfigurationKeys.AppCoreApplicationName)]
        public string Name { get;set; }

        /// <summary>
        /// Gets or sets the description/byline of the Application.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationDescription)]
        public string Description { get;set; }
    }
}
