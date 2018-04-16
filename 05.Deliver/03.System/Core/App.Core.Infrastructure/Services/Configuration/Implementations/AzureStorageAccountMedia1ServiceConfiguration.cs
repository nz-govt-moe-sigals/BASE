namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.ConfigurationSettings;

    public class AzureStorageAccountMedia1ServiceConfiguration : AzureStorageAccountServiceConfigurationBase
    {
        public AzureStorageAccountMedia1ServiceConfiguration(IAzureKeyVaultService keyVaultService) : base(keyVaultService)
        {

            var configuration =
                keyVaultService.GetObject<AzureStorageAccountMedia1ConfigurationSettings>();

            Initialize(configuration);
        }
    }
}