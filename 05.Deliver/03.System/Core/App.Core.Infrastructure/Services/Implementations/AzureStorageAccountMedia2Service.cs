namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Models.ConfigurationSettings;

    public class AzureStorageAccountMedia2Service : AzureStorageAccountServiceBase, IAzureStorageAccountMedia2Service
    {
        public AzureStorageAccountMedia2Service(
            AzureStorageAccountMedia2ServiceConfiguration configuration) : base(configuration)
        {

        }
    }
}