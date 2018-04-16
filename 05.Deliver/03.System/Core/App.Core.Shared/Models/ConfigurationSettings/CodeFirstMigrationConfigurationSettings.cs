namespace App.Core.Shared.Models.ConfigurationSettings
{
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration of 
    /// EF CodeFirst.
    /// </summary>
    public class CodeFirstMigrationConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreCodeFirstAttachDebuggerToPSSeeding)]
        public bool CodeFirstAttachDebugger { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreCodeFirstSeedIncludeDemoEntries)]
        public bool CodeFirstSeedDemoStuff { get; set; }

    }
}