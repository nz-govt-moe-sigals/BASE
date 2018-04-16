namespace App.Core.Shared.Models.ConfigurationSettings
{
    public interface IStorageAccountConfigurationSettings
    {
        string ResourceName { get; set; }
        string Key { get; set; }
    }
}