namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.ConfigurationSettings;

    public class AzureStorageAccountDiagnosticsServiceConfiguration : AzureStorageAccountServiceConfigurationBase
    {
        public AzureStorageAccountDiagnosticsServiceConfiguration(IAzureKeyVaultService keyVaultService):base(keyVaultService)
        {

            var configuration =
                keyVaultService.GetObject<AzureStorageAccountDiagnosticsConfigurationSettings>();

            Initialize(configuration);
        }
    }
}