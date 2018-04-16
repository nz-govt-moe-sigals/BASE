namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.ConfigurationSettings;

    public class AzureStorageAccountMedia2ServiceConfiguration : AzureStorageAccountServiceConfigurationBase
    {
        public AzureStorageAccountMedia2ServiceConfiguration(IAzureKeyVaultService keyVaultService) : base(keyVaultService)
        {

            var configuration =
                keyVaultService.GetObject<AzureStorageAccountMedia2ConfigurationSettings>();

            Initialize(configuration);
        }
    }
}