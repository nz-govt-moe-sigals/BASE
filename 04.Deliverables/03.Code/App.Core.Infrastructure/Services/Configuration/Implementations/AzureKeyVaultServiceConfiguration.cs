

namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Core.Shared.Models.Configuration;

    public class AzureKeyVaultServiceConfiguration
    {
        public string KeyVaultUrl;

        public readonly AadApplicationRegistrationInformation AADClientInfo;

        public AzureKeyVaultConfiguration Configuration;

        public AzureKeyVaultServiceConfiguration(IHostSettingsService hostSettingsService)
        {
            this.AADClientInfo = hostSettingsService.GetObject<AadApplicationRegistrationInformation>();
            this.Configuration = hostSettingsService.GetObject<AzureKeyVaultConfiguration>();


        }

    }
}
