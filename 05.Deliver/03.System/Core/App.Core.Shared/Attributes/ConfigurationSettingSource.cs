namespace App.Core.Shared.Attributes
{
    using System;

    public class ConfigurationSettingSource : Attribute
    {
        public enum SourceType
        {
            All,
            AppSetting,
            KeyVault
        }

        public SourceType Source { get; private set; }
        public ConfigurationSettingSource(SourceType source)
        {
            Source = source;
        }
    }
}