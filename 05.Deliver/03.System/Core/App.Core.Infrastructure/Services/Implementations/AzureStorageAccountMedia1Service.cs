namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Models.ConfigurationSettings;

    public class AzureStorageAccountMedia1Service : AzureStorageAccountServiceBase, IAzureStorageAccountMedia1Service
    {
        public AzureStorageAccountMedia1Service(
            AzureStorageAccountMedia1ServiceConfiguration configuration) : base(configuration)
        {

        }
    }
}