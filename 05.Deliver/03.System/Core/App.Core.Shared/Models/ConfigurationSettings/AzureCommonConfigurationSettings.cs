namespace App.Core.Shared.Models.ConfigurationSettings
{
    using App.Core.Shared.Attributes;

    public class AzureCommonConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName)]
        public string RootResourceName
        {
            get; set;
        }
    }
}