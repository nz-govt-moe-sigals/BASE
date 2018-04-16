namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Models.ConfigurationSettings;

    public class AzureStorageAccountDiagnosticsService : AzureStorageAccountServiceBase, IAzureStorageAccountDiagnosticsService
    {
        public AzureStorageAccountDiagnosticsService(
            AzureStorageAccountDiagnosticsServiceConfiguration configuration) : base(configuration)
        {
            
        }
    }
}